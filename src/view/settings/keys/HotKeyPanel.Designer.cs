using SBRunScr.item;
using System.ComponentModel;

namespace SBRunScr.view.settings.keys;

partial class HotKeyPanel
{
    public Label Label = new();
    private CheckBox WinKey = new();
    private TextBox KeysBox = new();

    private void InitializeComponent()
    {
        Dock = DockStyle.Fill;
        ColumnCount = 3;
        RowCount = 1;
        ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));
        ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
        ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        Label.Dock = DockStyle.Fill;

        WinKey.Text = "Win +";
        WinKey.Dock = DockStyle.Right;
        WinKey.CheckedChanged += new EventHandler(CheckedChangedHandle);

        KeysBox.Dock = DockStyle.Fill;
        KeysBox.ShortcutsEnabled = false;
        KeysBox.Text = UNDEFINED;
        KeysBox.KeyPress += new KeyPressEventHandler(KeysBoxPressHandle);
        KeysBox.KeyDown += new KeyEventHandler(KeysBoxDownHandle);
        KeysBox.KeyUp += new KeyEventHandler(KeysBoxUpHandle);

        Controls.Add(Label);
        Controls.Add(WinKey);
        Controls.Add(KeysBox);
    }
}