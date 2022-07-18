using UFO.UI.Dialogs.Configs;

namespace UFO.UI.Dialogs;

public interface IDialog
{
    Task<bool> ShowConfirmDialogAsync(string title, string description, string positiveButton = "Ok",
        string negativeButton = "Cancel", ConfirmDialogConfig config = null);
}