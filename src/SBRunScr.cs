using System.Reflection;
using SBRunScr.form;

namespace SBRunScr;

static class SBRunScr
{
    internal static Assembly AssemblyResolveHandler(object? sender, ResolveEventArgs args)
    {
        AssemblyName assemblyName = new(args.Name);
        string path = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "libs",
            $"{assemblyName.Name}.dll");
        return Assembly.LoadFrom(path);
    }

    [STAThread]
    static void Main()
    {
        AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolveHandler;
        ApplicationConfiguration.Initialize();
        Application.Run(new MainFrom());
    }
}