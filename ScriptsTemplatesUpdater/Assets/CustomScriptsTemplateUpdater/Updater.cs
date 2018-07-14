#if UNITY_EDITOR

using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace CustomScriptsTemplateUpdater
{
    public class Updater : EditorWindow
    {
        const string NEW_TEMPLATES_PATH = "CustomScriptsTemplateUpdater/ScriptTemplates";

        string TemplatesDirectory
        {
            get { return EditorApplication.applicationContentsPath + "/Resources/ScritpTemplates"; }
        }

        bool autoOpen; // TODO make as editor pref with default true
        
        bool updateScripts = true;
        bool cleanUp = true;
        bool restart = true;

        [MenuItem("Tools/Restart")]
        static void RestartUnity()
        {
            Process.Start(EditorApplication.applicationPath); 
            EditorApplication.Exit(0);
        }

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

            DrawDescription();

            if (GUILayout.Button(GetLabel()))
            {
                if (updateScripts)
                    UpdateScripts();
                if (cleanUp)
                    CleanUpProject();
                if (restart)
                    RestartUnity();

                return;
            }
            
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            autoOpen = GUILayout.Toggle(autoOpen, "Auto Open");
            GUILayout.EndHorizontal();
        }

        void DrawDescription()
        {
            updateScripts = GUILayout.Toggle(updateScripts, "UpdateScripts");
            var text = string.Format("Update scripts will copy all templates from \nAssets/{0} \nand paste them to \n{1}",
                NEW_TEMPLATES_PATH, TemplatesDirectory);
            GUILayout.Label(text);
            
            GUILayout.Space(10);

            cleanUp = GUILayout.Toggle(cleanUp, "Clean Up");
            var cleanUpText = string.Format("Clean up will remove {0}", "Assets/CustomScriptsTemplateUpdater");
            GUILayout.Label(cleanUpText);
            
            GUILayout.Space(10);
            
            restart = GUILayout.Toggle(restart, "Restart");
            var restartText = string.Format("Will restart unity.\nSo it will load new templates");
            GUILayout.Label(restartText);
        }

        string GetLabel()
        {
            List<string> labelElements = new List<string>();
            if (updateScripts)
                labelElements.Add("Update Scripts");
            if (cleanUp)
                labelElements.Add("Clean Up Project");
            if (restart)
                labelElements.Add("Restart Unity");

            return string.Join(" + ", labelElements.ToArray());
        }

        void UpdateScripts()
        {
            
        }

        void CleanUpProject()
        {
            
        }
    }
}

#endif