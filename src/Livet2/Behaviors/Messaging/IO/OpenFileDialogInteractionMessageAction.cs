using Livet.Messaging.IO;
using Microsoft.Win32;
using System.Windows;

using Livet.Messaging;

namespace Livet.Behaviors.Messaging.IO
{
    public class OpenFileDialogInteractionMessageAction : InteractionMessageAction<DependencyObject>
    {
        protected override void InvokeAction(InteractionMessage message)
        {
            var openFileMessage = message as OpeningFileSelectionMessage;

            if (openFileMessage != null)
            {
                var dialog = new OpenFileDialog
                {
                    FileName = openFileMessage.FileName,
                    InitialDirectory = openFileMessage.InitialDirectory,
                    AddExtension = openFileMessage.AddExtension,
                    Filter = openFileMessage.Filter,
                    Title = openFileMessage.Title,
                    Multiselect = openFileMessage.MultiSelect
                };

                var showDialog = dialog.ShowDialog();
                openFileMessage.Response = showDialog != null && showDialog.Value ? dialog.FileNames : null;
            }
        }
    }
}
