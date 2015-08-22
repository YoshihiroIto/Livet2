using System.Windows;
using System.Windows.Interactivity;

using Livet.Messaging;
using System.ComponentModel;

namespace Livet.Behaviors.Messaging
{
    [System.Windows.Markup.ContentProperty("DirectInteractionMessage")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
    public abstract class InteractionMessageAction<T> : TriggerAction<T> where T : DependencyObject
    {
        protected override sealed void Invoke(object parameter)
        {
            if ((bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue)) return;

            var message = parameter as InteractionMessage;

            if (DirectInteractionMessage != null)
            {
                message = DirectInteractionMessage.Message;
            }

            var window = Window.GetWindow(AssociatedObject);

            if (window == null) return;

            if ((!window.IsActive) && InvokeActionOnlyWhenWindowIsActive)
            {
                return;
            }

            if (message != null)
            {
                InvokeAction(message);

                DirectInteractionMessage?.InvokeCallbacks(message);
            }

        }

        protected abstract void InvokeAction(InteractionMessage message);

        public DirectInteractionMessage DirectInteractionMessage
        {
            get { return (DirectInteractionMessage)GetValue(DirectInteractionMessageProperty); }
            set { SetValue(DirectInteractionMessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DirectInteractionMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DirectInteractionMessageProperty =
            DependencyProperty.Register(nameof(DirectInteractionMessage), typeof(DirectInteractionMessage), typeof(InteractionMessageAction<T>), new PropertyMetadata());


        public bool InvokeActionOnlyWhenWindowIsActive
        {
            get { return (bool)GetValue(InvokeActionOnlyWhenWindowIsActiveProperty); }
            set { SetValue(InvokeActionOnlyWhenWindowIsActiveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InvokeActionOnlyWhenWindowIsActive.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InvokeActionOnlyWhenWindowIsActiveProperty =
            DependencyProperty.Register(nameof(InvokeActionOnlyWhenWindowIsActive), typeof(bool), typeof(InteractionMessageAction<T>), new PropertyMetadata(true));


    }
}
