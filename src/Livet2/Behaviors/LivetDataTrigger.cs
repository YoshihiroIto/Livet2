using System.Windows;

namespace Livet.Behaviors
{
    public class LivetDataTrigger : Microsoft.Expression.Interactivity.Core.DataTrigger
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            EvaluateBindingChange(
                new DependencyPropertyChangedEventArgs(
                    ValueProperty,
                    null,
                    Value));
        }
    }
}
