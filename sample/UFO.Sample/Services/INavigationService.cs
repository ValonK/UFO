namespace UFO.Sample.Services;

public interface INavigationService
{
    Task Navigate<T>() where T : ContentPage;
}
