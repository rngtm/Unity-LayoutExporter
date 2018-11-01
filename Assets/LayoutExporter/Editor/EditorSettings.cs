using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LayoutExporter
{
    internal static class EditorSettings
    {
        // menu name
        public const string LayoutExportWindow_MenuName = "Window/Layout Tools/Export Layout... (to Project)";
        public const string LayoutImportWindow_MenuName = "Window/Layout Tools/Import Layout... (to Unity editor)";

        // menu priority
        public const int LayoutExportWindow_MenuOrder = 1000;
        public const int LayoutImportWindow_MenuOrder = 1001;

        // window title
        public const string LayoutExportWindow_WindowTitle = "Export Layout";
        public const string LayoutImportWindow_WindowTitle = "Import Layout";

        // description
        public const string LayoutExportWindow_Description = "Export Layout (to Project)";
        public const string LayoutImportWindow_Description = "Import Layout (to Unity editor)";
    }
}