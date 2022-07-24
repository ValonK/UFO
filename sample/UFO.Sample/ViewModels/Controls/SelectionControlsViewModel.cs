using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UFO.Sample.ViewModels.Controls;

public partial class SelectionControlsViewModel : BaseViewModel
{
	private bool isChecked;

	public bool IsChecked {
		get => isChecked;
		set { 
			isChecked = value;
			OnPropertyChanged(nameof(IsChecked));
		}
	}

	[RelayCommand]
	public void CheckBoxChanged(bool value)
	{
	}

	public override void OnAppearing()
	{
		base.OnAppearing();
		IsChecked = true;
	}
}

