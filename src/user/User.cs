using System.Reflection;

namespace SBRunScr.user;

public class User
{
    public string UserFile()
    {
        string appName = Assembly.GetExecutingAssembly().GetName().Name ?? "SBRunScr";
        string appDataDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            appName);
        Directory.CreateDirectory(appDataDir);
        return Path.Combine(appDataDir, "settings.db");
    }
}