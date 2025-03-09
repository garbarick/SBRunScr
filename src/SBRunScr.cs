using System.Reflection;
using SBRunScr.user;
using SBRunScr.tray;

namespace SBRunScr;

public class SBRunScr
{
    [STAThread]
    public static void Main()
    {
        new SBRunScr().Start();
    }

    private void Start()
    {
        Mutex? mutex = CreateMutex();
        if (mutex == null)
        {
            return;
        }
        try
        {
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolveHandler;
            ApplicationConfiguration.Initialize();
            Application.Run(new SBContext());
        }
        finally
        {
            mutex.Close();
        }
    }

    private Assembly AssemblyResolveHandler(object? sender, ResolveEventArgs args)
    {
        AssemblyName assemblyName = new(args.Name);
        string path = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "libs",
            $"{assemblyName.Name}.dll");
        return Assembly.LoadFrom(path);
    }

    private Mutex? CreateMutex()
    {
        bool created;
        Mutex mutex = new(true, new User().AppName(), out created);
        if (!created)
        {
            mutex.Close();
            return null;
        }
        return mutex;
    }
}