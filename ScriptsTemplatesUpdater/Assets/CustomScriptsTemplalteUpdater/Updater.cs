#if UNITY_EDITOR

using System;
using System.Diagnostics;
using UnityEditor;
using Debug = UnityEngine.Debug;

namespace CustomScriptsTemplalteUpdater
{
    public static class Updater
    {
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
    }
}

#endif