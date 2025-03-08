using SBRunScr.db;
using SBRunScr.wall;

namespace SBRunScr.form;

public partial class MainFrom : Form
{
    private readonly DataBase dataBase = new();

    public MainFrom()
    {
        InitializeComponent();
    }

    private void UpdateWallpaper(object sender, EventArgs e)
    {
        string? filePath = dataBase.GetCurrentFile();
        if (filePath != null)
        {
            new WallPaper().Set(filePath);
        }
    }
}
