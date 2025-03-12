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
        for (int i = 0; i < mainPanel.Controls.Count; i +=3)
        {
            Label label = (Label) mainPanel.Controls[i];
            CheckBox win = (CheckBox) mainPanel.Controls[i + 1];
            HotKeyBox hotKeyBox = (HotKeyBox) mainPanel.Controls[i + 2];
            HotKey hotKey = settings.GetHotKey(label.Text);
            win.Checked = hotKey.Win;
            hotKeyBox.Hotkey = hotKey;
            hotKeyBox.Redraw();
        }
    }

    public override void OnHide()
    {
        for (int i = 0; i < mainPanel.Controls.Count; i +=3)
        {
            Label label = (Label) mainPanel.Controls[i];
            CheckBox win = (CheckBox) mainPanel.Controls[i + 1];
            HotKeyBox hotKeyBox = (HotKeyBox) mainPanel.Controls[i + 2];
            HotKey hotKey = hotKeyBox.Hotkey;
            hotKey.Win = win.Checked;
            settings.SetHotKey(label.Text, hotKey);
        }
        SBContext.Current?.RegisterHotKeys();
    }
}