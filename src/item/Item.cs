namespace SBRunScr.item;

public class Item(long id, string name)
{
    public long Id { get; } = id;

    public string Name { get; set; } = name;
}