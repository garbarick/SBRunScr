using SBRunScr.db;
using SBRunScr.item;
using SBRunScr.tray;
using SBRunScr.wall;

namespace SBRunScr.form;

public partial class MainFrom : Form
{
    private readonly Settings settings = new();

    public MainFrom()
    {
        InitializeComponent();
    }

    private void UpdateWallpaper(object sender, EventArgs args)
    {
        FileItem? fileItem = settings.GetCurrentFile();
        if (fileItem != null)
        {
            new WallPaper().Set(fileItem.Path);
        }
    }

    private void ShowMenu(object sender, EventArgs args)
    {
        Button button = (Button)sender;
        SBContext.Current?.Menu?.Show(button.PointToScreen(button.Location));
    }

    public void UpdateFilesList()
    {
        SettingsView.UpdateFilesList();
    }
}
