namespace UFO.UI.Dialogs;

internal interface IAwaitableDialog<T> 
{
    TaskCompletionSource<T> TaskCompletionSource { get; set; }
}