namespace UFO.UI.Controls;

public partial class UfoCheckBox : BaseSelectionControl
{
	public UfoCheckBox()
	{
		InitializeComponent();
	}

	public event EventHandler<bool> CheckedChanged;

	private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		CheckedChanged?.Invoke(this, e.Value);
		CheckedChangedCommand?.Execute(e.Value);
	}
}