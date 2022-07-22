using UFO.Sample.ViewModels.Controls;

namespace UFO.Sample.Pages.Controls;

public partial class ChipsPage 
{
	public ChipsPage(ChipsViewModel chipsViewModel)
	{
		InitializeComponent();
		BindingContext = chipsViewModel;
	}
}