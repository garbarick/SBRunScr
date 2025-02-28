namespace SBRunScr.form;

public partial class InputBox : Form
{
    private string result;

    public InputBox(string title, string message, string text)
    {
        result = text;
        InitializeComponent(title, message, text);
    }

    private void OkClick(object sender, EventArgs e)
    {
        result = textBox.Text;
    }

    public string Result()
    {
        return result;
    }
}