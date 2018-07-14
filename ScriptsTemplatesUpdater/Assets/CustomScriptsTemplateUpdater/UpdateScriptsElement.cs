using System.IO;
using UnityEditor;
using UnityEngine;

namespace CustomScriptsTemplateUpdater
{
    public partial class Updater
    {
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
                var path = Path.Combine(Application.dataPath, NEW_TEMPLATES_PATH);
                var info = new DirectoryInfo(path);
                var fileInfo = info.GetFiles();
                foreach (var file in fileInfo)
                    if (!file.Name.EndsWith(".meta"))
                        CopyToTemplates(file);
            }

            static void CopyToTemplates(FileInfo file)
            {
                Debug.Log(file.FullName);
                var newPath = Path.Combine(TemplatesDirectory, file.Name);
                Debug.Log(newPath);
                
            }
        }
    }
}