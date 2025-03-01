using SBRunScr.view.settings.tree;
using SBRunScr.db;
using SBRunScr.form;

namespace SBRunScr.view.settings.files;

public partial class FilesPanel : SettingsPanel
{
    private readonly DataBase dataBase = new();

    public FilesPanel()
    {
        InitializeComponent();
    }

    private void AddList(object sender, EventArgs e)
    {
        InputBox dialog = new("New list", "Name", "");
        if (dialog.ShowDialog() == DialogResult.OK && dataBase.AddList(dialog.Result()))
        {
            Console.WriteLine($"added {dialog.Result()}");
        }
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