using SBRunScr.item;

namespace SBRunScr.view.settings.files;

public class ListItemView : ListViewItem
{
    public ListItem Item { get; }

    public ListItemView(ListItem item)
    {
        Item = item;
        Update();
    }

    public void Update()
    {
        Text = Item.Name;
        SubItems.Add(Item.Count.ToString());
    }
}