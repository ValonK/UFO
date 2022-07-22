using System.Windows.Input;

namespace UFO.UI.Controls.Cards;

public abstract class Card : ContentView
{

	public static readonly BindableProperty CornerRadiusProperty =
		BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(Card),
			defaultValue: 15f);

	public float CornerRadius
	{
		get => (float)GetValue(CornerRadiusProperty);
		set => SetValue(CornerRadiusProperty, value);
	}

}
