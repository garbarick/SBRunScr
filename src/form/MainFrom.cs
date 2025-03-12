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
        MouseEventArgs mouseEvent = (MouseEventArgs)args;
        SBContext.Current?.Menu?.Show(button.PointToScreen(mouseEvent.Location));
    }

    public void OnShow()
    {
        SettingsView.OnShow();
    }

    private void OnResizeHandler(object sender, EventArgs args)
    {
        if (WindowState == FormWindowState.Minimized)
        {
            SettingsView.OnHide();
            Close();
        }
    }

    private void OnClose(object sender, EventArgs e)
    {
        SettingsView.OnHide();
    }
}
