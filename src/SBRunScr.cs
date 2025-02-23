using SBRunScr.form;

namespace SBRunScr;

static class SBRunScr
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainFrom());
    }
}