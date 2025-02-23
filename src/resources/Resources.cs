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

    public static Icon? GetIcon(string name)
    {
        Stream stream = GetStream(name)?? throw new InvalidDataException($"Unknown resoucre {name}");
        return new Icon(stream);
    }

    public static Image? GetImage(string name)
    {
        return GetIcon(name)?.ToBitmap();
    }

    public static Stream? GetStream(string name)
    {
        string path = $"{typeof(Resources).Namespace}.{name}";
        return typeof(Resources).Assembly.GetManifestResourceStream(path);
    }
}