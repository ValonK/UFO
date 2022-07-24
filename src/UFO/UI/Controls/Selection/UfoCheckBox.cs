using System.ComponentModel;

namespace UFO.UI.Controls.Selection;

public class UfoCheckBox : UfoSelectionControl
{
	public UfoCheckBox()
	{
		Content = new CheckBoxBuilder(this).Build();
	}
}

internal sealed class CheckBoxBuilder : LayoutBuilder
{
	private readonly UfoCheckBox _ufoCheckBox;
	private readonly Grid _controlGridContainer = new();
	private readonly TapGestureRecognizer _labelGestureRecognizer = new();
	private readonly CheckBox _checkBox = new() { HorizontalOptions = LayoutOptions.Center };
	private readonly Label _textLabel = new()
	{
		HorizontalTextAlignment = TextAlignment.Start,
		VerticalTextAlignment = TextAlignment.Center
	};

	public CheckBoxBuilder(UfoCheckBox ufoCheckBox)
	{
		_ufoCheckBox = ufoCheckBox;
		_ufoCheckBox.Unloaded += UfoCheckBox_Unloaded;
		_ufoCheckBox.PropertyChanged += UfoCheckBox_PropertyChanged;

		Construct();
	}

	internal override View Build()
	{
		return _controlGridContainer;
	}

	protected override void Construct()
	{
		_checkBox.CheckedChanged += _checkBox_CheckedChanged;
		_labelGestureRecognizer.Tapped += LabelGestureRecognizer_Tapped;

		_textLabel.GestureRecognizers.Add(_labelGestureRecognizer);
		_controlGridContainer.ColumnDefinitions.Add(new(GridLength.Auto));
		_controlGridContainer.ColumnDefinitions.Add(new(GridLength.Star));

		_controlGridContainer.Children.Add(_checkBox);
		_controlGridContainer.Children.Add(_textLabel);

		Grid.SetColumn(_checkBox, 0);
		Grid.SetColumn(_textLabel, 1);
	}

	private void LabelGestureRecognizer_Tapped(object sender, EventArgs e)
	{
		_checkBox.IsChecked = !_checkBox.IsChecked;
	}

	private void _checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		_ufoCheckBox.IsChecked = e.Value;
		_ufoCheckBox.CheckedChangedCommand?.Execute(e.Value);
	}

	private void UfoCheckBox_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == nameof(_ufoCheckBox.IsChecked)) _checkBox.IsChecked = _ufoCheckBox.IsChecked;
		if (e.PropertyName == nameof(_ufoCheckBox.Color)) _checkBox.Color = _ufoCheckBox.Color;
		if (e.PropertyName == nameof(_ufoCheckBox.Text)) _textLabel.Text = _ufoCheckBox.Text;
		if (e.PropertyName == nameof(_ufoCheckBox.FontFamily)) _textLabel.FontFamily = _ufoCheckBox.FontFamily;
		if (e.PropertyName == nameof(_ufoCheckBox.TextColor)) _textLabel.TextColor = _ufoCheckBox.TextColor;
	}

	private void UfoCheckBox_Unloaded(object sender, EventArgs e)
	{
		_ufoCheckBox.Unloaded -= UfoCheckBox_Unloaded;
		_ufoCheckBox.PropertyChanged -= UfoCheckBox_PropertyChanged;
		_checkBox.CheckedChanged -= _checkBox_CheckedChanged;
		_labelGestureRecognizer.Tapped -= LabelGestureRecognizer_Tapped;
	}
}