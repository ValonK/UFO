using CommunityToolkit.Maui.Views;
namespace UFO.UI.Dialogs;

public abstract class BaseDialog : Popup
{
	protected BaseDialog()
	{
		CanBeDismissedByTappingOutsideOfPopup = false;
		Color = Colors.Transparent;
	}
	
	protected static Page MainPage
	{
		get
		{
			if (Application.Current == null)
			{
				throw new InvalidOperationException("Application cannot be null");
			}

			if (Application.Current.MainPage == null)
			{
				throw new InvalidOperationException("MainPage cannot be null");
			}

			return Application.Current.MainPage;
		}
	}
}