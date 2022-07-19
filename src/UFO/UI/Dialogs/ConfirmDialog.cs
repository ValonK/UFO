using CommunityToolkit.Maui.Views;
using UFO.UI.Dialogs.Configs;
using UFO.Utilities.Builders;

namespace UFO.UI.Dialogs;

//https://dribbble.com/shots/17967766-A-collection-of-modals-Untitled-UI
public class ConfirmDialog : BaseDialog, IAwaitableDialog<bool>
{
    private readonly ConfirmDialogConfig _confirmDialogConfiguration;
    private ConfirmDialogLayoutBuilder _confirmDialogLayoutBuilder;

    private ConfirmDialog(ConfirmDialogConfig confirmDialogConfig)
    {
        _confirmDialogConfiguration = confirmDialogConfig;
        CreateDialog();
    }

    private void CreateDialog()
    {
        _confirmDialogLayoutBuilder = new ConfirmDialogLayoutBuilder(_confirmDialogConfiguration);
        Content = _confirmDialogLayoutBuilder.CreateView(); 
    }
 
    public TaskCompletionSource<bool> TaskCompletionSource { get; set; }

    public static async Task<bool> ShowAsync(string title, string description, string positiveButton = "Ok",
        string negativeButton = "Cancel", ConfirmDialogConfig confirmDialogConfig = null)
    {
        confirmDialogConfig ??= new ConfirmDialogConfig();
        confirmDialogConfig.PositiveButtonText = positiveButton;
        confirmDialogConfig.NegativeButtonText = negativeButton;
        confirmDialogConfig.Title = title;
        confirmDialogConfig.Description = description;
        
        var dialog = new ConfirmDialog(confirmDialogConfig)
        {
            TaskCompletionSource = new TaskCompletionSource<bool>()
        };

        if (Application.Current == null)
        {
            throw new InvalidOperationException("Application.Current cannot be null");
        }
        
        await MainPage.ShowPopupAsync(dialog);

        return await dialog.TaskCompletionSource.Task;
    }
    
}

