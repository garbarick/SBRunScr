using SBRunScr.db;
using SBRunScr.item;
using SBRunScr.tray;
using SBRunScr.view.settings.tree;

namespace SBRunScr.view.settings.keys;

public partial class KeysPanel : SettingsPanel
{
    private readonly Settings settings = new();

    public KeysPanel()
    {
        InitializeComponent();
    }

    public override void OnShow()
    {
        SBContext.Current?.UnRegisterHotKeys();
        for (int i = 0; i < mainPanel.Controls.Count; i++)
        {
            HotKeyPanel control = (HotKeyPanel)mainPanel.Controls[i];
            control.HotKey = settings.GetHotKey(control.Label.Text);
            control.Redraw();
        }
    }

    public override void OnHide()
    {
        for (int i = 0; i < mainPanel.Controls.Count; i++)
        {
            HotKeyPanel control = (HotKeyPanel)mainPanel.Controls[i];
            HotKey hotKey = control.HotKey;
            settings.SetHotKey(control.Label.Text, hotKey);
        }
        SBContext.Current?.RegisterHotKeys();
    }
}