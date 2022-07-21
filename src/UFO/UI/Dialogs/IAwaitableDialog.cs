namespace UFO.UI.Dialogs;

internal interface IAwaitableDialog
{
    TaskCompletionSource TaskCompletionSource { get; set; }
}