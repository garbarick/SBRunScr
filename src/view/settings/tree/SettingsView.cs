namespace SBRunScr.view.settings.tree;

public partial class SettingsView : TreeView
{
    private readonly Control SettingsPanel;

    public SettingsView(Control SettingsPanel)
    {
        this.SettingsPanel = SettingsPanel;
        InitializeComponent();
    }

    private void BeforeCollapse_(object sender, TreeViewCancelEventArgs args)
    {
        args.Cancel = true;
    }

    private void BeforeSelect_(object sender, TreeViewCancelEventArgs args)
    {
        foreach (SettingsNode node in Collect(Nodes))
        {
            if (node.Control.Visible)
            {
                node.Control.Visible = false;
                node.Control.OnHide();
            }
        }
        if (args.Node is SettingsNode current)
        {
            current.Control.Visible = true;
            current.Control.Size = new(SettingsPanel.Width - 10, SettingsPanel.Height);
            current.Control.OnShow();
        }
    }

    public void OnShow()
    {
        if (SelectedNode == null)
        {
            return;
        }
        SettingsNode current = (SettingsNode)SelectedNode;
        current.Control.OnShow();
    }

    public void OnHide()
    {
        if (SelectedNode == null)
        {
            return;
        }
        SettingsNode current = (SettingsNode)SelectedNode;
        current.Control.OnHide();
    }
}