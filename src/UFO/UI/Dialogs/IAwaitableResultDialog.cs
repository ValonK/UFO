namespace UFO.UI.Dialogs;

internal interface IAwaitableResultDialog<T> 
{ 
    TaskCompletionSource<T> TaskCompletionSource { get; set; }
}
