using Livet.Messaging.IO;
using Microsoft.Win32;
using System.Windows;

using Livet.Messaging;

namespace Livet.Behaviors.Messaging.IO
{
    public class SaveFileDialogInteractionMessageAction : InteractionMessageAction<DependencyObject>
    {
        protected override void InvokeAction(InteractionMessage message)
        {
            var saveFileMessage = message as SavingFileSelectionMessage;

            if (saveFileMessage != null)
            {
                var dialog = new SaveFileDialog
                {
                    FileName = saveFileMessage.FileName,
                    InitialDirectory = saveFileMessage.InitialDirectory,
                    AddExtension = saveFileMessage.AddExtension,
                    CreatePrompt = saveFileMessage.CreatePrompt,
                    Filter = saveFileMessage.Filter,
                    OverwritePrompt = saveFileMessage.OverwritePrompt,
                    Title = saveFileMessage.Title
                };

                var showDialog = dialog.ShowDialog();
                saveFileMessage.Response = showDialog != null && showDialog.Value ? dialog.FileNames : null;
            }
        }
    }
}
