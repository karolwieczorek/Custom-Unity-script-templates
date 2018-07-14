using UnityEditor;

namespace CustomScriptsTemplateUpdater
{
    public partial class Updater
    {
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
                var path = "Assets/" + MAIN_FOLDER;
                FileUtil.DeleteFileOrDirectory(path);
                FileUtil.DeleteFileOrDirectory(path + ".meta");
            }
        }
    }
}