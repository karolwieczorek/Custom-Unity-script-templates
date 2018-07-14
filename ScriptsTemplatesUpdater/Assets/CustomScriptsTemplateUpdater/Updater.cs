#if UNITY_EDITOR

using System.Collections.Generic;
using System.Diagnostics;
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

            if (GUILayout.Button(GetLabel()))
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

        string GetLabel()
        {
            var labelElements = elements.Where(x => x.Enabled).Select(x => x.Name).ToArray();
            return string.Join(" + ", labelElements);
        }

        class UpdateScriptsElement : UpdaterElement
        {
            public override string Name
            {
                get { return "Update Scripts"; }
            }

            protected override string GetDescriptionText()
            {
                return string.Format("Update scripts will copy all templates from \nAssets/{0} \nand paste them to \n{1}",
                    NEW_TEMPLATES_PATH, TemplatesDirectory);
            }

            protected override void Execute()
            {
                
            }
        }

        class RestartElement : UpdaterElement
        {
            public override string Name
            {
                get { return "Restart"; }
            }

            protected override string GetDescriptionText()
            {
                return "Will restart unity.\nSo it will load new templates";
            }

            protected override void Execute()
            {
                Process.Start(EditorApplication.applicationPath); 
                EditorApplication.Exit(0);
            }
        }

        class CleanUpElement : UpdaterElement
        {
            public override string Name
            {
                get { return "Clean Up"; }
            }

            protected override string GetDescriptionText()
            {
                return string.Format("Clean up will remove {0}", "Assets/CustomScriptsTemplateUpdater");
            }

            protected override void Execute()
            {
                Debug.Log(Name);
            }
        }

        abstract class UpdaterElement
        {
            public abstract string Name { get; }
            bool enabled = true;
            public bool Enabled
            {
                get { return enabled; }
            }

            public void TryExecute()
            {
                if (enabled)
                    Execute();
            }

            public void DrawDescription()
            {
                enabled = GUILayout.Toggle(enabled, Name);
                GUILayout.Label(GetDescriptionText());
                GUILayout.Space(10);
            }

            protected abstract string GetDescriptionText();
            protected abstract void Execute();
        }
    }
}

#endif