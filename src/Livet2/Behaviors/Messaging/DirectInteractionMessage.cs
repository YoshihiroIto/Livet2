using Livet.Messaging;
using System.Windows;
using System.Windows.Input;

namespace Livet.Behaviors.Messaging
{
    [System.Windows.Markup.ContentProperty("Message")]
    public class DirectInteractionMessage : Freezable
    {
        private readonly MethodBinderWithArgument _callbackMethod = new MethodBinderWithArgument();

        public InteractionMessage Message
        {
            get { return (InteractionMessage)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register(nameof(Message), typeof(InteractionMessage), typeof(DirectInteractionMessage), new UIPropertyMetadata(null));

        public ICommand CallbackCommand
        {
            get { return (ICommand)GetValue(CallbackCommandProperty); }
            set { SetValue(CallbackCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CallbackCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CallbackCommandProperty =
            DependencyProperty.Register(nameof(CallbackCommand), typeof(ICommand), typeof(DirectInteractionMessage), new UIPropertyMetadata(null));

        public object CallbackMethodTarget
        {
            get { return GetValue(CallbackMethodTargetProperty); }
            set { SetValue(CallbackMethodTargetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CallbackMethodTarget.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CallbackMethodTargetProperty =
            DependencyProperty.Register(nameof(CallbackMethodTarget), typeof(object), typeof(DirectInteractionMessage), new UIPropertyMetadata(null));

        public string CallbackMethodName
        {
            get { return (string)GetValue(CallbackMethodNameProperty); }
            set { SetValue(CallbackMethodNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CallbackMethodNameProperty =
            DependencyProperty.Register(nameof(CallbackMethodName), typeof(string), typeof(DirectInteractionMessage), new UIPropertyMetadata(null));

        internal void InvokeCallbacks(InteractionMessage message)
        {
            if (CallbackCommand != null)
            {
                if (CallbackCommand.CanExecute(message))
                {
                    CallbackCommand.Execute(message);
                }
            }
            if (CallbackMethodTarget != null && CallbackMethodName != null)
            {
                _callbackMethod.Invoke(CallbackMethodTarget, CallbackMethodName, message);
            }
        }

        protected override Freezable CreateInstanceCore()
        {
            return new DirectInteractionMessage();
        }
    }
}
