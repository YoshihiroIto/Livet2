using System.Windows;

namespace Livet.Messaging.Windows
{
    public class WindowActionMessage : InteractionMessage
    {
        public WindowActionMessage()
        {
        }

        public WindowActionMessage(string messageKey)
            : base(messageKey) { }

        public WindowActionMessage(WindowAction action,string messageKey)
            :this(messageKey)
        {
            Action = action;
        }

        public WindowActionMessage(WindowAction action)
            : this(action,null) { }

        protected override Freezable CreateInstanceCore()
        {
            return new WindowActionMessage(MessageKey);
        }

        public WindowAction Action
        {
            get { return (WindowAction)GetValue(ActionProperty); }
            set { SetValue(ActionProperty, value); }
        }

        public static readonly DependencyProperty ActionProperty =
            DependencyProperty.Register(nameof(Action), typeof(WindowAction), typeof(WindowActionMessage), new PropertyMetadata());  
    }
}
