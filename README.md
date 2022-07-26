
# UFO 🛸

**.NET MAUI** Controls & Dialogs for Windows, iOS, and Android. Still being developed **not** released yet.


## Contents

- [Getting Started](#getting-started)
- [Features](#features)
  - [Controls](#controls)
    - [Cards](#cards)
      - [Action](#action)
      - [Avatar](#avatar)
      - [Carousel] (TODO)
      - [Credit] (TODO)
      - [Expandable] (TODO)
      - [Parallax](#parallax)
      - [Settings](#settings)
    - [Banner] (TODO) 
    - [CheckBox](#checkbox)
    - [Chip](#chip) 
    - [FAB] (TODO) 
    - [ImageCropper] (TODO)
    - [MarkdownLabel] (TODO)
  - [Dialogs](#dialogs)
    - [Alert](#alert)
    - [Confirm](#confirm)
    - [InputDialog] (TODO)
    - [LoadingDialog] (TODO)
    - [State] (TODO)
    - [Selection] (TODO)
    - [Toast] (TODO)
    - [Tutorial] (TODO)

### Getting Started

1. Download the [NuGet Package](https://www.google.com) and install it in your .NET MAUI project.
2. Make sure to use ```.UseMauiCommunityToolkit()``` in your ```MauiProgram.cs```.
3. Checkout the [Sample Application](https://github.com/ValonK/UFO/tree/main/sample/UFO.Sample).

## Features

### Cards

---
#### Action

<img src="https://github.com/ValonK/UFO/blob/main/assets/controls/cards/actioncard.png?raw=true" width="500" height="587">  

#### Properties

```HasActionButton``` - Activate/Deactivate Action Icon Button 

```IconSize``` - The Action Icon Button's size 

```IconLayoutOptions``` - Controls the icon button's position.  

```IconImageSource``` - The Icon Button's ImageSource 

```IconBackground``` - The Icon Button's Background: Color or Gradient 

```IconCommand``` - The Icon Button's Command 

```TopView``` - The Action Card's Top View 

```BottomView``` - The Action Card's bottom view 

```BorderColor``` - The Action Card's Border Color 

```CornerRadius``` - The Action Card's Corner Radius 

#### Sample Code
```xaml
<cards:UfoActionCard IconSize="60"
                     IconLayoutOptions="End">
    <cards:UfoActionCard.IconBackground>
        <LinearGradientBrush StartPoint="0,0" EndPoint="1,1">
            <GradientStop Color="{StaticResource Primary}" Offset="0.5" />
            <GradientStop Color="#fa05c9" Offset="0.8" />
        </LinearGradientBrush>
    </cards:UfoActionCard.IconBackground>
    <cards:UfoActionCard.IconImageSource>
        <FontImageSource FontFamily="{StaticResource MaterialFont}"
                         Glyph="{x:Static icon:IconFont.Ufo}"
                         Color="White"
                         Size="30"/>
    </cards:UfoActionCard.IconImageSource>
    <cards:UfoActionCard.TopView>
        <Image Source="cardimage.png" Aspect="AspectFill"/>
    </cards:UfoActionCard.TopView>
    <cards:UfoActionCard.BottomView>
      <Grid/>
    </cards:UfoActionCard.BottomView>
</cards:UfoActionCard>
```
---

#### Avatar

<img src="https://github.com/ValonK/UFO/blob/main/assets/controls/cards/avatarcard.png?raw=true" width="554" height="570">  

#### Properties

```AvatarBackgroundColor``` - The color of the Avatar's background 

```AvatarBorderColor``` - The Color of the Avatar's Border 

```AvatarBorderWidth``` - Border Width of the Avatar 

```AvatarSize``` - Size of the Avatar 

```AvatarText``` - Text of the Avatar 

```AvatarImageSource``` - Sources for the Avatar's Image: File, Font, Web 

```AvatarPadding``` - Padding of the Avatar

```AvatarTextColor``` - The text color of the avatar  

```BorderColor``` - Color of the Card's Border  

```CornerRadius``` - Radius of the Card's Corners 

```TopView``` - The Card's top view  

```BottomView``` - The Card's bottom view  

```Command``` - The Card's tapped command 

```CloseButtonImageSource``` - The Image Source of the Close Button 

```CloseButtonBackground``` - The Background of the Close Button 

```CloseButtonCommand``` - The Close Button tapped command 

```CloseButtonSize``` - The Size of the Close Button

#### Sample Code

```xaml
<cards:UfoAvatarCard AvatarTextColor="Black"
                     AvatarBorderWidth="20"
                     AvatarBorderColor="{StaticResource Primary}"
                     AvatarSize="80" 
                     AvatarText="JD"
                     CloseButtonSize="20">
      <cards:UfoAvatarCard.CloseButtonImageSource>
          <FontImageSource FontFamily="{StaticResource MaterialFont}"
                           Size="15"
                           Glyph="{x:Static icon:IconFont.Close}"
                           Color="White"/>
      </cards:UfoAvatarCard.CloseButtonImageSource>
        <cards:UfoAvatarCard.CloseButtonBackground>
          <LinearGradientBrush StartPoint="0,0" EndPoint="1,1">
            <GradientStop Color="{StaticResource Primary}" Offset="0.5" />
            <GradientStop Color="#fa05c9" Offset="0.8" />
          </LinearGradientBrush>
      </cards:UfoAvatarCard.CloseButtonBackground>
        <cards:UfoAvatarCard.TopView>
           <Image Source="cardimage.png" Aspect="AspectFill"/>
        </cards:UfoAvatarCard.TopView>
      <cards:UfoAvatarCard.BottomView>
          <Grid/>
      </cards:UfoAvatarCard.BottomView>
</cards:UfoAvatarCard>
```
---

#### Parallax

[ParallaxCard Preview](https://github.com/ValonK/Xamarin.Forms.Parallax)

The device's orientation sensor is used to create the parallax effect, checkout [DeviceOrientation Documentation](https://docs.microsoft.com/en-us/dotnet/maui/platform-integration/device/sensors?tabs=windows#orientation)

#### Properties

```ForegroundView``` - The View seen in the Foreground 

```BackgroundView``` - The View seen in the Background 

```IsParallaxActive``` - Activate/deactivate the parallax effect 

```xaml
<cards:UfoParallaxCard IsParallaxActive="True">
    <cards:UfoParallaxCard.ForegroundView>
        <Image Source="img_fg.png" 
               Aspect="AspectFill"/>
    </cards:UfoParallaxCard.ForegroundView>
    <cards:UfoParallaxCard.BackgroundView>
        <Image Source="img_bg.jpeg"
               Aspect="Fill"
               Margin="-200, 0, -200, 0"/>
    </cards:UfoParallaxCard.BackgroundView>
</cards:UfoParallaxCard>
```
---

#### Settings

<img src="https://github.com/ValonK/UFO/blob/main/assets/controls/cards/settings.png?raw=true" width="744" height="196">  

#### Properties

```IconImageSource``` - The Card icon's source  

```IconVerticalOptions``` - Vertical Options for the Card Icon 

```Title``` - Title Text

```TitleFontFamily``` - Title Font Family 

```TitleTextColor``` - Title Text Color

```TitleFontFamily``` - Title Font Attributes

```TitleFontAttributes``` - Title Font Attributes

```Description``` - Description Text 

```DescriptionFontFamily``` - Description Font Family 

```DescriptionTextColor``` - Description Text Color 

```DescriptionFontAttributes``` - Description Font Attributes

```SettingsView``` - The view where your check boxes and switches are located  


```xaml
<cards:UfoSettingsCard Title="Setting"
                       TitleFontAttributes="Bold"
                       TitleFontSize="14"
                       TitleTextColor="White"
                       Margin="5,0,5,0"		
                       DescriptionFontSize="10"
                       IconVerticalOptions="Center"
                       DescriptionTextColor="White"
                       Description="Lorem ipsum dolor sit amet"
                       Background="{StaticResource Gradient}">
      <cards:UfoSettingsCard.IconImageSource>
          <FontImageSource FontFamily="{StaticResource MaterialFont}"
                           Glyph="{x:Static icon:IconFont.Tools}"
                           Color="White"
                           Size="20"/>
      </cards:UfoSettingsCard.IconImageSource>
      <cards:UfoSettingsCard.SettingsView>
          <Switch VerticalOptions="Center"
                  HorizontalOptions="Center"
                  ThumbColor="White"
                  OnColor="GreenYellow"/>
      </cards:UfoSettingsCard.SettingsView>
</cards:UfoSettingsCard>
```

---

## Controls

---

#### CheckBox

#### Properties

```Text``` - CheckBox Text 

```IsChecked``` - CheckBox Is Checked 

```FontFamily``` - CheckBox Font Family

```TextColor``` - CheckBox Text Color

```Color``` - CheckBox Checked Color

```CheckedChangedCommand``` - CheckBox Command when IsChecked Changed

#### Sample Code

```xaml
<selectionControls:UfoCheckBox Color="Red"
                               Text="Text"
                               TextColor="Red"
                               IsChecked="{Binding IsChecked}"
                               CheckedChangedCommand="{Binding CheckBoxChangedCommand}"/>
```

---

#### Chip

<img src="https://github.com/ValonK/UFO/blob/main/assets/controls/chips/chip.png?raw=true" width="209" height="67">  

#### Properties

```ChipBorderColor``` - Color of the Chip's Border 

```ChipBackground``` - Chip's Background: Color, Gradient

```IconImageSource``` - Image Source of the Chip's Icon 

```CloseButtonIconImageSource``` - Image Source of the Chip's Close Icon 

```CloseButtonCommand``` - Chips's Close Command

```Command``` - Chips's Command

```Text``` - Chips's Text

```FontFamily``` - Chips's Font Family

```TextColor``` - Chips's Text Color

#### Sample Code

```xaml
<controls:UfoChip ChipBackground="{StaticResource Primary}"
                  Text="Chip 3"
                  HorizontalOptions="Center"
                  TextColor="White">
         <controls:UfoChip.IconImageSource>
            <FontImageSource FontFamily="{StaticResource MaterialFont}"
                             Glyph="{x:Static icon:IconFont.Ufo}"
                             Color="White"/>
         </controls:UfoChip.IconImageSource>
         <controls:UfoChip.CloseButtonIconImageSource>
            <FontImageSource FontFamily="{StaticResource MaterialFont}"
                             Glyph="{x:Static icon:IconFont.Close}"
                             Color="White"
                             Size="16"/>
          </controls:UfoChip.CloseButtonIconImageSource>
</controls:UfoChip>
```

---

## Dialogs

In your ```MauiProgram.cs``` file, register the ```IUfoDialog``` Service. 
```c#
builder.Services.AddSingleton<IUfoDialog, UfoDialog>();
```
Simply inject IUfoDialog into your ViewModel

```c#
private readonly IUfoDialog _ufoDialog;
public ViewModel(IUfoDialog ufoDialog)
{
    _ufoDialog = ufoDialog;
}
```
---

### Confirm

#### Default

<img src="https://github.com/ValonK/UFO/blob/main/assets/dialogs/confirm/confirm.png?raw=true" width="380" height="180">  

```c#
var result = await _ufoDialog.ShowConfirmDialogAsync("Title", "Description");
```

#### With CheckBox

<img src="https://github.com/ValonK/UFO/blob/main/assets/dialogs/confirm/confirm_checkbox.png?raw=true"  width="380" height="180">

```c#
var config = new ConfirmDialogConfig { ShowCheckBox = true };
var result = await _ufoDialog.ShowConfirmDialogAsync("Title", "Description", config: config);
```


#### With Icon

<img src="https://github.com/ValonK/UFO/blob/main/assets/dialogs/confirm/confirm_header_image.png?raw=true"  width="380" height="180">

```c#
var config = new ConfirmDialogConfig
{
    IconSource = new FileImageSource() { File = "headerimage.png" },
    IconHorizontalOptions = LayoutOptions.Start,
    IconHeight = 30,
    IconWidth = 30
};

var result = await _ufoDialog.ShowConfirmDialogAsync("Title", "Description", config: config);
```

---

### Alert

<img src="https://github.com/ValonK/UFO/blob/main/assets/dialogs/alert/alert.png?raw=true" width="380" height="210">

```c#
await _ufoDialog.ShowAlertDialogAsync("Title", "Description");
```

#### With Icon
<img src="https://github.com/ValonK/UFO/blob/main/assets/dialogs/alert/alert_font_header_image.png?raw=true" width="380" height="210">

```c#
var config = new AlertDialogConfig
{
    IconSource = new FileImageSource() { File = "headerimage.png" },
    IconHorizontalOptions = LayoutOptions.Start
};

await _ufoDialog.ShowAlertDialogAsync("Title", "Description", config: config);
```
---
