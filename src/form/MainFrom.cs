namespace SBRunScr.form;

public partial class MainFrom : Form
{
    public MainFrom()
    {
        InitializeComponent();
    }

    private void UpdateWallpaper(object sender, EventArgs e)
    {
        MessageBox.Show(this, "Update wallpaper", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
