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
    private SettingsView SettingsView;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (Components != null))
        {
            Components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        Components = new System.ComponentModel.Container();
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = MinimumSize = new Size(800, 500);
        Text = "SBRunScr";
        Icon = Resources.GetIcon("main");
        Resize += new EventHandler(OnResizeHandler);

        SettingsPanel = CreateSettingsPanel();
        MainSplitter = CreateMainSpliter();

        Controls.Add(MainSplitter);

        Shown += new EventHandler(OnShow);
        FormClosing += new FormClosingEventHandler(OnClose);
        CenterToScreen();
    }

    private void OnShow(object sender, EventArgs args)
    {
        MainSplitter.SplitterDistance = 160;
    }

    private SplitContainer CreateMainSpliter()
    {
        SplitContainer result = new();
        result.FixedPanel = FixedPanel.Panel1;
        result.Dock = DockStyle.Fill;
        result.Panel1.Controls.Add(CreateLeftPanel());
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

    private Control CreateLeftPanel()
    {
        TableLayoutPanel result = new();
        result.Dock = DockStyle.Fill;
        result.ColumnCount = 1;
        result.RowCount = 2;
        result.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        result.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
        result.Controls.Add(SettingsView = new SettingsView(SettingsPanel));
        result.Controls.Add(CreateMenuButton());
        return result;
    }

    private Control CreateRightPanel()
    {
        TableLayoutPanel result = new();
        result.Dock = DockStyle.Fill;
        result.ColumnCount = 1;
        result.RowCount = 2;
        result.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        result.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
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
        result.Image = Resources.GetIconAsImage("updateWallpaper", new Size(48, 26));
        result.Dock = DockStyle.Left;
        result.Click += new EventHandler(UpdateWallpaper);
        return result;
    }

    private Control CreateMenuButton()
    {
        Button result = new();
        result.Text = "Menu";
        result.Dock = DockStyle.Fill;
        result.Click += new EventHandler(ShowMenu);
        return result;
    }
}
