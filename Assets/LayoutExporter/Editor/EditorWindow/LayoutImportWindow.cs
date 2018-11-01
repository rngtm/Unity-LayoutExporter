using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.IO;

namespace LayoutExporter
{
    public class LayoutImportWindow : EditorWindow
    {
        [SerializeField] private UnityEditor.DefaultAsset m_LayoutAsset;

        [MenuItem(EditorSettings.LayoutImportWindow_MenuName, false, EditorSettings.LayoutImportWindow_MenuOrder)]
        static void OpenWindow()
        {
            GetWindow<LayoutImportWindow>(EditorSettings.LayoutImportWindow_WindowTitle);
        }

        void OnGUI()
        {
            EditorGUILayout.LabelField(EditorSettings.LayoutImportWindow_Description);
            m_LayoutAsset = EditorGUILayout.ObjectField(m_LayoutAsset, typeof(UnityEditor.DefaultAsset), false) as UnityEditor.DefaultAsset;

            // レイアウトファイル(.wlt)をUnityEditorへ登録
            EditorGUI.BeginDisabledGroup(m_LayoutAsset == null);
            if (GUILayout.Button("Import"))
            {
                var filePath = Path.GetFullPath(
                    AssetDatabase.GetAssetPath(m_LayoutAsset)
                );
                var fileName = Path.GetFileName(filePath);

                var savePath = EditorUtility.SaveFilePanel(
                    "Save Layout File",
                    WindowLayout.LayoutsPreferencesPath,
                    fileName,
                    "wlt");

                if (!string.IsNullOrEmpty(savePath))
                {
                    var saveFullPath = Path.GetFullPath(savePath);
                    File.Copy(filePath, saveFullPath);

                    Debug.Log("Import: " + saveFullPath);
                }

                InternalEditorUtility.ReloadWindowLayoutMenu(); // レイアウトメニュー更新
            }
            EditorGUI.EndDisabledGroup();
        }
    }
}