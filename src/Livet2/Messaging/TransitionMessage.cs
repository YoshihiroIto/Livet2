using System.Windows;
using System;

namespace Livet.Messaging
{
    [System.Windows.Markup.ContentProperty(nameof(TransitionViewModel))]
    public class TransitionMessage : ResponsiveInteractionMessage<bool?>
    {
        public TransitionMessage() { }

        public TransitionMessage(string messageKey) : base(messageKey) { }

        public TransitionMessage(ViewModel transitionViewModel, string messageKey)
            : this(null, transitionViewModel, TransitionMode.UnKnown, messageKey) { }

        public TransitionMessage(ViewModel transitionViewModel, TransitionMode mode, string messageKey)
            : this(null, transitionViewModel, mode, messageKey) { }

        public TransitionMessage(Type windowType, ViewModel transitionViewModel, TransitionMode mode, string messageKey)
            :base(messageKey)
        {
            Mode = mode;
            TransitionViewModel = transitionViewModel;

            if (windowType != null)
            {
                if (!windowType.IsSubclassOf(typeof(Window)))
                {
                    throw new ArgumentException("windowType need Window based.", nameof(windowType));
                }
            }

            WindowType = windowType;
        }

        public TransitionMessage(ViewModel transitionViewModel)
            : this(null, transitionViewModel, TransitionMode.UnKnown, null) { }

        public TransitionMessage(ViewModel transitionViewModel, TransitionMode mode)
            : this(null, transitionViewModel, mode, null) { }

        public TransitionMessage(Type windowType, ViewModel transitionViewModel, TransitionMode mode)
            : this(windowType,transitionViewModel,mode,null) { }

        public ViewModel TransitionViewModel
        {
            get { return (ViewModel)GetValue(TransitionViewModelProperty); }
            set { SetValue(TransitionViewModelProperty, value); }
        }

        public static readonly DependencyProperty TransitionViewModelProperty =
            DependencyProperty.Register(nameof(TransitionViewModel), typeof(ViewModel), typeof(TransitionMessage), new PropertyMetadata(null));

        public TransitionMode Mode
        {
            get { return (TransitionMode)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register(nameof(Mode), typeof(TransitionMode), typeof(TransitionMessage), new PropertyMetadata(TransitionMode.UnKnown));

        public Type WindowType
        {
            get { return (Type)GetValue(WindowTypeProperty); }
            set { SetValue(WindowTypeProperty, value); }
        }

        public static readonly DependencyProperty WindowTypeProperty =
            DependencyProperty.Register(nameof(WindowType), typeof(Type), typeof(TransitionMessage), new PropertyMetadata(null));

        protected override Freezable CreateInstanceCore()
        {
            return new TransitionMessage(TransitionViewModel,MessageKey);
        }
    }
}
