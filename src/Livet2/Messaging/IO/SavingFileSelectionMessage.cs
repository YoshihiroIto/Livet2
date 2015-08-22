using System.Windows;
namespace Livet.Messaging.IO
{
    public class SavingFileSelectionMessage : FileSelectionMessage
    {
        public SavingFileSelectionMessage()
        {
        }

        public SavingFileSelectionMessage(string messageKey)
            : base(messageKey)
        {
        }

        protected override Freezable CreateInstanceCore()
        {
            return new SavingFileSelectionMessage(MessageKey);
        }

        public bool CreatePrompt
        {
            get { return (bool)GetValue(CreatePromptProperty); }
            set { SetValue(CreatePromptProperty, value); }
        }

        public static readonly DependencyProperty CreatePromptProperty =
            DependencyProperty.Register(nameof(CreatePrompt), typeof(bool), typeof(SavingFileSelectionMessage), new PropertyMetadata(false));

        public bool OverwritePrompt
        {
            get { return (bool)GetValue(OverwritePromptProperty); }
            set { SetValue(OverwritePromptProperty, value); }
        }

        public static readonly DependencyProperty OverwritePromptProperty =
            DependencyProperty.Register(nameof(OverwritePrompt), typeof(bool), typeof(SavingFileSelectionMessage), new PropertyMetadata(true));

        
        
    }
}