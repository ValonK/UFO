using CommunityToolkit.Maui.Views;
using UFO.UI.Dialogs.Configs;

namespace UFO.UI.Dialogs;

//https://dribbble.com/shots/17967766-A-collection-of-modals-Untitled-UI
public class ConfirmDialog : BaseDialog, IAwaitableDialog<bool>
{
    private readonly ConfirmDialogConfig _confirmDialogConfiguration;
    
    public ConfirmDialog(ConfirmDialogConfig confirmDialogConfig)
    {
        _confirmDialogConfiguration = confirmDialogConfig;

        this.Content = new Grid
        {
            BackgroundColor = Colors.White,
            HeightRequest = 200,
            WidthRequest = 200,
        };
    }
 
    public TaskCompletionSource<bool> TaskCompletionSource { get; set; }

    public static async Task<bool> ShowAsync(string title, string description, string positiveButton = "Ok",
        string negativeButton = "Cancel", ConfirmDialogConfig confirmDialogConfig = null)
    {
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

