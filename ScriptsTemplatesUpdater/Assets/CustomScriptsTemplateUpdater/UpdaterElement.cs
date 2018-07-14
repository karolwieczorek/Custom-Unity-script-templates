using UnityEngine;

namespace CustomScriptsTemplateUpdater
{
    public partial class Updater
    {
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