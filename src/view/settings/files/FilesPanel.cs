using SBRunScr.view.settings.tree;

namespace SBRunScr.view.settings.files;

public partial class FilesPanel : SettingsPanel
{
    public FilesPanel()
    {
        InitializeComponent();
    }

    private void AddList(object sender, EventArgs e)
    {
        Console.WriteLine("AddList");
    }

    private void EditList(object sender, EventArgs e)
    {
        Console.WriteLine("EditList");
    }

    private void DeleteList(object sender, EventArgs e)
    {
        Console.WriteLine("DeleteList");
    }
}