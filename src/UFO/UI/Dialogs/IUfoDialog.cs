using UFO.UI.Dialogs.Configs;
using UFO.UI.Dialogs.Confirm;

namespace UFO.UI.Dialogs;

public interface IUfoDialog
{
    Task<ConfirmDialogResult> ShowConfirmDialogAsync(string title, string description = "", string positiveButton = "Ok",
        string negativeButton = "Cancel", ConfirmDialogConfig config = null);
}