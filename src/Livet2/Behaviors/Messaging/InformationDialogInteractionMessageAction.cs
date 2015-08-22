using Livet.Messaging;
using System.Windows;

namespace Livet.Behaviors.Messaging
{
    public class InformationDialogInteractionMessageAction : InteractionMessageAction<FrameworkElement>
    {
        protected override void InvokeAction(InteractionMessage message)
        {
            var informationMessage = message as InformationMessage;

            if (informationMessage != null)
            {
                MessageBox.Show(
                    informationMessage.Text,
                    informationMessage.Caption,
                    MessageBoxButton.OK,
                    informationMessage.Image
                    );
            }

        }
    }
}
