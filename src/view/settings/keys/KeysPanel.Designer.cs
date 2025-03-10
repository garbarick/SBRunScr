using System.Drawing.Text;

namespace SBRunScr.view.settings.keys;

partial class KeysPanel
{
    private void InitializeComponent()
    {
        Text = "Keys";
        Dock = DockStyle.Fill;

        Controls.Add(CreateMainLayout());
    }

    private Control CreateMainLayout()
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
        result.Controls.AddRange(CreateHotKeyRow("Previous"));
        result.Controls.AddRange(CreateHotKeyRow("Next"));
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

        HotKeyBox text = new();
        text.Dock = DockStyle.Fill;

        return new Control[] { title, win, text };
    }
}