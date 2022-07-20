using CommunityToolkit.Mvvm.ComponentModel;

namespace UFO.Sample.ViewModels;

public abstract partial class BaseViewModel : ObservableObject
{
    public virtual void OnAppearing(){}
    public virtual void OnDisappearing(){}
}