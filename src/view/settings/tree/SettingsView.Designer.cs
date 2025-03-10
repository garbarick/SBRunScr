using SBRunScr.view.settings.files;
using SBRunScr.view.settings.general;
using SBRunScr.view.settings.keys;

namespace SBRunScr.view.settings.tree;

partial class SettingsView
{
    private void InitializeComponent()
    {
        Dock = DockStyle.Fill;
        HideSelection = false;
        FullRowSelect = true;
        ShowLines = false;

        InitNodes();
        ExpandAll();

        BeforeCollapse += new TreeViewCancelEventHandler(BeforeCollapse_);
        BeforeSelect += new TreeViewCancelEventHandler(BeforeSelect_);
    }

    private void InitNodes()
    {
        Nodes.Add(new SettingsNode(new GeneralPanel()));
        Nodes[0].Nodes.Add(new SettingsNode(new FilesPanel()));
        Nodes[0].Nodes.Add(new SettingsNode(new KeysPanel()));
        foreach (SettingsNode node in Collect(Nodes))
        {
            SettingsPanel.Controls.Add(node.Control);
        }
    }

    private IEnumerable<SettingsNode> Collect(TreeNodeCollection nodes)
    {
        foreach (TreeNode node in nodes)
        {
            yield return (SettingsNode)node;
            foreach (var child in Collect(node.Nodes))
            {
                yield return child;
            }
        }
    }
}