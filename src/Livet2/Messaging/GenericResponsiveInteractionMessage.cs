using System.Windows;

namespace Livet.Messaging
{
    public class GenericResponsiveInteractionMessage<TValue,TResponse> : ResponsiveInteractionMessage<TResponse>
    {

        public GenericResponsiveInteractionMessage(TValue value, string messageKey) : base(messageKey)
        {
            Value = value;
        }

        public GenericResponsiveInteractionMessage(TValue value) :this(value,null)
        {
        }

        public TValue Value
        {
            get { return (TValue)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(TValue), typeof(GenericResponsiveInteractionMessage<TValue, TResponse>), new PropertyMetadata(defaultValue: default(TValue)));

        protected override Freezable CreateInstanceCore()
        {
            return new GenericResponsiveInteractionMessage<TValue, TResponse>(Value,MessageKey);
        }
    }
}
