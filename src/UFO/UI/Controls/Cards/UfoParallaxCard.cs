using System.ComponentModel;
using UFO.Internals;
using UFO.UI.Builders;

namespace UFO.UI.Controls.Cards;

public class UfoParallaxCard : UfoCard
{
	public static readonly BindableProperty ForegroundViewProperty = BindableProperty.Create(nameof(ForegroundView), typeof(View), typeof(UfoParallaxCard));
	public static readonly BindableProperty BackgroundViewProperty = BindableProperty.Create(nameof(BackgroundView), typeof(View), typeof(UfoParallaxCard));
	public static readonly BindableProperty IsParallaxActiveProperty = BindableProperty.Create(nameof(IsParallaxActive), typeof(bool), typeof(UfoParallaxCard));

	public UfoParallaxCard()
	{
		Content = new ParallaxCardLayoutBuilder(this).Build();
	}
	
	public View ForegroundView
	{
		get => (View)GetValue(ForegroundViewProperty);
		set => SetValue(ForegroundViewProperty, value);
	}

	public View BackgroundView
	{
		get => (View)GetValue(BackgroundViewProperty);
		set => SetValue(BackgroundViewProperty, value);
	}

	public bool IsParallaxActive
	{
		get => (bool)GetValue(IsParallaxActiveProperty);
		set => SetValue(IsParallaxActiveProperty, value);
	}
}

internal sealed class ParallaxCardLayoutBuilder : CardLayoutBuilder
{
	private readonly UfoParallaxCard _parallaxCard;
	private readonly ContentView _foregroundView = new() { Padding = 0, VerticalOptions = LayoutOptions.End};
	private readonly ContentView _backgroundView = new() { Padding = 0, VerticalOptions = LayoutOptions.Fill};
	
	public ParallaxCardLayoutBuilder(UfoParallaxCard parallaxCard)
	{
		_parallaxCard = parallaxCard;
		_parallaxCard.PropertyChanged += ParallaxCard_PropertyChanged;
		_parallaxCard.Unloaded += ParallaxCard_Unloaded;
		
		Construct();
	}

	internal override View Build()
	{
		return CardFrameContainer;
	}

	protected override void Construct()
	{
		ControlGridContainer.Children.Add(_backgroundView);
		ControlGridContainer.Children.Add(_foregroundView);
		ControlGridContainer.Children.Add(CloseButton);
		
		CardFrameContainer.Content = ControlGridContainer;
	}

	private void ParallaxCard_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		SetCardFrameProperties(e.PropertyName, _parallaxCard);
		SetCloseButtonProperties(e.PropertyName, _parallaxCard);
		if (e.PropertyName == nameof(_parallaxCard.BackgroundView)) _backgroundView.Content = _parallaxCard.BackgroundView;
		if (e.PropertyName == nameof(_parallaxCard.ForegroundView)) _foregroundView.Content = _parallaxCard.ForegroundView;
		if (e.PropertyName == nameof(_parallaxCard.IsParallaxActive))
		{
			if (_parallaxCard.IsParallaxActive)
			{
				UfoOrientationSensor.OrientationChanged += UfoOrientationSensor_OrientationChanged;
				UfoOrientationSensor.Start();
			}
			else
			{
				UfoOrientationSensor.Stop();
				UfoOrientationSensor.OrientationChanged -= UfoOrientationSensor_OrientationChanged;
			}
		}
	}

	private async void UfoOrientationSensor_OrientationChanged(object sender, OrientationSensorChangedEventArgs e)
	{
		var xReading = e.Reading.Orientation.X;
		await _backgroundView.TranslateTo(xReading * 150, 0, 80);
	}

	private void ParallaxCard_Unloaded(object sender, EventArgs e)
	{
		_parallaxCard.PropertyChanged -= ParallaxCard_PropertyChanged;
		_parallaxCard.Unloaded -= ParallaxCard_Unloaded;

		UfoOrientationSensor.Stop();
		UfoOrientationSensor.OrientationChanged -= UfoOrientationSensor_OrientationChanged;
	}
}