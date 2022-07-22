using CommunityToolkit.Mvvm.Input;
using UFO.Sample.Pages.Controls;
using UFO.Sample.Pages.Controls.Cards;

namespace UFO.Sample.ViewModels.Controls;

public partial class ControlsViewModel : BaseViewModel
{
	[RelayCommand]
	public async Task OpenChipsAsync()
	{
		await Shell.Current.GoToAsync(nameof(ChipsPage));
	}

	[RelayCommand]
	public async Task OpenCardsAsync()
	{
		await Shell.Current.GoToAsync(nameof(CardsPage));
	}
}

