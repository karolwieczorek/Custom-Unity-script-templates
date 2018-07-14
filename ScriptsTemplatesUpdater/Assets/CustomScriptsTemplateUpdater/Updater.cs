#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace CustomScriptsTemplateUpdater
{
    public class Updater : EditorWindow
    {
        const string newTemplatesPath = "CustomScriptsTemplateUpdater/ScriptTemplates";

        string TemplatesDirectory
        {
            get { return EditorApplication.applicationContentsPath + "/Resources/ScritpTemplates"; }
        }

        bool updateScripts = true;
        bool cleanUp = true;
        bool restart = true;

        [MenuItem("Tools/Restart")]
        static void RestartUnity()
        {
            Process.Start(EditorApplication.applicationPath); 
            Environment.Exit(1);
        }

        [MenuItem("Tools/LogPaths")]
        static void LogPaths()
        {
            Debug.Log(EditorApplication.applicationPath);
            Debug.Log(EditorApplication.applicationContentsPath);
        }

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
            }
        }

        void DrawDescription()
        {
            updateScripts = GUILayout.Toggle(updateScripts, "UpdateScripts");
            var text = string.Format("Update scripts will copy all templates from \nAssets/{0} \nand paste them to \n{1}",
                newTemplatesPath, TemplatesDirectory);
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