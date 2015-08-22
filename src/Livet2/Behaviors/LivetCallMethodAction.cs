using System.Windows.Interactivity;
using System.Windows;

namespace Livet.Behaviors
{
    public class LivetCallMethodAction : TriggerAction<DependencyObject>
    {
        private readonly MethodBinder _method = new MethodBinder();
        private readonly MethodBinderWithArgument _callbackMethod = new MethodBinderWithArgument();

        private bool _parameterSet;

        public object MethodTarget
        {
            get { return GetValue(MethodTargetProperty); }
            set { SetValue(MethodTargetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MethodTarget.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MethodTargetProperty =
            DependencyProperty.Register(nameof(MethodTarget), typeof(object), typeof(LivetCallMethodAction), new PropertyMetadata(null));

        public string MethodName
        {
            get { return (string)GetValue(MethodNameProperty); }
            set { SetValue(MethodNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MethodNameProperty =
            DependencyProperty.Register(nameof(MethodName), typeof(string), typeof(LivetCallMethodAction), new PropertyMetadata(null));


        public object MethodParameter
        {
            get { return GetValue(MethodParameterProperty); }
            set { SetValue(MethodParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MethodParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MethodParameterProperty =
            DependencyProperty.Register(nameof(MethodParameter), typeof(object), typeof(LivetCallMethodAction), new PropertyMetadata(null, OnMethodParameterChanged));

        private static void OnMethodParameterChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var thisReference = (LivetCallMethodAction)sender;
            thisReference._parameterSet = true;
        }

        protected override void Invoke(object parameter)
        {
            if (MethodTarget == null) return;
            if (MethodName == null) return;

            if (!_parameterSet)
            {
                _method.Invoke(MethodTarget, MethodName);
            }
            else
            {
                _callbackMethod.Invoke(MethodTarget, MethodName, MethodParameter);
            }
        }
    }
}
