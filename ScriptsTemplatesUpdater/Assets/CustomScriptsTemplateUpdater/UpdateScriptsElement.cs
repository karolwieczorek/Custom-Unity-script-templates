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
                
            }
        }
    }
}