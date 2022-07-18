using UFO.UI.Dialogs;

namespace UFO.TestApp;

public class MainViewModel
{
    private readonly IDialog _dialog;
    private readonly SecondPage _secondPage;

    public MainViewModel(IDialog dialog, SecondPage secondPage)
    {
        _dialog = dialog;
        _secondPage = secondPage;
    }

    public async void OnAppearing()
    {
        await App.Current.MainPage.Navigation.PushAsync(_secondPage);
    }
}