namespace SBRunScr.resources;

public class Resources
{
    static Resources()
    {
        PrintAllResources();
    }

    private static void PrintAllResources()
    {
        foreach (string name in typeof(Resources).Assembly.GetManifestResourceNames())
        {
            Console.WriteLine($"resource:{name}");
        }
    }

    public static Icon GetIcon(string name)
    {
        using Stream stream = GetStream("ico", name) ?? throw new InvalidDataException($"Unknown resoucre {name}");
        return new Icon(stream);
    }

    public static Image GetIconAsImage(string name)
    {
        return GetIcon(name).ToBitmap();
    }

    public static Image GetIconAsImage(string name, Size size)
    {
        return new Bitmap(GetIcon(name).ToBitmap(), size);
    }

    public static string GetSql(string name)
    {
        using Stream stream = GetStream("sql", name) ?? throw new InvalidDataException($"Unknown resoucre {name}");
        using StreamReader reader = new(stream);
        return reader.ReadToEnd();
    }

    public static Stream? GetStream(string type, string name)
    {
        string path = $"{typeof(Resources).Namespace}.{type}.{name}.{type}";
        return typeof(Resources).Assembly.GetManifestResourceStream(path);
    }
}