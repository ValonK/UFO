
# UFO 🛸

**.NET MAUI** Controls & Dialogs for Windows, iOS, and Android. Still being developed **not** yet released


## Contents

- [Getting Started](#getting-started)
- [Features](#features)
  - [Controls](#controls)
    - [Cards](#cards)
      - [Action](#action)
      - [Avatar](#avatar)
      - [Carousel] (TOOO)
      - [Expandable] (TOOO)
      - [Parallax] (TOOO)
    - [CheckBox](#checkbox)
    - [Chip](#chip) 
    - [Banner] (TODO) 
    - [FAB] (TODO) 
  - [Dialogs](#dialogs)
    - [Alert](#alert)
    - [Confirm](#confirm)
    - [InputDialog] (TODO)
    - [LoadingDialog] (TODO)
    - [State] (TODO)
    - [Selection] (TODO)
    - [Toast] (TODO)

### Getting Started

1. Download the [NuGet Package](https://www.google.com) and install it in your .NET MAUI project.
2. Make sure to use ```.UseMauiCommunityToolkit()``` in your ```MauiProgram.cs```.
3. Checkout the [Sample Application](https://github.com/ValonK/UFO/tree/main/sample/UFO.Sample).

## Features

### Cards

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

```CloseImageSource``` - The Image Source of the Close Button 

```CloseBackground``` - The Background of the Close Button 

```CloseCommand``` - The Close Button tapped command 

```CloseSize``` - The Size of the Close Button

#### Sample Code

```xaml
<cards:UfoAvatarCard AvatarTextColor="Black"
                     AvatarBorderWidth="20"
                     AvatarBorderColor="{StaticResource Primary}"
                     AvatarSize="80" 
                     AvatarText="JD"
                     CloseSize="20">
      <cards:UfoAvatarCard.CloseImageSource>
          <FontImageSource FontFamily="{StaticResource MaterialFont}"
                           Size="15"
                           Glyph="{x:Static icon:IconFont.Close}"
                           Color="White"/>
      </cards:UfoAvatarCard.CloseImageSource>
        <cards:UfoAvatarCard.CloseBackground>
          <LinearGradientBrush StartPoint="0,0" EndPoint="1,1">
            <GradientStop Color="{StaticResource Primary}" Offset="0.5" />
            <GradientStop Color="#fa05c9" Offset="0.8" />
          </LinearGradientBrush>
      </cards:UfoAvatarCard.CloseBackground>
        <cards:UfoAvatarCard.TopView>
           <Image Source="cardimage.png" Aspect="AspectFill"/>
        </cards:UfoAvatarCard.TopView>
      <cards:UfoAvatarCard.BottomView>
          <Grid/>
      </cards:UfoAvatarCard.BottomView>
</cards:UfoAvatarCard>
```
## Controls

#### CheckBox

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

#### Chip

<img src="https://github.com/ValonK/UFO/blob/main/assets/controls/chips/chip.png?raw=true" width="209" height="67">  

```ChipBorderColor``` - Color of the Chip's Border 

```ChipBackground``` - Chip's Background: Color, Gradient

```IconImageSource``` - Image Source of the Chip's Icon 

```CloseIconImageSource``` - Image Source of the Chip's Close Icon 

```CloseCommand``` - Chips's Close Command

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
         <controls:UfoChip.CloseIconImageSource>
            <FontImageSource FontFamily="{StaticResource MaterialFont}"
                             Glyph="{x:Static icon:IconFont.Close}"
                             Color="White"
                             Size="16"/>
          </controls:UfoChip.CloseIconImageSource>
</controls:UfoChip>
```

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

### Confirm

#### Default

<img src="https://github.com/ValonK/UFO/blob/main/assets/dialogs/confirm/confirm.png?raw=true" width="380" height="180">  

```c#
var result = await _ufoDialog.ShowConfirmDialogAsync("Title", "Description");
```

#### With CheckBox

<img src="https://github.com/ValonK/UFO/blob/main/assets/dialogs/confirm/confirm_checkbox.png?raw=true"  width="380" height="180">

```c#
var confirmDialogConfig = new ConfirmDialogConfig { ShowDontAskAgain = true };
var result = await _ufoDialog.ShowConfirmDialogAsync("Title", "Description", config: confirmDialogConfig);
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
