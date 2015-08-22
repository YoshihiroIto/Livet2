using System.Windows.Interactivity;
using System.Windows;

namespace Livet.Behaviors
{
    public class SetFocusAction : TriggerAction<FrameworkElement>
    {
        protected override void Invoke(object parameter)
        {
            AssociatedObject.Focus();
        }
    }
}
