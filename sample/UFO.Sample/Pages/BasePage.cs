using UFO.Sample.ViewModels;

namespace UFO.Sample.Pages;

public class BasePage : ContentPage
{
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is BaseViewModel viewModel)
        {
            viewModel.OnAppearing();
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        if (BindingContext is BaseViewModel viewModel)
        {
            viewModel.OnDisappearing();
        }
    }
}