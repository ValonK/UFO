using UFO.UI.Builders;

namespace UFO.UI.Controls.Selection;

public class UfoCheckBox : UfoSelectionControl
{
	public UfoCheckBox()
	{
		Content = new CheckBoxBuilder(this).Build();
	}
}