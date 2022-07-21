namespace UFO.UI.Dialogs;

public sealed class ConfirmDialogResult
{
	public ConfirmDialogResult(bool dontShowAgain, bool result)
	{
		DontShowAgain = dontShowAgain;
		Result = result;
	}

	public bool DontShowAgain { get; }

	public bool Result { get; }
}
