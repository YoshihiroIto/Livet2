using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Livet.Behaviors
{
    public class MethodBinderWithArgument
    {
        private static readonly ConcurrentDictionary<Type, ConcurrentDictionary<string, Action<object, object>>> MethodCacheDictionary = new ConcurrentDictionary<Type, ConcurrentDictionary<string, Action<object, object>>>();

        private string _methodName;

        private Type _targetObjectType;
        private Type _argumentType;

        private MethodInfo _methodInfo;
        private Action<object, object> _method;

        public void Invoke(object targetObject, string methodName, object argument)
        {
            if (targetObject == null) throw new ArgumentNullException(nameof(targetObject));
            if (methodName == null) throw new ArgumentNullException(nameof(methodName));

            var newTargetObjectType = targetObject.GetType();
            var newArgumentType = argument.GetType();

            if (_targetObjectType == newTargetObjectType &&
                _methodName == methodName &&
                _argumentType == newArgumentType)
            {
                if (_method != null)
                {
                    _method(targetObject, argument);
                    return;
                }

                if (TryGetCacheFromMethodCacheDictionary(out _method))
                {
                    _method(targetObject, argument);
                    return;
                }

                if (_methodInfo != null)
                {
                    _methodInfo.Invoke(targetObject, new[] { argument });
                    return;
                }
            }

            _targetObjectType = newTargetObjectType;
            _argumentType = newArgumentType;
            _methodName = methodName;

            if (TryGetCacheFromMethodCacheDictionary(out _method))
            {
                _method(targetObject, argument);
                return;
            }

            _methodInfo = _targetObjectType.GetMethods()
                .FirstOrDefault(method =>
                {
                    if (method.Name != methodName) return false;

                    var parameters = method.GetParameters();

                    if (parameters.Length != 1) return false;

                    if (!_argumentType.IsAssignableFrom(parameters[0].ParameterType)) return false;

                    return method.ReturnType == typeof(void);
                });

            if (_methodInfo == null)
            {
                throw new ArgumentException(
                    $"{_targetObjectType.Name} 型に {_argumentType.Name} 型の引数を一つだけ持つメソッド {methodName} が見つかりません。");
            }

            _methodInfo.Invoke(targetObject, new[] { argument });

            var taskArgument = new Tuple<Type, MethodInfo, Type>(_targetObjectType, _methodInfo, _argumentType);

            Task.Factory.StartNew(arg =>
            {
                var taskArg = (Tuple<Type, MethodInfo, Type>)arg;

                var paraTarget = Expression.Parameter(typeof(object), "target");
                var paraMessage = Expression.Parameter(typeof(object), "argument");

                var method = Expression.Lambda<Action<object, object>>
                        (
                            Expression.Call
                                (
                                    Expression.Convert(paraTarget, taskArg.Item1),
                                    taskArg.Item2,
                                    Expression.Convert(paraMessage, taskArg.Item3)
                                ),
                                paraTarget,
                                paraMessage
                        ).Compile();

                var dic = MethodCacheDictionary.GetOrAdd(taskArg.Item1, _ => new ConcurrentDictionary<string, Action<object, object>>());
                dic.TryAdd(taskArg.Item2.Name, method);
            }, taskArgument);
        }

        private bool TryGetCacheFromMethodCacheDictionary(out Action<object, object> m)
        {
            m = null;
            var foundAction = false;
            ConcurrentDictionary<string, Action<object, object>> actionDictionary;
            if (MethodCacheDictionary.TryGetValue(_targetObjectType, out actionDictionary))
            {
                foundAction = actionDictionary.TryGetValue(_methodName, out m);
            }
            return foundAction;
        }
    }
}
