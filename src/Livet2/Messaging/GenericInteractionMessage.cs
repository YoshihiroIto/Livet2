using System.Windows;

namespace Livet.Messaging
{
    public class GenericInteractionMessage<T> : InteractionMessage
    {
        public GenericInteractionMessage(T value,string messageKey) : base(messageKey)
        {
            Value = value;
        }

        public GenericInteractionMessage(T value) :this(value,null)
        {
        }

        public T Value
        {
            get { return (T)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(T), typeof(GenericInteractionMessage<T>), new PropertyMetadata(defaultValue: default(T)));

        protected override Freezable CreateInstanceCore()
        {
            return new GenericInteractionMessage<T>(Value,MessageKey);
        }
    }
}
