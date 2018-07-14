using System.Diagnostics;
using UnityEditor;

namespace CustomScriptsTemplateUpdater
{
    public partial class Updater
    {
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
    }
}