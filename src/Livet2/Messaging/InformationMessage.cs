using System.Windows;

namespace Livet.Messaging
{
    public class InformationMessage : InteractionMessage
    {
        public InformationMessage()
        {
        }

        public InformationMessage(string text, string caption, MessageBoxImage image, string messageKey)
            : base(messageKey)
        {
            Text = text;
            Caption = caption;
            MessageKey = messageKey;
            Image = image;
        }

        public InformationMessage(string text, string caption, string messageKey) : this(text, caption, MessageBoxImage.None, messageKey) { }


        protected override Freezable CreateInstanceCore()
        {
            return new InformationMessage(Text,Caption,MessageKey);
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(InformationMessage), new PropertyMetadata(null));

        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register(nameof(Caption), typeof(string), typeof(InformationMessage), new PropertyMetadata(null));


        public MessageBoxImage Image
        {
            get { return (MessageBoxImage)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register(nameof(Image), typeof(MessageBoxImage), typeof(InformationMessage), new PropertyMetadata());

        
        
    }
}