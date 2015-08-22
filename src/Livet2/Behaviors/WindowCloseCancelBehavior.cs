using System.Windows.Interactivity;
using System.Windows;
using System.Windows.Input;

namespace Livet.Behaviors
{
    public class WindowCloseCancelBehavior : Behavior<Window>
    {
        readonly MethodBinder _callbackMethod = new MethodBinder();

        public bool CanClose
        {
            get { return (bool)GetValue(CanCloseProperty); }
            set { SetValue(CanCloseProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanClose.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanCloseProperty =
            DependencyProperty.Register(nameof(CanClose), typeof(bool), typeof(WindowCloseCancelBehavior), new PropertyMetadata(true));

        public ICommand CloseCanceledCallbackCommand
        {
            get { return (ICommand)GetValue(CloseCanceledCallbackCommandProperty); }
            set { SetValue(CloseCanceledCallbackCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CloseCanceledCallbackCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CloseCanceledCallbackCommandProperty =
            DependencyProperty.Register(nameof(CloseCanceledCallbackCommand), typeof(ICommand), typeof(WindowCloseCancelBehavior), new PropertyMetadata(null));

        public object CloseCanceledCallbackMethodTarget
        {
            get { return GetValue(CloseCanceledCallbackMethodTargetProperty); }
            set { SetValue(CloseCanceledCallbackMethodTargetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CloseCanceledCallbackMethodTarget.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CloseCanceledCallbackMethodTargetProperty =
            DependencyProperty.Register(nameof(CloseCanceledCallbackMethodTarget), typeof(object), typeof(WindowCloseCancelBehavior), new PropertyMetadata(null));

        public string CloseCanceledCallbackMethodName
        {
            get { return (string)GetValue(CloseCanceledCallbackMethodNameProperty); }
            set { SetValue(CloseCanceledCallbackMethodNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CloseCanceledCallbackMethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CloseCanceledCallbackMethodNameProperty =
            DependencyProperty.Register(nameof(CloseCanceledCallbackMethodName), typeof(string), typeof(WindowCloseCancelBehavior), new PropertyMetadata(null));

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Closing += (sender, e) =>
            {
                if (!CanClose)
                {
                    if (CloseCanceledCallbackCommand != null && CloseCanceledCallbackCommand.CanExecute(null))
                    {
                        CloseCanceledCallbackCommand.Execute(null);
                    }

                    if (CloseCanceledCallbackMethodTarget != null && CloseCanceledCallbackMethodName != null)
                    {
                        _callbackMethod.Invoke(CloseCanceledCallbackMethodTarget, CloseCanceledCallbackMethodName);
                    }

                    e.Cancel = true;
                }
            };
        }
    }
}
