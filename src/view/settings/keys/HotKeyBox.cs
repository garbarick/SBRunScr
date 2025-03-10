namespace SBRunScr.view.settings.keys;

public class HotKeyBox : TextBox
{
    private static readonly string UNDEFINED = Keys.None.ToString();
    private static readonly Keys[] IGNORE_KEYS = [Keys.None, Keys.LWin, Keys.RWin, Keys.ShiftKey, Keys.Menu, Keys.ControlKey];
    private static readonly Keys[] MODIFS = [Keys.Alt, Keys.Shift, Keys.Control];
    public Keys hotkey = Keys.None;
    public Keys modifiers = Keys.None;

    public HotKeyBox()
    {
        ShortcutsEnabled = false;
        Text = UNDEFINED;
        KeyPress += new KeyPressEventHandler(KeyPressHandle);
        KeyDown += new KeyEventHandler(KeyDownHandle);
        KeyUp += new KeyEventHandler(KeyUpHandle);
    }

    public Keys GetHotKey()
    {
        return hotkey;
    }

    public void SetHotKey(Keys hotkey)
    {
        this.hotkey = hotkey;
    }

    public Keys GetModifiers()
    {
        return modifiers;
    }

    public void SetModifiers(Keys modifiers)
    {
        this.modifiers = modifiers;
    }

    private void KeyPressHandle(object? sender, KeyPressEventArgs args)
    {
        args.Handled = true;
    }

    private void KeyUpHandle(object? sender, KeyEventArgs args)
    {
        if (hotkey == Keys.None && ModifierKeys == Keys.None)
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
            modifiers = args.Modifiers;
            hotkey = args.KeyCode;
            Redraw();
        }
    }

    private void ResetHotkey()
    {
        hotkey = Keys.None;
        modifiers = Keys.None;
        Redraw();
    }

    private void Redraw()
    {
        if (IGNORE_KEYS.Contains(hotkey))
        {
            hotkey = Keys.None;
            Text = UNDEFINED;
            return;
        }
        Text = "";
        foreach (Keys key in MODIFS)
        {
            if (modifiers.HasFlag(key))
            {
                Text += key + " + ";
            }
        }
        Text += hotkey;
    }
}