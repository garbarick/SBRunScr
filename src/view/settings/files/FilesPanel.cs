using SBRunScr.view.settings.tree;
using SBRunScr.db;
using SBRunScr.form;
using SBRunScr.item;

namespace SBRunScr.view.settings.files;

public partial class FilesPanel : SettingsPanel
{
    private readonly DataBase dataBase = new();

    public FilesPanel()
    {
        InitializeComponent();
        UpdateLists();
        SelectListByIndex(0);
    }

    private void AddList(object sender, EventArgs args)
    {
        InputBox dialog = new("New list", "Name", "");
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            string name = dialog.Result();
            long id = dataBase.AddList(name);
            if (id > 0)
            {
                ListItem item = new ListItem(id, name, 0);
                ListItemView itemView = new(item);
                Lists.Items.Add(itemView);
                SelectListByIndex(Lists.Items.Count - 1);
            }
        }
    }

    private void EditList(object sender, EventArgs args)
    {
        if (Lists.SelectedIndices.Count > 0)
        {
            int index = Lists.SelectedIndices[0];
            ListItemView item = (ListItemView)Lists.Items[index];
            InputBox dialog = new("Edit list", "Name", item.Item.Name);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string name = dialog.Result();
                if (dataBase.RenameList(item.Item.Id, name))
                {
                    item.Item.Name = name;
                    item.Update();
                }
            }
        }
    }

    private void DeleteList(object sender, EventArgs args)
    {
        if (Lists.SelectedIndices.Count > 0)
        {
            int index = Lists.SelectedIndices[0];
            ListItemView item = (ListItemView)Lists.Items[index];
            if (MessageBox.Show($"Delete '{item.Item.Name}'", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (dataBase.DeleteList(item.Item.Id))
                {
                    Lists.Items.RemoveAt(index);
                    index = index == Lists.Items.Count ? index - 1 : 0;
                    SelectListByIndex(index);
                }
            }
        }
    }

    private void AddFolder(object sender, EventArgs args)
    {
        Console.WriteLine("AddFolder");
    }

    private void ExcludeFolder(object sender, EventArgs args)
    {
        Console.WriteLine("ExcludeFolder");
    }

    private void ClearFiles(object sender, EventArgs args)
    {
        Console.WriteLine("ClearFiles");
    }

    private void UpdateLists()
    {
        Lists.Items.Clear();
        foreach (ListItem item in dataBase.GetLists())
        {
            ListItemView itemView = new(item);
            Lists.Items.Add(itemView);
        }
    }

    private void SelectListByIndex(int index)
    {
        Lists.SelectedIndices.Clear();
        if (index > -1 && index < Lists.Items.Count)
        {
            ListItemView item = (ListItemView)Lists.Items[index];
            item.Selected = true;
            Lists.EnsureVisible(index);
        }
    }

    private void ListsSelectedChanged(object sender, EventArgs args)
    {
        if (Lists.SelectedIndices.Count > 0)
        {
            int index = Lists.SelectedIndices[0];
            Console.WriteLine($"selected index: {index}");
        }
    }
}