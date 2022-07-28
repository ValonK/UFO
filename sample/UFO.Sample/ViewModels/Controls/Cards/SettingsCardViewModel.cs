using CommunityToolkit.Mvvm.Input;

namespace UFO.Sample.ViewModels.Controls.Cards;

public partial class SettingsCardViewModel : CardViewModel
{
	private LayoutOptions _iconLayoutOption;
	public LayoutOptions IconLayoutOption
	{
		get => _iconLayoutOption;
		set
		{
			_iconLayoutOption = value;
			OnPropertyChanged(nameof(IconLayoutOption));
		}
	}

	[RelayCommand]
	public void IconPosition(string position)
	{
		IconLayoutOption = position switch
		{
			"Start" => LayoutOptions.Start,
			"Center" => LayoutOptions.Center,
			"End" => LayoutOptions.End,
			_ => IconLayoutOption
		};
	}
}