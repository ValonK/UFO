using UFO.Sample.ViewModels.Controls;

namespace UFO.Sample.Pages.Controls;

public partial class SelectionControlsPage 
{
	public SelectionControlsPage(SelectionControlsViewModel selectionControlsViewModel)
	{
		InitializeComponent();
		BindingContext = selectionControlsViewModel;
	}
}