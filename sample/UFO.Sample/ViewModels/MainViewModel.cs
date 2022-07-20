using CommunityToolkit.Mvvm.Input;
using UFO.Sample.Pages;
using UFO.Sample.Pages.Dialogs;

namespace UFO.Sample.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    [RelayCommand]
    private async Task OpenDialogsAsync()
    {
        await Shell.Current.GoToAsync(nameof(DialogsPage));
    }
}