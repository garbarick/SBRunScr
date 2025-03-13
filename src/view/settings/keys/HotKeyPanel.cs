using SBRunScr.item;
using System.ComponentModel;

namespace SBRunScr.view.settings.keys;

public partial class HotKeyPanel : TableLayoutPanel
{
    private static readonly string UNDEFINED = Keys.None.ToString();
    private static readonly Keys[] IGNORE_KEYS = [Keys.None, Keys.LWin, Keys.RWin, Keys.ShiftKey, Keys.Menu, Keys.ControlKey];
    private static readonly Keys[] MODIFS = [Keys.Alt, Keys.Shift, Keys.Control];
    private HotKey hotkey = new();
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public HotKey HotKey
    {
        get
        {
            return hotkey;
        }
        set
        {
            hotkey = value;
            WinKey.Checked = hotkey.Win;
        }
    }

    public HotKeyPanel(string name)
    {
        InitializeComponent();
        Label.Text = name;
    }

    private void CheckedChangedHandle(object sender, EventArgs args)
    {
        hotkey.Win = WinKey.Checked;
    }

    private void KeysBoxPressHandle(object? sender, KeyPressEventArgs args)
    {
        args.Handled = true;
    }

    private void KeysBoxUpHandle(object? sender, KeyEventArgs args)
    {
        if (hotkey.Key == Keys.None && ModifierKeys == Keys.None)
        {
            ResetKeys();
            return;
        }
    }

    private void KeysBoxDownHandle(object? sender, KeyEventArgs args)
    {
        if (args.KeyCode == Keys.Delete)
        {
            ResetKeys();
            return;
        }
        else
        {
            hotkey.Key = args.KeyCode;
            hotkey.Modifiers = args.Modifiers;
            Redraw();
        }
    }

    private void ResetKeys()
    {
        hotkey.Key = Keys.None;
        hotkey.Modifiers = Keys.None;
        Redraw();
    }

    public void Redraw()
    {
        if (IGNORE_KEYS.Contains(hotkey.Key))
        {
            hotkey.Key = Keys.None;
        }
        KeysBox.Text = string.Empty;
        foreach (Keys key in MODIFS)
        {
            if (hotkey.Modifiers.HasFlag(key))
            {
                KeysBox.Text += key + " + ";
            }
        }
        if (hotkey.Key != Keys.None)
        {
            KeysBox.Text += hotkey.Key;
        }
        if (string.IsNullOrEmpty(KeysBox.Text))
        {
            KeysBox.Text = UNDEFINED;
        }
    }
}