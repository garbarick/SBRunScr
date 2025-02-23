namespace SBRunScr.view.settings.tree;

public class SettingsNode : TreeNode
{
    public readonly SettingsPanel Control;

    public SettingsNode(SettingsPanel control)
    {
        Control = control;
        Text = Control.Text;
    }
}