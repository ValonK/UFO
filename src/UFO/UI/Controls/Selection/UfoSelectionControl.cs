using System.Windows.Input;
using UFO.Utilities;

namespace UFO.UI.Controls.Selection;

public abstract class UfoSelectionControl : ContentView
{
	public static readonly BindableProperty CheckedChangedCommandProperty = BindableProperty.Create(nameof(CheckedChangedCommand), typeof(ICommand), typeof(UfoSelectionControl));
	public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(UfoSelectionControl));
	public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(UfoSelectionControl), defaultBindingMode: BindingMode.TwoWay);
	public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(UfoSelectionControl));
	public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(UfoSelectionControl), defaultValue: Colors.Black);
	public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(UfoSelectionControl), defaultValue: UfoColors.UfoPrimaryColor);
	
	public ICommand CheckedChangedCommand
	{
		get => (ICommand)GetValue(CheckedChangedCommandProperty);
		set => SetValue(CheckedChangedCommandProperty, value);
	}
	
	public bool IsChecked
    {
        get => (bool)GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }
	
	public string Text
	{
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}

	public string FontFamily
	{
		get => (string)GetValue(FontFamilyProperty);
		set => SetValue(FontFamilyProperty, value);
	}
	
	public Color TextColor
	{
		get => (Color)GetValue(TextColorProperty);
		set => SetValue(TextColorProperty, value);
	}
	
	public Color Color
	{
		get => (Color)GetValue(ColorProperty);
		set => SetValue(ColorProperty, value);
	}
}