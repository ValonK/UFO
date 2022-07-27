using CommunityToolkit.Mvvm.Input;
using UFO.UI.Dialogs;

namespace UFO.Sample.ViewModels.Controls.Cards;

public partial class ActionsCardViewModel : BaseViewModel
{
	private readonly IUfoDialog _ufoDialog;
	private LayoutOptions _actionButtonLayoutOption;
	private bool _isCloseButtonVisible;
	private bool _isActionButtonVisible;

	public ActionsCardViewModel(IUfoDialog ufoDialog)
	{
		_ufoDialog = ufoDialog;
	}

	public LayoutOptions ActionButtonLayoutOption
	{
		get => _actionButtonLayoutOption;
		set
		{
			_actionButtonLayoutOption = value;
			OnPropertyChanged(nameof(ActionButtonLayoutOption));
		}
	}

	public bool IsCloseButtonVisible
	{
		get => _isCloseButtonVisible;
		set
		{
			_isCloseButtonVisible = value;
			OnPropertyChanged(nameof(IsCloseButtonVisible));
		}
	}

	public bool IsActionButtonVisible 
	{
		get => _isActionButtonVisible;
		set 
		{
			_isActionButtonVisible = value;
			OnPropertyChanged(nameof(IsActionButtonVisible));
		} 
	}

	[RelayCommand]
	public void Card() => _ufoDialog.ShowAlertDialogAsync("Action Card", "Card Command");

	[RelayCommand]
	public void CardClose() => _ufoDialog.ShowAlertDialogAsync("Action Card", "Card Close Command");

	[RelayCommand]
	public void Icon() => _ufoDialog.ShowAlertDialogAsync("Action Card", "Icon Command");

	[RelayCommand]
	public void ShowHideCloseButton() => IsCloseButtonVisible = !IsCloseButtonVisible;

	[RelayCommand]
	public void ShowHideActionButton()
	{
		IsActionButtonVisible = !IsActionButtonVisible;
	}

	[RelayCommand]
	public void IconButtonPosition(string position)
	{
		ActionButtonLayoutOption = position switch
		{
			"Start" => LayoutOptions.Start,
			"Center" => LayoutOptions.Center,
			"End" => LayoutOptions.End,
			_ => ActionButtonLayoutOption
		};
	}

	public override void OnAppearing()
	{
		IsActionButtonVisible = true;
		ActionButtonLayoutOption = LayoutOptions.End;
	}
}