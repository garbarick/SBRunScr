namespace SBRunScr.item;

public class ListItem(long id, string name, long count) : Item(id, name)
{
    public long Count { get; set; } = count;
}