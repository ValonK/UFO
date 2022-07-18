using UFO.UI.Dialogs.Configs;

namespace UFO.UI.Dialogs;

public class Dialog : IDialog
{
    public async Task<bool> ShowConfirmDialogAsync(string title, string description, string positiveButton = "Ok",
        string negativeButton = "Cancel", ConfirmDialogConfig config = null)
    {
        return await ConfirmDialog.ShowAsync(title, description, positiveButton, negativeButton, config);
    }
}