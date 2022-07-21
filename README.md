
# UFO
A collection of **.NET MAUI** Controls & Dialogs (still under heavy development)

## Contents

- [Getting Started](#getting-started)
- [Features](#features)
  - [Controls](#controls)
    - [Cards](#cards)
    - [CheckBox](#checkbox)
  - [Dialogs](#dialogs)
    - [Confirm](#confirm)
    - [Alert](#alert)

### Getting Started

1. Download the [NuGet Package](https://www.google.com) and install it in your .NET MAUI project.
2. Make sure to use ```.UseMauiCommunityToolkit()``` in your ```MauiProgram.cs```.
3. Checkout the [Sample Application](https://github.com/ValonK/UFO/tree/main/sample/UFO.Sample).

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

#### With Font Icon

<img src="https://github.com/ValonK/UFO/blob/main/assets/dialogs/confirm/confirn_header_font_image.png?raw=true"  width="380" height="180">

```c#

var config = new ConfirmDialogConfig
{
    IconSource = new FontImageSource { 
        FontFamily = MaterialDesignIcons, 
        Color = Color.FromArgb("#7c54d4"),
        Size = 30,
        Glyph = "\U000f04d2",
    },
    IconHorizontalOptions = LayoutOptions.Start
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

#### With Font Icon
<img src="https://github.com/ValonK/UFO/blob/main/assets/dialogs/alert/alert_header_image.png?raw=true" width="380" height="210">

```c#
var config = new AlertDialogConfig
{
    IconSource = new FontImageSource
    {
        FontFamily = MaterialDesignIcons,
        Color = Color.FromArgb("#7c54d4"),
        Size = 30,
        Glyph = "\U000f04d2",
    },
    IconHorizontalOptions = LayoutOptions.Start
};

await _ufoDialog.ShowAlertDialogAsync("Title", "Description", config: config);
```


