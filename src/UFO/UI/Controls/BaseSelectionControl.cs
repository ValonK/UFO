namespace UFO.UI.Controls;

public abstract class BaseSelectionControl : ContentView
{
    public static readonly BindableProperty IsCheckedProperty = 
        BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(UfoCheckBox));
    
    public bool IsChecked
    {
        get => (bool)GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }

	public static readonly BindableProperty TextProperty =
	   BindableProperty.Create(nameof(Text), typeof(string), typeof(UfoCheckBox));

	public string Text
	{
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}

	public static readonly BindableProperty FontFamilyProperty =
	   BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(UfoCheckBox), defaultValue: string.Empty);

	public string FontFamily
	{
		get => (string)GetValue(FontFamilyProperty);
		set => SetValue(FontFamilyProperty, value);
	}

	public static readonly BindableProperty TextColorProperty =
		BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(UfoCheckBox), defaultValue: Colors.Black);

	public Color TextColor
	{
		get => (Color)GetValue(TextColorProperty);
		set => SetValue(TextColorProperty, value);
	}
}