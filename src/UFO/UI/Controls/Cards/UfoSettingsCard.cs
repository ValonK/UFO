using System.ComponentModel;
using UFO.UI.Builders;

namespace UFO.UI.Controls.Cards;

public class UfoSettingsCard : UfoCard
{
	public static readonly BindableProperty IconImageSourceProperty = BindableProperty.Create(nameof(IconImageSource), typeof(ImageSource), typeof(UfoSettingsCard));
	public static readonly BindableProperty IconVerticalOptionsProperty = BindableProperty.Create(nameof(IconVerticalOptions), typeof(LayoutOptions), typeof(UfoSettingsCard), defaultValue: LayoutOptions.Center);
	public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(UfoSettingsCard));
	public static readonly BindableProperty TitleFontFamilyProperty = BindableProperty.Create(nameof(TitleFontFamily), typeof(string), typeof(UfoSettingsCard));
	public static readonly BindableProperty TitleTextColorProperty = BindableProperty.Create(nameof(TitleTextColor), typeof(Color), typeof(UfoSettingsCard), defaultValue: Colors.Black);
	public static readonly BindableProperty TitleFontAttributesProperty = BindableProperty.Create(nameof(TitleFontAttributes), typeof(FontAttributes), typeof(UfoSettingsCard));
	public static readonly BindableProperty TitleFontSizeProperty = BindableProperty.Create(nameof(TitleFontSize), typeof(double), typeof(UfoSettingsCard), defaultValue: 20.0);
	public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(nameof(Description), typeof(string), typeof(UfoSettingsCard));
	public static readonly BindableProperty DescriptionFontFamilyProperty = BindableProperty.Create(nameof(TitleFontFamily), typeof(string), typeof(UfoSettingsCard));
	public static readonly BindableProperty DescriptionTextColorProperty = BindableProperty.Create(nameof(DescriptionTextColor), typeof(Color), typeof(UfoSettingsCard), defaultValue: Colors.Black);
	public static readonly BindableProperty DescriptionFontAttributesProperty = BindableProperty.Create(nameof(TitleFontAttributes), typeof(FontAttributes), typeof(UfoSettingsCard));
	public static readonly BindableProperty DescriptionFontSizeProperty = BindableProperty.Create(nameof(DescriptionFontSize), typeof(double), typeof(UfoSettingsCard), defaultValue: 17.0);
	public static readonly BindableProperty SettingsViewProperty = BindableProperty.Create(nameof(SettingsView), typeof(View), typeof(UfoSettingsCard));

	public UfoSettingsCard()
	{
		Content = new SettingsCardBuilder(this).Build();
	}

	public ImageSource IconImageSource
	{
		get => (ImageSource)GetValue(IconImageSourceProperty);
		set => SetValue(IconImageSourceProperty, value);
	}

	public string Title
	{
		get => (string)GetValue(TitleProperty);
		set => SetValue(TitleProperty, value);
	}

	public string TitleFontFamily
	{
		get => (string)GetValue(TitleFontFamilyProperty);
		set => SetValue(TitleFontFamilyProperty, value);
	}

	public Color TitleTextColor
	{
		get => (Color)GetValue(TitleTextColorProperty);
		set => SetValue(TitleTextColorProperty, value);
	}

	public FontAttributes TitleFontAttributes
	{
		get => (FontAttributes)GetValue(TitleFontAttributesProperty);
		set => SetValue(TitleFontAttributesProperty, value);
	}

	public double TitleFontSize
	{
		get => (double)GetValue(TitleFontSizeProperty);
		set => SetValue(TitleFontSizeProperty, value);
	}

	public string DescriptionFontFamily
	{
		get => (string)GetValue(DescriptionFontFamilyProperty);
		set => SetValue(DescriptionFontFamilyProperty, value);
	}

	public Color DescriptionTextColor
	{
		get => (Color)GetValue(DescriptionTextColorProperty);
		set => SetValue(DescriptionTextColorProperty, value);
	}

	public FontAttributes DescriptionFontAttributes
	{
		get => (FontAttributes)GetValue(DescriptionFontAttributesProperty);
		set => SetValue(DescriptionFontAttributesProperty, value);
	}

	public string Description
	{
		get => (string)GetValue(DescriptionProperty);
		set => SetValue(DescriptionProperty, value);
	}

	public View SettingsView
	{
		get => (View)GetValue(SettingsViewProperty);
		set => SetValue(SettingsViewProperty, value);
	}

	public double DescriptionFontSize
	{
		get => (double)GetValue(DescriptionFontSizeProperty);
		set => SetValue(DescriptionFontSizeProperty, value);
	}

	public LayoutOptions IconVerticalOptions
	{
		get => (LayoutOptions)GetValue(IconVerticalOptionsProperty);
		set => SetValue(IconVerticalOptionsProperty, value);
	}
}

internal sealed class SettingsCardBuilder : CardLayoutBuilder
{
	private readonly UfoSettingsCard _ufoSettingsCard;

	private readonly Image _iconImage = new() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
	private readonly VerticalStackLayout _labelVerticalStackLayout = new() { Spacing = 5 };
	private readonly Label _titleLabel = new() { VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Start };
	private readonly Label _descriptionLabel = new() { VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Start };
	private readonly ContentView _settingsContentView = new();

	public SettingsCardBuilder(UfoSettingsCard ufoSettingsCard)
	{
		_ufoSettingsCard = ufoSettingsCard;
		_ufoSettingsCard.PropertyChanged += UfoSettingsCardOnPropertyChanged;
		_ufoSettingsCard.Unloaded += UfoSettingsCardOnUnloaded;

		Construct();
	}

	internal override View Build()
	{
		return CardFrameContainer;
	}

	protected override void Construct()
	{
		_labelVerticalStackLayout.Children.Add(_titleLabel);
		_labelVerticalStackLayout.Children.Add(_descriptionLabel);

		ControlGridContainer.ColumnSpacing = 10;
		ControlGridContainer.ColumnDefinitions.Add(new(GridLength.Auto));
		ControlGridContainer.ColumnDefinitions.Add(new(GridLength.Star));
		ControlGridContainer.ColumnDefinitions.Add(new(GridLength.Auto));

		ControlGridContainer.Children.Add(_iconImage);
		ControlGridContainer.Children.Add(_labelVerticalStackLayout);
		ControlGridContainer.Children.Add(_settingsContentView);

		Grid.SetColumn(_iconImage, 0);
		Grid.SetColumn(_labelVerticalStackLayout, 1);
		Grid.SetColumn(_settingsContentView, 2);

		CardFrameContainer.Padding = 10;
		CardFrameContainer.Content = ControlGridContainer;
	}

	private void UfoSettingsCardOnPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		SetCardFrameProperties(e.PropertyName, _ufoSettingsCard);
		if (e.PropertyName == nameof(_ufoSettingsCard.Title)) _titleLabel.Text = _ufoSettingsCard.Title;
		if (e.PropertyName == nameof(_ufoSettingsCard.TitleFontFamily)) _titleLabel.FontFamily = _ufoSettingsCard.TitleFontFamily;
		if (e.PropertyName == nameof(_ufoSettingsCard.TitleTextColor)) _titleLabel.TextColor = _ufoSettingsCard.TitleTextColor;
		if (e.PropertyName == nameof(_ufoSettingsCard.TitleFontAttributes)) _titleLabel.FontAttributes = _ufoSettingsCard.TitleFontAttributes;
		if (e.PropertyName == nameof(_ufoSettingsCard.TitleFontSize)) _titleLabel.FontSize = _ufoSettingsCard.TitleFontSize;
		if (e.PropertyName == nameof(_ufoSettingsCard.Description)) _descriptionLabel.Text = _ufoSettingsCard.Description;
		if (e.PropertyName == nameof(_ufoSettingsCard.DescriptionFontFamily)) _descriptionLabel.FontFamily = _ufoSettingsCard.DescriptionFontFamily;
		if (e.PropertyName == nameof(_ufoSettingsCard.DescriptionTextColor)) _descriptionLabel.TextColor = _ufoSettingsCard.DescriptionTextColor;
		if (e.PropertyName == nameof(_ufoSettingsCard.DescriptionFontAttributes)) _descriptionLabel.FontAttributes = _ufoSettingsCard.DescriptionFontAttributes;
		if (e.PropertyName == nameof(_ufoSettingsCard.DescriptionFontSize)) _descriptionLabel.FontSize = _ufoSettingsCard.DescriptionFontSize;
		if (e.PropertyName == nameof(_ufoSettingsCard.SettingsView)) _settingsContentView.Content = _ufoSettingsCard.SettingsView;
		if (e.PropertyName == nameof(_ufoSettingsCard.IconImageSource)) _iconImage.Source = _ufoSettingsCard.IconImageSource;
		if (e.PropertyName == nameof(_ufoSettingsCard.IconVerticalOptions))
		{
			_iconImage.Margin = _ufoSettingsCard.IconVerticalOptions.Alignment switch
			{
				LayoutAlignment.Start => new Thickness(0, 5, 0, 0),
				LayoutAlignment.End => new Thickness(0, 0, 0, 5),
				_ => _iconImage.Margin
			};

			_iconImage.VerticalOptions = _ufoSettingsCard.IconVerticalOptions;
		}
	}

	private void UfoSettingsCardOnUnloaded(object sender, EventArgs e)
	{
		_ufoSettingsCard.Unloaded -= UfoSettingsCardOnUnloaded;
		_ufoSettingsCard.PropertyChanged -= UfoSettingsCardOnPropertyChanged;
	}
}