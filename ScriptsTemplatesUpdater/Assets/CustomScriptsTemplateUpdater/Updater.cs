#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace CustomScriptsTemplateUpdater
{
    public partial class Updater : EditorWindow
    {
        const string NEW_TEMPLATES_PATH = "CustomScriptsTemplateUpdater/ScriptTemplates";

        static string TemplatesDirectory
        {
            get { return EditorApplication.applicationContentsPath + "/Resources/ScritpTemplates"; }
        }

        bool autoOpen; // TODO make as editor pref with default true

        readonly List<UpdaterElement> elements = new List<UpdaterElement>
        {
            new UpdateScriptsElement(), 
            new CleanUpElement(), 
            new RestartElement()
        };

        [MenuItem("Tools/LogPaths")]
        static void LogPaths()
        {
            Debug.Log(EditorApplication.applicationPath);
            Debug.Log(EditorApplication.applicationContentsPath);
        }

        [MenuItem("Tools/Script Templates Updater")]
        [UnityEditor.Callbacks.DidReloadScripts]
        static void OnScriptsReloaded()
        {
            var window = GetWindow<Updater>();
            window.titleContent = new GUIContent("Updater");
        }

        void OnGUI()
        {
            GUILayout.Label("Updater for Unity Script Templates");

            foreach (var element in elements)
                element.DrawDescription();

            if (GUILayout.Button(GetButtonLabel()))
            {
                foreach (var element in elements)
                    element.TryExecute();

                return;
            }
            
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            autoOpen = GUILayout.Toggle(autoOpen, "Auto Open");
            GUILayout.EndHorizontal();
        }

        string GetButtonLabel()
        {
            var labelElements = elements.Where(x => x.Enabled).Select(x => x.Name).ToArray();
            return string.Join(" + ", labelElements);
        }
    }
}

#endif