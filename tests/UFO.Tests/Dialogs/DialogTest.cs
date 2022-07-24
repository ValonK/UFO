using System.Reflection;
using Microsoft.Maui.Controls;
using UFO.UI.Dialogs;

namespace UFO.Tests.Dialogs;

public abstract class DialogTest
{
    protected static T GetDialogControl<T>(Dialog dialog, string controlName) where T : View
    {
        var fieldInfo = dialog.GetType().GetField(controlName, BindingFlags.Instance | BindingFlags.NonPublic);
        return fieldInfo?.GetValue(dialog) as T;
    }
}