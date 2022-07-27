using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using UFO.Sample.Pages.Controls;
using UFO.Sample.Pages.Controls.Cards;
using UFO.UI.Dialogs;

namespace UFO.Sample.ViewModels.Controls.Cards;

public partial class CardsViewModel : BaseViewModel
{
	private readonly IUfoDialog _ufoDialog;

	public CardsViewModel(IUfoDialog ufoDialog)
	{
		_ufoDialog = ufoDialog;
	}

	public ObservableCollection<CardItem> Cards { get; } = new();

	[RelayCommand]
	public async void CardSelected(CardItem cardItem)
	{
		if(cardItem.PageName == nameof(ParallaxCardPage))
		{
			if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
			{
				await _ufoDialog.ShowAlertDialogAsync("Parallax Card", "Parallax Card is not supported for Windows");
				return;
			}
		}

		await Shell.Current.GoToAsync(cardItem.PageName);
	}

	public override void OnAppearing()
	{
		if (Cards.Count != 0) return;

		Cards.Add(new(nameof(ActionCardPage), "Action Card", "You can configure distinct top and bottom views as well as whether to show or hide the action button and close button."));
		Cards.Add(new(nameof(AvatarCardPage), "Avatar Card", "You can configure distinct top and bottom views as well as specifiy the Avatar Image Source or use initials."));
		Cards.Add(new(nameof(ParallaxCardPage), "Parallax Card", "You can configure distinct foreground & background views for the parallax effect. The device's orientation sensor is used to create the effect."));
		Cards.Add(new(nameof(SettingsCardPage), "Settings Card", "You can customize a setting's symbol / picture as well as the settings control, such as CheckBox, Switch, or custom views, that you want to use."));
	}
}

public record CardItem(string PageName, string Title, string Description);

