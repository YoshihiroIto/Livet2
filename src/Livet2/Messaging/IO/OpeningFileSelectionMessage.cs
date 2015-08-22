using System.Windows;

namespace Livet.Messaging.IO
{
    public class OpeningFileSelectionMessage : FileSelectionMessage
    {
        public OpeningFileSelectionMessage()
        {
        }

        public OpeningFileSelectionMessage(string messageKey)
            : base(messageKey)
        {
        }

        protected override Freezable CreateInstanceCore()
        {
            return new OpeningFileSelectionMessage(MessageKey);
        }

        public bool MultiSelect
        {
            get { return (bool)GetValue(MultiSelectProperty); }
            set { SetValue(MultiSelectProperty, value); }
        }

        public static readonly DependencyProperty MultiSelectProperty =
            DependencyProperty.Register(nameof(MultiSelect), typeof(bool), typeof(OpeningFileSelectionMessage), new PropertyMetadata(false));    
    }
}