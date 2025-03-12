using SBRunScr.item;
using System.ComponentModel;

namespace SBRunScr.view.settings.keys;

public class HotKeyBox : TextBox
{
    private static readonly string UNDEFINED = Keys.None.ToString();
    private static readonly Keys[] IGNORE_KEYS = [Keys.None, Keys.LWin, Keys.RWin, Keys.ShiftKey, Keys.Menu, Keys.ControlKey];
    private static readonly Keys[] MODIFS = [Keys.Alt, Keys.Shift, Keys.Control];

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public HotKey Hotkey { get; set; } = new HotKey();

    public HotKeyBox()
    {
        ShortcutsEnabled = false;
        Text = UNDEFINED;
        KeyPress += new KeyPressEventHandler(KeyPressHandle);
        KeyDown += new KeyEventHandler(KeyDownHandle);
        KeyUp += new KeyEventHandler(KeyUpHandle);
    }

    private void KeyPressHandle(object? sender, KeyPressEventArgs args)
    {
        args.Handled = true;
    }

    private void KeyUpHandle(object? sender, KeyEventArgs args)
    {
        if (Hotkey.Key == Keys.None && ModifierKeys == Keys.None)
        {
            ResetHotkey();
            return;
        }
    }

    private void KeyDownHandle(object? sender, KeyEventArgs args)
    {
        if (args.KeyCode == Keys.Delete)
        {
            ResetHotkey();
            return;
        }
        else
        {
            Hotkey.Key = args.KeyCode;
            Hotkey.Modifiers = args.Modifiers;
            Redraw();
        }
    }

    private void ResetHotkey()
    {
        Hotkey.Key = Keys.None;
        Hotkey.Modifiers = Keys.None;
        Redraw();
    }

    public void Redraw()
    {
        if (IGNORE_KEYS.Contains(Hotkey.Key))
        {
            Hotkey.Key = Keys.None;
        }
        Text = string.Empty;
        foreach (Keys key in MODIFS)
        {
            if (Hotkey.Modifiers.HasFlag(key))
            {
                Text += key + " + ";
            }
        }
        if (Hotkey.Key != Keys.None)
        {
            Text += Hotkey.Key;
        }
        if (string.IsNullOrEmpty(Text))
        {
            Text = UNDEFINED;
        }
    }
}