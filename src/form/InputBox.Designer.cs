using System.Windows.Forms;

namespace SBRunScr.form;

partial class InputBox
{
    private TextBox textBox;

    private void InitializeComponent(string title, string message, string text)
    {
        Text = title;
        ClientSize = new Size(500, 140);
        MaximizeBox = false;
        MinimizeBox = false;
        FormBorderStyle = FormBorderStyle.FixedDialog;

        TableLayoutPanel panel = createPanel();

        Label label = createLabel(message);
        panel.Controls.Add(label, 0, 0);
        panel.SetColumnSpan(label, 4);

        textBox = createText(text);
        panel.Controls.Add(textBox, 0, 1);
        panel.SetColumnSpan(textBox, 4);

        Button ok = createOk();
        AcceptButton = ok;
        Button cancel = createCancel();
        CancelButton = cancel;

        panel.Controls.Add(ok, 1, 2);
        panel.Controls.Add(cancel, 2, 2);

        Controls.Add(panel);
        CenterToScreen();
    }

    private TableLayoutPanel createPanel()
    {
        TableLayoutPanel result = new();
        result.Dock = DockStyle.Fill;
        result.ColumnCount = 4;
        result.RowCount = 3;
        result.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
        result.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
        result.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
        result.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
        result.RowStyles.Add(new RowStyle(SizeType.Percent, 30));
        result.RowStyles.Add(new RowStyle(SizeType.Percent, 30));
        result.RowStyles.Add(new RowStyle(SizeType.Percent, 40));
        return result;
    }

    private Label createLabel(string message)
    {
        Label result = new();
        result.Text = message;
        result.TextAlign = ContentAlignment.MiddleCenter;
        result.Dock = DockStyle.Fill;
        return result;
    }

    private TextBox createText(string text)
    {
        TextBox result = new();
        result.Text = text;
        result.Dock = DockStyle.Fill;
        return result;
    }

    private Button createOk()
    {
        Button result = new();
        result.Text = "OK";
        result.Dock = DockStyle.Fill;
        result.DialogResult = DialogResult.OK;
        result.Click += new EventHandler(OkClick);
        return result;
    }

    private Button createCancel()
    {
        Button result = new();
        result.Text = "Cancel";
        result.Dock = DockStyle.Fill;
        result.DialogResult = DialogResult.Cancel;
        return result;
    }
}