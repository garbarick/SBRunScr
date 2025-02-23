using System.Reflection;
using SBRunScr.resources;

namespace SBRunScr.form;

partial class MainFrom
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 500);
        Text = "SBRunScr";
        Icon = Resources.GetIcon("main.ico");
        Controls.Add(CreateMainPanel());
        CenterToScreen();
    }

    private Panel CreateMainPanel()
    {
        TableLayoutPanel result = new TableLayoutPanel();
        result.AutoSize = true;
        result.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        result.Dock = DockStyle.Fill;
        result.Controls.Add(createUpdateButton());
        return result;
    }

    private Button createUpdateButton()
    {
        Button result = new Button();
        result.Image = Resources.GetImage("updateWallpaper.ico");
        result.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        result.Size = new Size(80, 40);
        result.Click += new EventHandler(UpdateWallpaper);
        return result;
    }

    #endregion
}
