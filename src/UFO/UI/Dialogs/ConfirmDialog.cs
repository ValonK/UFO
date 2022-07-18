using CommunityToolkit.Maui.Views;

namespace UFO.UI.Dialogs;

public class ConfirmDialog : Popup, IAwaitableDialog<bool>
{
    public TaskCompletionSource<bool> TaskCompletionSource { get; set; }
    
}