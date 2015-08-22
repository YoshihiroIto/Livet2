using System;
using System.Windows;

namespace Livet.Messaging
{
    public class InteractionMessage : Freezable
    {
        public InteractionMessage()
        {
            if(!DispatcherHelper.UIDispatcher?.CheckAccess() ?? true) throw new InvalidOperationException();
        }

        public InteractionMessage(string messageKey) :this()
        {
            MessageKey = messageKey;
        }

        public string MessageKey
        {
            get { return (string)GetValue(MessageKeyProperty); }
            set { SetValue(MessageKeyProperty, value); }
        }

        public static readonly DependencyProperty MessageKeyProperty =
            DependencyProperty.Register(nameof(MessageKey), typeof(string), typeof(InteractionMessage), new PropertyMetadata(null));

        protected override Freezable CreateInstanceCore()
        {
            return new InteractionMessage(MessageKey);
        }
    }
}