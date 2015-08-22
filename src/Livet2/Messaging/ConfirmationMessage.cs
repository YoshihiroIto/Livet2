using System.Windows;

namespace Livet.Messaging
{
    public class ConfirmationMessage : ResponsiveInteractionMessage<bool?>
    {
        public ConfirmationMessage(string text, string caption, MessageBoxImage image, MessageBoxButton button, MessageBoxResult defaultResult, string messageKey)
            : base(messageKey)
        {
            Text = text;
            Caption = caption;
            Image = image;
            Button = button;
            DefaultResult = defaultResult;
        }

        public ConfirmationMessage(string text, string caption, MessageBoxImage image,MessageBoxButton button, string messageKey)
            : this(text, caption, image, button, MessageBoxResult.OK, messageKey) { }

        public ConfirmationMessage(string text, string caption, MessageBoxImage image, string messageKey)
            : this(text, caption, image, MessageBoxButton.OK, messageKey) { }

        public ConfirmationMessage(string text, string caption, string messageKey)
            : this(text, caption, MessageBoxImage.None, messageKey) { }

        public ConfirmationMessage(string text, string caption)
            : this(text, caption, null) { }

        public ConfirmationMessage() { }

        protected override Freezable CreateInstanceCore()
        {
            return new ConfirmationMessage(Text, Caption, Image, Button, DefaultResult, MessageKey);
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(ConfirmationMessage), new PropertyMetadata(null));

        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register(nameof(Caption), typeof(string), typeof(ConfirmationMessage), new PropertyMetadata(null));

        public MessageBoxImage Image
        {
            get { return (MessageBoxImage)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register(nameof(Image), typeof(MessageBoxImage), typeof(ConfirmationMessage), new PropertyMetadata());

        public MessageBoxButton Button
        {
            get { return (MessageBoxButton)GetValue(ButtonProperty); }
            set { SetValue(ButtonProperty, value); }
        }

        public static readonly DependencyProperty ButtonProperty =
            DependencyProperty.Register(nameof(Button), typeof(MessageBoxButton), typeof(ConfirmationMessage), new PropertyMetadata(MessageBoxButton.OKCancel));  

        public MessageBoxResult DefaultResult
        {
            get { return (MessageBoxResult)GetValue(DefaultResultProperty); }
            set { SetValue(DefaultResultProperty, value); }
        }
        public static readonly DependencyProperty DefaultResultProperty =
            DependencyProperty.Register(nameof(DefaultResult), typeof(MessageBoxResult), typeof(ConfirmationMessage), new PropertyMetadata(MessageBoxResult.OK));
    }
}