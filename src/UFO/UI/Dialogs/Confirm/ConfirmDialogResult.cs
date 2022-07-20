namespace UFO.UI.Dialogs.Confirm;

public sealed class ConfirmDialogResult
{
	public ConfirmDialogResult(bool result)
	{
		Result = result;
	}

	public ConfirmDialogResult(bool dontShowAgain, bool result)
	{
		DontShowAgain = dontShowAgain;
		Result = result;
	}

	public bool DontShowAgain { get; set; }

	public bool Result { get; set; }
}
