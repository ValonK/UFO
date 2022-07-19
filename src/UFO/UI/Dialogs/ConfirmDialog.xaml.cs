using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using UFO.UI.Dialogs.Configs;
using UFO.Utilities.Builders;

namespace UFO.UI.Dialogs
{
	public partial class ConfirmDialog : BaseDialog, IAwaitableDialog<bool>
	{
		private readonly ConfirmDialogConfig _confirmDialogConfiguration;
		private ConfirmDialogLayoutBuilder _confirmDialogLayoutBuilder;

		private ConfirmDialog(ConfirmDialogConfig confirmDialogConfig)
		{
			InitializeComponent();
			_confirmDialogConfiguration = confirmDialogConfig;
			CreateDialog();
		}

		public TaskCompletionSource<bool> TaskCompletionSource { get; set; }

		private void CreateDialog()
		{
			if(_confirmDialogConfiguration.HeaderImageSource != null)
			{
				HeaderImage.Source = _confirmDialogConfiguration.HeaderImageSource;
				HeaderImage.VerticalOptions = _confirmDialogConfiguration.HeaderImageVerticalOptions;
				HeaderImage.HorizontalOptions = _confirmDialogConfiguration.HeaderImageHorizontalOptions;
			}
			else
			{
				HeaderImage.IsVisible = false;
			}
			
			TitleLabel.Text = _confirmDialogConfiguration.Title;
			TitleLabel.TextColor = _confirmDialogConfiguration.TitleFontColor;
			TitleLabel.FontSize = _confirmDialogConfiguration.TitleFontSize;

			if (!string.IsNullOrEmpty(_confirmDialogConfiguration.TitleFontFamily))
			{
				TitleLabel.FontFamily = _confirmDialogConfiguration.TitleFontFamily;
			}

			if (!string.IsNullOrEmpty(_confirmDialogConfiguration.Description))
			{
				DescriptionLabel.Text = _confirmDialogConfiguration.Description;
				DescriptionLabel.TextColor = _confirmDialogConfiguration.DescriptionFontColor;

				if (!string.IsNullOrEmpty(_confirmDialogConfiguration.DescriptionFontFamily))
				{
					DescriptionLabel.FontFamily = _confirmDialogConfiguration.DescriptionFontFamily;
				}
			}
			else
			{
				DescriptionLabel.IsVisible = false;
			}

			NegativeButton.BackgroundColor = _confirmDialogConfiguration.NegativeButtonColor;
			NegativeButton.Text = _confirmDialogConfiguration.NegativeButtonText;

			if (!string.IsNullOrEmpty(_confirmDialogConfiguration.NegativeButtonFontFamily))
			{
				NegativeButton.FontFamily = _confirmDialogConfiguration.NegativeButtonFontFamily;
			}

			NegativeButton.BorderColor = _confirmDialogConfiguration.NegativeButtonBorderColor;
			NegativeButton.BorderWidth = _confirmDialogConfiguration.NegativeButtonBorderWidth;
			NegativeButton.TextColor = _confirmDialogConfiguration.NegativeButtonFontColor;

			PositiveButton.BackgroundColor = _confirmDialogConfiguration.PositiveButtonColor;
			PositiveButton.Text = _confirmDialogConfiguration.PositiveButtonText;

			if (!string.IsNullOrEmpty(_confirmDialogConfiguration.PositiveButtonFontFamily))
			{
				PositiveButton.FontFamily = _confirmDialogConfiguration.PositiveButtonFontFamily;
			}
			PositiveButton.BorderColor = _confirmDialogConfiguration.NegativeButtonBorderColor;
			PositiveButton.BorderWidth = _confirmDialogConfiguration.NegativeButtonBorderWidth;
		}
 

		public static async Task<bool> ShowAsync(string title, string description, string positiveButton = "Ok",
			string negativeButton = "Cancel", ConfirmDialogConfig confirmDialogConfig = null)
		{
			confirmDialogConfig ??= new ConfirmDialogConfig();
			confirmDialogConfig.PositiveButtonText = positiveButton;
			confirmDialogConfig.NegativeButtonText = negativeButton;
			confirmDialogConfig.Title = title;
			confirmDialogConfig.Description = description;
        
			var dialog = new ConfirmDialog(confirmDialogConfig)
			{
				TaskCompletionSource = new TaskCompletionSource<bool>()
			};

			if (Application.Current == null)
			{
				throw new InvalidOperationException("Application.Current cannot be null");
			}
        
			await MainPage.ShowPopupAsync(dialog);

			return await dialog.TaskCompletionSource.Task;
		}

		private void NegativeButton_Clicked(object sender, EventArgs e)
		{

		}

		private void PositiveButton_Clicked(object sender, EventArgs e)
		{

		}
	}
}