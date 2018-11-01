using System.IO;
using UnityEditorInternal;

namespace LayoutExporter
{
    internal class WindowLayout
    {
        public static readonly string LayoutsPreferencesPath = Path.Combine(InternalEditorUtility.unityPreferencesFolder, "Layouts");
    }
}