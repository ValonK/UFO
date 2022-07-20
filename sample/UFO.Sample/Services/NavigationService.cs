using Maui.Plugins.PageResolver;

namespace UFO.Sample.Services;

public class NavigationService : INavigationService
{
    public async Task Navigate<T>() where T : ContentPage
    {
        await App.Current.MainPage.Navigation.PushAsync<T>();
    }
}