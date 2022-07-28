using CommunityToolkit.Mvvm.Input;
using UFO.UI.Dialogs;

namespace UFO.Sample.ViewModels.Controls.Cards;

public abstract partial class CardViewModel : BaseViewModel
{
	private bool _isCloseButtonVisible;

	public CardViewModel()
	{
		UfoDialog = Helpers.ServiceProvider.GetService<IUfoDialog>();
	}

	protected IUfoDialog UfoDialog { get; } 
	public bool IsCloseButtonVisible
	{
		get => _isCloseButtonVisible;
		set
		{
			_isCloseButtonVisible = value;
			OnPropertyChanged(nameof(IsCloseButtonVisible));
		}
	}


	[RelayCommand]
	public void Card() => UfoDialog.ShowAlertDialogAsync("Action Card", "Card Command");

	[RelayCommand]
	public void CardClose() => UfoDialog.ShowAlertDialogAsync("Action Card", "Card Close Command");

	[RelayCommand]
	public void ShowHideCloseButton() => IsCloseButtonVisible = !IsCloseButtonVisible;
}