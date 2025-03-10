using SBRunScr.resources;

namespace SBRunScr.view.settings.tree;

public class SettingsPanel : GroupBox
{
    public virtual void OnShow()
    {
    }

    protected Button CreateButton(string name, EventHandler handler)
    {
        Button result = new();
        result.Image = Resources.GetIconAsImage(name, new Size(24, 24));
        result.Size = new Size(0, 40);
        result.Dock = DockStyle.Top;
        result.Click += handler;
        return result;
    }
}