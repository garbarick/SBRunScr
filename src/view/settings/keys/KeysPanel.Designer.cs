using System.Drawing.Text;
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
        result.ColumnCount = 3;
        result.RowCount = 3;
        result.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));
        result.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
        result.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        result.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
        result.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
        result.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        result.Controls.AddRange(CreateHotKeyRow(Constants.Previous));
        result.Controls.AddRange(CreateHotKeyRow(Constants.Next));
        return result;
    }

    private Control[] CreateHotKeyRow(string name)
    {
        Label title = new();
        title.Text = name;
        title.Dock = DockStyle.Fill;

        CheckBox win = new();
        win.Text = "Win +";
        win.Dock = DockStyle.Right;

        HotKeyBox hotKeyBox = new();
        hotKeyBox.Dock = DockStyle.Fill;

        return new Control[] { title, win, hotKeyBox };
    }
}