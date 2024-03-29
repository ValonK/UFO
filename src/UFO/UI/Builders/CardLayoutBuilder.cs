﻿using UFO.UI.Controls.Cards;
using UFO.Utilities;

namespace UFO.UI.Builders;

internal abstract class CardLayoutBuilder : LayoutBuilder
{
    protected CardLayoutBuilder()
    {
        CardFrameContainer = new()
        {
            Padding = 0,
            CornerRadius = UfoSizes.DefaultCornerRadius,
            IsClippedToBounds = true
        };
        
        ControlGridContainer = new();
        
        CloseButton = new()
        {
            Padding = 0,
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.End,
            Margin = new Thickness(0, 10, 10, 0),
            HeightRequest = 20,
            WidthRequest = 20,
            CornerRadius = 10,
            IsVisible = false
        };
    }

    protected Frame CardFrameContainer { get; }
    protected Grid ControlGridContainer { get; }
    protected Button CloseButton { get; }

    protected void SetCardFrameProperties(string propertyName, UfoCard ufoCard)
    {
        switch (propertyName)
        {
            case nameof(UfoCard.CardBackground):
                CardFrameContainer.Background = ufoCard.CardBackground;
                break;
            case nameof(UfoCard.BorderColor):
                CardFrameContainer.BorderColor = ufoCard.BorderColor;
                break;
            case nameof(UfoCard.CornerRadius):
                CardFrameContainer.CornerRadius = ufoCard.CornerRadius;
                break;
            case nameof(UfoCard.Command):
            {
                var tapGestureRecognizer = new TapGestureRecognizer
                {
                    Command = ufoCard.Command
                };
                CardFrameContainer.GestureRecognizers.Clear();
                CardFrameContainer.GestureRecognizers.Add(tapGestureRecognizer);
            }
                break;
        }
    }

    protected void SetCloseButtonProperties(string propertyName, UfoCard ufoCard)
    {
        switch (propertyName)
        {
            case nameof(UfoCard.CloseButtonVisible):
                CloseButton.IsVisible = ufoCard.CloseButtonVisible;
                break;
            case nameof(UfoCard.CloseButtonImageSource):
                CloseButton.ImageSource = ufoCard.CloseButtonImageSource;
                break;
            case nameof(UfoCard.CloseButtonBackground):
                CloseButton.Background = ufoCard.CloseButtonBackground;
                break;
            case nameof(UfoCard.CloseButtonCommand):
                CloseButton.Command = ufoCard.CloseButtonCommand;
                break;
            case nameof(UfoCard.CloseButtonSize):
            {
                var size = ufoCard.CloseButtonSize;
                CloseButton.HeightRequest = size;
                CloseButton.WidthRequest = size;
                CloseButton.CornerRadius = (int)(size / 2);
                break;
            }
        }
    }
}