using System.ComponentModel;
using System.Windows.Input;

namespace UFO.UI.Controls;

public class UfoChip : ContentView
{
	public static readonly BindableProperty ChipBorderColorProperty = BindableProperty.Create(nameof(ChipBorderColor), typeof(Color), typeof(UfoChip), defaultValue: Colors.Transparent);
	public static readonly BindableProperty ChipBackgroundProperty = BindableProperty.Create(nameof(ChipBackground), typeof(Brush), typeof(UfoChip));
	public static readonly BindableProperty IconImageSourceProperty = BindableProperty.Create(nameof(IconImageSource), typeof(ImageSource), typeof(UfoChip));
	public static readonly BindableProperty CloseIconImageSourceProperty = BindableProperty.Create(nameof(CloseIconImageSource), typeof(ImageSource), typeof(UfoChip));
	public static readonly BindableProperty CloseCommandProperty = BindableProperty.Create(nameof(CloseCommand), typeof(ICommand), typeof(UfoChip));
	public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(UfoChip));
	public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(UfoChip), defaultValue: nameof(UfoChip));
	public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(UfoChip));
	public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(UfoChip), defaultValue: Colors.Black);

	public UfoChip()
	{
		Content = new ChipBuilder(this).Build();
	}

	public Color ChipBorderColor
	{
		get => (Color)GetValue(ChipBorderColorProperty);
		set => SetValue(ChipBorderColorProperty, value);
	}

	public Brush ChipBackground
	{
		get => (Brush)GetValue(ChipBackgroundProperty);
		set => SetValue(ChipBackgroundProperty, value);
	}

	public ImageSource IconImageSource
	{
		get => (ImageSource)GetValue(IconImageSourceProperty);
		set => SetValue(IconImageSourceProperty, value);
	}

	public ImageSource CloseIconImageSource
	{
		get => (ImageSource)GetValue(CloseIconImageSourceProperty);
		set => SetValue(CloseIconImageSourceProperty, value);
	}

	public ICommand CloseCommand
	{
		get => (ICommand)GetValue(CloseCommandProperty);
		set => SetValue(CloseCommandProperty, value);
	}

	public ICommand Command
	{
		get => (ICommand)GetValue(CommandProperty);
		set => SetValue(CommandProperty, value);
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
}

internal sealed class ChipBuilder : LayoutBuilder
{
	private readonly UfoChip _ufoChip;

	private readonly Frame _chipFrameContainer = new()
	{
		Padding = 5,
		CornerRadius = 17,
		HeightRequest = 34,
		IsClippedToBounds = true
	};

	private readonly Label _textLabel = new()
	{
		Margin = new Thickness(0, 0, 5, 0),
		VerticalTextAlignment = TextAlignment.Center,
		HorizontalTextAlignment = TextAlignment.Center
	};

	private readonly Grid _controlGridContainer = new() { ColumnSpacing = 5 };
	private readonly Image _iconImage = new() { VerticalOptions = LayoutOptions.Center };
	private readonly Image _closeImage = new() { VerticalOptions = LayoutOptions.Center };

	public ChipBuilder(UfoChip ufoChip)
	{
		_ufoChip = ufoChip;
		_ufoChip.Unloaded += UfoChip_Unloaded;
		_ufoChip.PropertyChanged += UfoChip_PropertyChanged;
		_ufoChip.IsClippedToBounds = true;
		_ufoChip.VerticalOptions = LayoutOptions.Center;

		Construct();
	}

	internal override View Build()
	{
		return _chipFrameContainer;
	}

	protected override void Construct()
	{
		_controlGridContainer.ColumnDefinitions.Add(new(GridLength.Auto));
		_controlGridContainer.ColumnDefinitions.Add(new(GridLength.Star));
		_controlGridContainer.ColumnDefinitions.Add(new(GridLength.Auto));

		_controlGridContainer.Children.Add(_iconImage);
		_controlGridContainer.Children.Add(_textLabel);
		_controlGridContainer.Children.Add(_closeImage);

		Grid.SetColumn(_iconImage, 0);
		Grid.SetColumn(_textLabel, 1);
		Grid.SetColumn(_closeImage, 2);

		_chipFrameContainer.Content = _controlGridContainer;
	}

	private void UfoChip_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == nameof(_ufoChip.ChipBorderColor)) _chipFrameContainer.BorderColor = _ufoChip.ChipBorderColor;
		if (e.PropertyName == nameof(_ufoChip.ChipBackground)) _chipFrameContainer.Background = _ufoChip.ChipBackground;
		if (e.PropertyName == nameof(_ufoChip.IconImageSource)) _iconImage.Source = _ufoChip.IconImageSource;
		if (e.PropertyName == nameof(_ufoChip.Text)) _textLabel.Text = _ufoChip.Text;
		if (e.PropertyName == nameof(_ufoChip.TextColor)) _textLabel.TextColor = _ufoChip.TextColor;
		if (e.PropertyName == nameof(_ufoChip.CloseIconImageSource)) _closeImage.Source = _ufoChip.CloseIconImageSource;

		if (e.PropertyName == nameof(_ufoChip.CloseCommand))
		{
			_closeImage.GestureRecognizers.Clear();
			_closeImage.GestureRecognizers.Add(new TapGestureRecognizer { Command = _ufoChip.CloseCommand });
		}

		if (e.PropertyName == nameof(_ufoChip.Command))
		{
			_chipFrameContainer.GestureRecognizers.Clear();
			_chipFrameContainer.GestureRecognizers.Add(new TapGestureRecognizer { Command = _ufoChip.Command });
		}
	}

	private void UfoChip_Unloaded(object sender, EventArgs e)
	{
		_ufoChip.Unloaded -= UfoChip_Unloaded;
		_ufoChip.PropertyChanged -= UfoChip_PropertyChanged;
	}
}
