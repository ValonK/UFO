using UFO.Sample.ViewModels.Controls.Cards;

namespace UFO.Sample.Pages.Controls.Cards;

public partial class SettingsCardPage 
{
	public SettingsCardPage(SettingsCardViewModel settingsCardViewModel)
	{
		InitializeComponent();
		BindingContext = settingsCardViewModel;
	}
}