using UFO.UI.Dialogs.Configs;

namespace UFO.UI.Dialogs;

public interface IUfoDialog
{
    Task ShowAlertDialogAsync(
        string title, 
        string description="", 
        string confirmButton = "Ok",
        AlertDialogConfig config = null);

    Task<ConfirmDialogResult> ShowConfirmDialogAsync(
        string title, 
        string description = "", 
        string positiveButton = "Ok",
        string negativeButton = "Cancel", 
        ConfirmDialogConfig config = null);
}