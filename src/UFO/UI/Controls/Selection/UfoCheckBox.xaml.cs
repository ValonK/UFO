namespace UFO.UI.Controls.Selection;

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

	private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
		CheckBox.IsChecked = !CheckBox.IsChecked;
	}
}