using UFO.UI.Dialogs.Configs;
using UFO.UI.Dialogs.Confirm;

namespace UFO.UI.Dialogs;

public class UfoDialog : IUfoDialog
{
    public async Task<ConfirmDialogResult> ShowConfirmDialogAsync(string title, string description = "", string positiveButton = "Ok",
        string negativeButton = "Cancel", ConfirmDialogConfig config = null)
    {
        return await ConfirmDialog.ShowAsync(title, description, positiveButton, negativeButton, config);
    }
}