using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using SBRunScr.user;

namespace SBRunScr.wall;

public class WallPaper
{
    private const int SPI_SETDESKWALLPAPER = 20;
    private const int SPIF_UPDATEINIFILE = 0x01;
    private const int SPIF_SENDWININICHANGE = 0x02;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

    public void Set(string filePath)
    {
        string wallPath = Create(filePath);
        SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, wallPath, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
    }

    protected string Create(string filePath)
    {
        int width = SystemInformation.VirtualScreen.Width;
        int heigth = SystemInformation.VirtualScreen.Height;

        Image image = Image.FromFile(filePath);
        Image wallImage = new Bitmap(width, heigth);
        Graphics graphic = Graphics.FromImage(wallImage);

        graphic.Clear(Color.Black);
        graphic.DrawImage(image, 0, 0, width, heigth);

        string result = new User().UserFile("wallpaper.bmp");
        wallImage.Save(result, ImageFormat.Bmp);
        return result;
    }
}