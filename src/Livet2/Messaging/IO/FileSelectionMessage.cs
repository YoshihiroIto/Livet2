using System.Windows;

namespace Livet.Messaging.IO
{
    public abstract class FileSelectionMessage : ResponsiveInteractionMessage<string[]>
    {
        protected FileSelectionMessage()
        {
        }

        protected FileSelectionMessage(string messageKey)
            : base(messageKey)
        {
        }

        protected abstract override Freezable CreateInstanceCore();

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(FileSelectionMessage), new PropertyMetadata(null));

        public string Filter
        {
            get { return (string)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }

        public static readonly DependencyProperty FilterProperty =
            DependencyProperty.Register(nameof(Filter), typeof(string), typeof(FileSelectionMessage), new PropertyMetadata(null));

        public bool AddExtension
        {
            get { return (bool)GetValue(AddExtensionProperty); }
            set { SetValue(AddExtensionProperty, value); }
        }

        public static readonly DependencyProperty AddExtensionProperty =
            DependencyProperty.Register(nameof(AddExtension), typeof(bool), typeof(FileSelectionMessage), new PropertyMetadata(true));

        public string InitialDirectory
        {
            get { return (string)GetValue(InitialDirectoryProperty); }
            set { SetValue(InitialDirectoryProperty, value); }
        }

        public static readonly DependencyProperty InitialDirectoryProperty =
            DependencyProperty.Register(nameof(InitialDirectory), typeof(string), typeof(FileSelectionMessage), new PropertyMetadata(null));

        public string FileName
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }

        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register(nameof(FileName), typeof(string), typeof(FileSelectionMessage), new PropertyMetadata(null));  
    }
}