using SBRunScr.item;

namespace SBRunScr.view.settings.files;

public class FileItemView : ListViewItem
{
    public FileItem Item { get; }

    public FileItemView(FileItem item)
    {
        Item = item;
        Update();
    }

    public void Update()
    {
        SubItems.Clear();
        Text = Item.Path;
        SubItems.Add(Item.Type.ToString());
        SubItems.Add(Item.Name);
    }
}