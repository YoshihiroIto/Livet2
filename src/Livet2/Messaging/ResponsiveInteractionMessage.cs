using System.Windows;
namespace Livet.Messaging
{
    public abstract class ResponsiveInteractionMessage : InteractionMessage
    {
        internal ResponsiveInteractionMessage()
        {
        }

        internal ResponsiveInteractionMessage(string messageKey)
            : base(messageKey)
        {
        }

        internal object Response { get; set; }
    }

    public class ResponsiveInteractionMessage<T> : ResponsiveInteractionMessage
    {
        public ResponsiveInteractionMessage()
        {
        }

        public ResponsiveInteractionMessage( string messageKey )
            : base(messageKey)
        {
        }

        protected override Freezable CreateInstanceCore()
        {
            return new ResponsiveInteractionMessage<T>();
        }

        public new T Response 
        {
            get
            {
                return (T)base.Response;
            }
            set
            {
                base.Response = value;
            }
        }
    }
}