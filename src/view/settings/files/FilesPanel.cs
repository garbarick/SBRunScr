using SBRunScr.view.settings.tree;
using SBRunScr.db;
using SBRunScr.form;
using SBRunScr.item;

namespace SBRunScr.view.settings.files;

public partial class FilesPanel : SettingsPanel
{
    private readonly DataBase dataBase = new();
    private readonly Settings settings = new();

    public FilesPanel()
    {
        InitializeComponent();
        UpdateLists();
    }

    public override void OnShow()
    {
        long listId = settings.GetLastList();
        SelectListById(listId);
        SelectFileById(settings.GetLastFile(listId));

        if (Lists.SelectedIndices.Count > 0)
        {
            Lists.EnsureVisible(Lists.SelectedIndices[0]);
        }
        if (Files.SelectedIndices.Count > 0)
        {
            Files.EnsureVisible(Files.SelectedIndices[0]);
        }
    }

    private void AddList(object sender, EventArgs args)
    {
        InputBox dialog = new("New list", "Name", string.Empty);
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            string name = dialog.Result();
            long id = dataBase.AddList(name);
            if (id > 0)
            {
                UpdateLists();
                SelectListById(id);
            }
        }
    }

    private void EditList(object sender, EventArgs args)
    {
        if (Lists.SelectedIndices.Count == 0)
        {
            return;
        }
        ListItemView list = (ListItemView)Lists.Items[Lists.SelectedIndices[0]];
        InputBox dialog = new("Edit list", "Name", list.Item.Name);
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            string name = dialog.Result();
            if (dataBase.RenameList(list.Item.Id, name))
            {
                list.Item.Name = name;
                list.Update();
            }
        }
    }

    private void DeleteList(object sender, EventArgs args)
    {
        if (Lists.SelectedIndices.Count == 0)
        {
            return;
        }
        int index = Lists.SelectedIndices[0];
        ListItemView list = (ListItemView)Lists.Items[index];
        if (MessageBox.Show($"Delete '{list.Item.Name}'", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
        {
            if (dataBase.DeleteList(list.Item.Id))
            {
                Lists.Items.RemoveAt(index);
                index = index == Lists.Items.Count ? index - 1 : index;
                SelectListByIndex(index);
            }
        }
    }

    private void AddFolder(object sender, EventArgs args)
    {
        if (Lists.SelectedIndices.Count == 0)
        {
            return;
        }
        ListItemView list = (ListItemView)Lists.Items[Lists.SelectedIndices[0]];
        FolderBrowserDialog dialog = new();
        if (dialog.ShowDialog() == DialogResult.OK &&
            dataBase.AddFolder(dialog.SelectedPath, list.Item.Id))
        {
            UpdateFiles(list);
            UpdateListCount(list);
        }
    }

    private void ExcludeFolder(object sender, EventArgs args)
    {
        if (Lists.SelectedIndices.Count == 0)
        {
            return;
        }
        ListItemView list = (ListItemView)Lists.Items[Lists.SelectedIndices[0]];
        FolderBrowserDialog dialog = new();
        if (dialog.ShowDialog() == DialogResult.OK &&
            dataBase.ExcludeFolder(dialog.SelectedPath, list.Item.Id))
        {
            UpdateFiles(list);
            UpdateListCount(list);
        }
    }

    private void ClearFiles(object sender, EventArgs args)
    {
        if (Lists.SelectedIndices.Count == 0)
        {
            return;
        }
        ListItemView list = (ListItemView)Lists.Items[Lists.SelectedIndices[0]];
        if (dataBase.ClearFiles(list.Item.Id))
        {
            Files.Items.Clear();
            UpdateListCount(list);
        }
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

    private void SelectListById(long id)
    {
        if (id == 0 || Lists.Items.Count == 0)
        {
            return;
        }
        if (Lists.SelectedIndices.Count > 0)
        {
            ListItemView list = (ListItemView)Lists.Items[Lists.SelectedIndices[0]];
            if (id == list.Item.Id)
            {
                return;
            }
        }
        for (int i = 0; i < Lists.Items.Count; i++)
        {
            ListItemView item = (ListItemView)Lists.Items[i];
            if (id == item.Item.Id)
            {
                SelectListByIndex(i);
                break;
            }
        }
    }

    private void ListsSelectedChanged(object sender, EventArgs args)
    {
        Files.Items.Clear();
        FilesButtons.Enabled = false;
        if (Lists.SelectedIndices.Count == 0)
        {
            return;
        }
        ListItemView list = (ListItemView)Lists.Items[Lists.SelectedIndices[0]];
        settings.SetLastList(list.Item.Id);
        UpdateFiles(list);
        UpdateListCount(list);
        FilesButtons.Enabled = true;
    }

    private void UpdateFiles(ListItemView list)
    {
        Files.Items.Clear();
        long lastFileId = settings.GetLastFile(list.Item.Id);
        int index = 0;
        foreach (FileItem item in dataBase.GetFiles(list.Item.Id))
        {
            FileItemView itemView = new(item);
            Files.Items.Add(itemView);
            if (lastFileId == item.Id)
            {
                itemView.Selected = true;
                Files.EnsureVisible(index);
            }
            index++;
        }
    }

    private void UpdateListCount(ListItemView list)
    {
        list.Item.Count = Files.Items.Count;
        list.Update();
    }

    private void FilesSelectedChanged(object sender, EventArgs args)
    {
        if (Lists.SelectedIndices.Count == 0 || Files.SelectedIndices.Count == 0)
        {
            return;
        }
        ListItemView list = (ListItemView)Lists.Items[Lists.SelectedIndices[0]];
        FileItemView item = (FileItemView)Files.Items[Files.SelectedIndices[0]];
        PreviewImage.Image = Image.FromFile(item.Item.Path);
        settings.SetLastFile(list.Item.Id, item.Item.Id);
    }

    private void SelectFileById(long fileId)
    {
        if (fileId == 0)
        {
            return;
        }
        if (Files.SelectedIndices.Count > 0)
        {
            FileItemView item = (FileItemView)Files.Items[Files.SelectedIndices[0]];
            if (fileId == item.Item.Id)
            {
                return;
            }
        }
        Files.SelectedIndices.Clear();
        for (int i = 0; i < Files.Items.Count; i++)
        {
            FileItemView item = (FileItemView)Files.Items[i];
            if (fileId == item.Item.Id)
            {
                item.Selected = true;
                Files.EnsureVisible(i);
                break;
            }
        }
    }

    private void ExcludeFile(object sender, EventArgs args)
    {
        if (Lists.SelectedIndices.Count == 0 || Files.SelectedIndices.Count == 0)
        {
            return;
        }
        int index = Files.SelectedIndices[0];
        FileItemView item = (FileItemView)Files.Items[index];

        dataBase.ExcludeFile(item.Item.Id);
        Files.Items.RemoveAt(index);

        index = index == Files.Items.Count ? index - 1 : index;
        item = (FileItemView)Files.Items[index];
        item.Selected = true;
        Files.EnsureVisible(index);

        ListItemView list = (ListItemView)Lists.Items[Lists.SelectedIndices[0]];
        UpdateListCount(list);
    }
}