using System.Reflection;

namespace SBRunScr.user;

public class User
{
    public string UserFile(string file)
    {
        string appName = AppName();
        string appDataDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            appName);
        Directory.CreateDirectory(appDataDir);
        return Path.Combine(appDataDir, file);
    }

    public string AppName()
    {
        return Assembly.GetExecutingAssembly().GetName().Name ?? "SBRunScr";
    }
}