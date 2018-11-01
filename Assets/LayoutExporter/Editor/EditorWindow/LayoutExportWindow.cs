using System.Collections;
using System.IO;
using UnityEngine;
using UnityEditor;

namespace LayoutExporter
{
    public class LayoutExportWindow : EditorWindow
    {
        readonly GUIContent DescriptionContent = new GUIContent("Export Layout Settings to Project");

        private const int MaxLayoutNameLength = 15;
        private string[] m_Paths;
        private Vector2 m_ScrollPos;

        [MenuItem(EditorSettings.LayoutExportWindow_MenuName, false, EditorSettings.LayoutExportWindow_MenuOrder)]
        private static void Open()
        {
            GetWindow<LayoutExportWindow>(EditorSettings.LayoutExportWindow_WindowTitle);
        }

        private void OnFocus()
        {
            InitializePaths();
        }

        private void OnGUI()
        {
            // DrawHeader();

            EditorGUILayout.LabelField(EditorSettings.LayoutExportWindow_Description);

            if (m_Paths == null)
            {
                InitializePaths();
            }

            m_ScrollPos = EditorGUILayout.BeginScrollView(m_ScrollPos);
            foreach (string     path in m_Paths)
            {   
                string name     = Path.GetFileNameWithoutExtension(path);
                if (name.Length > MaxLayoutNameLength)
                    name = name.Substring(0, MaxLayoutNameLength) + "...";

                if (GUILayout.Button(string.Format("{0}", name)))
                {
                    Debug.Log(path);
                    var savePath = EditorUtility.SaveFilePanelInProject(
                        "Save Layout File",
                        name,
                        "wlt",
                        "");

                    if (!string.IsNullOrEmpty(savePath))
                    {
                        File.Copy(path, savePath);
                        AssetDatabase.Refresh();
                    }
                }
            }
            EditorGUILayout.EndScrollView();
        }

        private void InitializePaths()
        {
            string[] allPaths = Directory.GetFiles(WindowLayout.LayoutsPreferencesPath);
            ArrayList filteredFiles = new ArrayList();
            foreach (string path in allPaths)
            {
                string name = Path.GetFileName(path);
                if (Path.GetExtension(name) == ".wlt")
                {
                    filteredFiles.Add(path);
                }
            }
            m_Paths = filteredFiles.ToArray(typeof(string)) as string[];
        }

        private void DrawHeader()
        {
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
            {
                GUILayout.Label(DescriptionContent);
                GUILayout.FlexibleSpace();
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}