namespace SBRunScr.view.settings.tree;

public partial class SettingsView : TreeView
{
    private readonly Control SettingsPanel;

    public SettingsView(Control SettingsPanel)
    {
        this.SettingsPanel = SettingsPanel;
        InitializeComponent();
    }

    private void BeforeCollapse_(object sender, TreeViewCancelEventArgs e)
    {
        e.Cancel = true;
    }

    private void BeforeSelect_(object sender, TreeViewCancelEventArgs e)
    {
        foreach (SettingsNode node in Collect(Nodes))
        {
            node.Control.Visible = false;
        }
        if (e.Node is SettingsNode current)
        {
            current.Control.Visible = true;
            current.Control.Size = new(SettingsPanel.Width - 10, SettingsPanel.Height);
            current.Control.OnShow();
        }
    }
}