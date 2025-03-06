namespace SBRunScr.item;

public class FileItem(long id, string path, int type) : Item(id, System.IO.Path.GetFileName(path))
{
    public string Path { get; set; } = path;
    public int Type { get; set; } = type;
}