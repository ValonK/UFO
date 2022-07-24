using UFO.UI.Dialogs.Configs;

namespace UFO.UI.Dialogs;

public class UfoDialog : IUfoDialog
{
    public async Task ShowAlertDialogAsync(
        string title, 
        string description = "",
        string confirmButton = "Ok",
        AlertDialogConfig config = null)
    {
        await AlertDialog.ShowAsync(title, description, confirmButton, config);
    }

    public async Task<ConfirmDialogResult> ShowConfirmDialogAsync(
        string title,
        string description = "",
        string positiveButton = "Ok",
        string negativeButton = "Cancel", 
        ConfirmDialogConfig config = null)
    {
        return await ConfirmDialog.ShowAsync(title, description, positiveButton, negativeButton, config);
    }
}