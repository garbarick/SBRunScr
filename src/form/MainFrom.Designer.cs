using System.Reflection;
using SBRunScr.resources;
using SBRunScr.view.settings;
using SBRunScr.view.settings.tree;

namespace SBRunScr.form;

partial class MainFrom
{
    private System.ComponentModel.IContainer Components;
    private Control SettingsPanel;
    private SplitContainer MainSplitter;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (Components != null))
        {
            Components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        Components = new System.ComponentModel.Container();
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = MinimumSize = new Size(800, 500);
        Text = "SBRunScr";
        Icon = Resources.GetIcon("main");

        SettingsPanel = CreateSettingsPanel();
        MainSplitter = CreateMainSpliter();

        Controls.Add(MainSplitter);

        Shown += new EventHandler(OnShow);
        CenterToScreen();
    }

    private void OnShow(object sender, EventArgs e)
    {
        MainSplitter.SplitterDistance = 160;
    }

    private SplitContainer CreateMainSpliter()
    {
        SplitContainer result = new();
        result.FixedPanel = FixedPanel.Panel1;
        result.Dock = DockStyle.Fill;
        result.Panel1.Controls.Add(new SettingsView(SettingsPanel));
        result.Panel1MinSize = 160;
        result.Panel2.Controls.Add(CreateRightPanel());
        result.SplitterDistance = 400;
        return result;
    }

    private Control CreateSettingsPanel()
    {
        Panel result = new();
        result.Dock = DockStyle.Fill;
        result.Padding = new Padding(2, 0, 4, 0);
        return result;
    }

    private Control CreateRightPanel()
    {
        TableLayoutPanel result = new();
        result.Dock = DockStyle.Fill;
        result.ColumnCount = 1;
        result.RowCount = 2;
        result.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        result.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
        result.Controls.Add(SettingsPanel);
        result.Controls.Add(CreateButtonsPanel());
        return result;
    }

    private Control CreateButtonsPanel()
    {
        Panel result = new();
        result.Dock = DockStyle.Fill;
        result.Controls.Add(CreateUpdateButton());
        return result;
    }

    private Control CreateUpdateButton()
    {
        Button result = new();
        result.Image = Resources.GetIconAsImage("updateWallpaper");
        result.Dock = DockStyle.Left;
        result.Click += new EventHandler(UpdateWallpaper);
        return result;
    }

    #endregion
}
