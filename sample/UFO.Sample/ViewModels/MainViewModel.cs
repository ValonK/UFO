using CommunityToolkit.Mvvm.Input;
using UFO.Sample.Pages;
using UFO.Sample.Services;

namespace UFO.Sample.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;

    public MainViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    [RelayCommand]
    private async Task OpenDialogsAsync()
    {
        await _navigationService.Navigate<DialogsPage>();
    }
}