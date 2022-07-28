using CommunityToolkit.Mvvm.Input;
using UFO.UI.Dialogs;

namespace UFO.Sample.ViewModels.Controls.Cards;

public partial class ActionsCardViewModel : CardViewModel
{
	private LayoutOptions _actionButtonLayoutOption;
	private bool _isActionButtonVisible;

	public LayoutOptions ActionButtonLayoutOption
	{
		get => _actionButtonLayoutOption;
		set
		{
			_actionButtonLayoutOption = value;
			OnPropertyChanged(nameof(ActionButtonLayoutOption));
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
	public void Icon() => UfoDialog.ShowAlertDialogAsync("Action Card", "Icon Command");

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