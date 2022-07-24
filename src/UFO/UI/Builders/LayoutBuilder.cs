namespace UFO.UI.Builders;

internal abstract class LayoutBuilder
{
	protected LayoutBuilder() { }

	internal abstract View Build();

	protected abstract void Construct();
}