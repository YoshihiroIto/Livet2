using System;
using System.Linq;
using Livet.Messaging;
using System.Windows;

namespace Livet.Behaviors.Messaging
{
    public class TransitionInteractionMessageAction : InteractionMessageAction<FrameworkElement>
    {
        public Type WindowType
        {
            get { return (Type)GetValue(WindowTypeProperty); }
            set { SetValue(WindowTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WindowType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WindowTypeProperty =
            DependencyProperty.Register(nameof(WindowType), typeof(Type), typeof(TransitionInteractionMessageAction), new PropertyMetadata());

        private static bool IsValidWindowType(Type value)
        {
            if (value != null)
            {
                if (value.IsSubclassOf(typeof(Window)))
                {
                    return value.GetConstructor(Type.EmptyTypes) != null;
                }
            }

            return false;
        }

        public TransitionMode Mode
        {
            get { return (TransitionMode)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register(nameof(Mode), typeof(TransitionMode), typeof(TransitionInteractionMessageAction), new PropertyMetadata(TransitionMode.Normal));

        public bool IsOwned
        {
            get { return (bool)GetValue(OwnedFromThisProperty); }
            set { SetValue(OwnedFromThisProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OwnedFromThis.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OwnedFromThisProperty =
            DependencyProperty.Register(nameof(IsOwned), typeof(bool), typeof(TransitionInteractionMessageAction), new PropertyMetadata(true));

        protected override void InvokeAction(InteractionMessage message)
        {
            var transitionMessage = message as TransitionMessage;

            if (transitionMessage == null) return;

            var targetType = transitionMessage.WindowType ?? WindowType;

            if (!IsValidWindowType(targetType))
            {
                return;
            }

            var defaultConstructor = targetType.GetConstructor(Type.EmptyTypes);

            if (Mode == TransitionMode.UnKnown && transitionMessage.Mode == TransitionMode.UnKnown)
            {
                return;
            }

            var mode = transitionMessage.Mode == TransitionMode.UnKnown ? Mode : transitionMessage.Mode;

            switch (mode)
            {
                case TransitionMode.Normal:
                case TransitionMode.Modal:
                    if (defaultConstructor != null)
                    {
                        var targetWindow = (Window)defaultConstructor.Invoke(null);
                        if (transitionMessage.TransitionViewModel != null)
                        {
                            targetWindow.DataContext = transitionMessage.TransitionViewModel;
                        }

                        if (IsOwned)
                        {
                            targetWindow.Owner = Window.GetWindow(AssociatedObject);
                        }

                        if (mode == TransitionMode.Normal)
                        {
                            targetWindow.Show();
                            transitionMessage.Response = null;
                        }
                        else
                        {
                            transitionMessage.Response = targetWindow.ShowDialog();
                        }
                    }

                    break;
                case TransitionMode.NewOrActive:
                    var window = Application.Current.Windows
                        .OfType<Window>()
                        .FirstOrDefault(w => w.GetType() == targetType);

                    if (window == null)
                    {
                        if (defaultConstructor != null) window = (Window)defaultConstructor.Invoke(null);

                        if (window != null)
                        {
                            if (transitionMessage.TransitionViewModel != null)
                            {
                                window.DataContext = transitionMessage.TransitionViewModel;
                            }
                            if (IsOwned)
                            {
                                window.Owner = Window.GetWindow(AssociatedObject);
                            }
                            window.Show();
                        }
                        transitionMessage.Response = null;
                    }
                    else
                    {
                        if (transitionMessage.TransitionViewModel != null)
                        {
                            window.DataContext = transitionMessage.TransitionViewModel;
                        }
                        if (IsOwned)
                        {
                            window.Owner = Window.GetWindow(AssociatedObject);
                        }
                        window.Activate();
                        if (window.WindowState == WindowState.Minimized)
                        {
                            window.WindowState = WindowState.Normal;
                        }
                        transitionMessage.Response = null;
                    }
                    break;
            }

        }

    }
}
