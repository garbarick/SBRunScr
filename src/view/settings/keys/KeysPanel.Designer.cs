using SBRunScr.item;

namespace SBRunScr.view.settings.keys;

partial class KeysPanel
{
    private TableLayoutPanel mainPanel;

    private void InitializeComponent()
    {
        Text = "Keys";
        Dock = DockStyle.Fill;
        Controls.Add(mainPanel = CreateMainLayout());
    }

    private TableLayoutPanel CreateMainLayout()
    {
        TableLayoutPanel result = new();
        result.Dock = DockStyle.Fill;
        result.ColumnCount = 1;
        result.RowCount = 3;
        result.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        result.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
        result.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
        result.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        result.Controls.Add(new HotKeyPanel(Constants.Previous));
        result.Controls.Add(new HotKeyPanel(Constants.Next));
        return result;
    }
}