using System.Windows.Input;
using UFO.Utilities;

namespace UFO.UI.Controls;

public abstract class BaseSelectionControl : ContentView
{

	public static readonly BindableProperty CheckedChangedCommandProperty =
		BindableProperty.Create(nameof(CheckedChangedCommand), typeof(ICommand), typeof(BaseSelectionControl));

	public ICommand CheckedChangedCommand
	{
		get => (ICommand)GetValue(CheckedChangedCommandProperty);
		set => SetValue(CheckedChangedCommandProperty, value);
	}

	public static readonly BindableProperty IsCheckedProperty = 
        BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(BaseSelectionControl),
			defaultBindingMode: BindingMode.TwoWay);

	public bool IsChecked
    {
        get => (bool)GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }

	public static readonly BindableProperty TextProperty =
	   BindableProperty.Create(nameof(Text), typeof(string), typeof(BaseSelectionControl));

	public string Text
	{
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}

	public static readonly BindableProperty FontFamilyProperty =
	   BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(BaseSelectionControl), defaultValue: string.Empty);

	public string FontFamily
	{
		get => (string)GetValue(FontFamilyProperty);
		set => SetValue(FontFamilyProperty, value);
	}

	public static readonly BindableProperty TextColorProperty =
		BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(BaseSelectionControl), defaultValue: Colors.Black);

	public Color TextColor
	{
		get => (Color)GetValue(TextColorProperty);
		set => SetValue(TextColorProperty, value);
	}

	public static readonly BindableProperty ColorProperty =
		BindableProperty.Create(nameof(Color), typeof(Color), typeof(BaseSelectionControl), defaultValue: UfoColors.UfoPrimaryColor);

	public Color Color
	{
		get => (Color)GetValue(ColorProperty);
		set => SetValue(ColorProperty, value);
	}
}