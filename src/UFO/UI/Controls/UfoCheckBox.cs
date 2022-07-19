namespace UFO.UI.Controls;

public class UfoCheckBox : BaseSelectionControl
{
	public UfoCheckBox()
    {
        CreateControl();
    }

    private Label CreateLabel()
    {
	    var label = new Label
	    {
		    HorizontalTextAlignment = TextAlignment.Start,
		    VerticalTextAlignment = TextAlignment.Center
	    };
	    
	    label.SetBinding(Label.TextProperty, TextProperty.PropertyName);
	    label.SetBinding(Label.TextColorProperty, TextColorProperty.PropertyName);
	    label.SetBinding(Label.FontFamilyProperty, FontFamilyProperty.PropertyName);

		return label;
    }

    private static CheckBox CreateCheckBox()
    {
	    var checkBox = new CheckBox();
	    checkBox.SetBinding(CheckBox.IsCheckedProperty, IsCheckedProperty.PropertyName);

	    return checkBox;
    }
    
    private void CreateControl()
    {
	    var containerGrid = new Grid();
	    var label = CreateLabel();
	    var checkBox = CreateCheckBox();
	    
	    containerGrid.ColumnDefinitions.Add(new(GridLength.Auto));
	    containerGrid.ColumnDefinitions.Add(new(GridLength.Star));

	    containerGrid.Children.Add(checkBox);
	    containerGrid.Children.Add(label);

		Grid.SetColumn(checkBox, 0);
		Grid.SetColumn(label, 1);

		Content = containerGrid;
	}
}