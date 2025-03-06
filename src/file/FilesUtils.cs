namespace SBRunScr.file;

public class FilesUtils
{
    public static List<string> GetFiles(string path)
    {
        List<string> result = [];
        foreach (string childPath in Directory.GetFiles(path))
        {
            string ext = Path.GetExtension(childPath).ToLower();
            if (ext.StartsWith('.'))
            {
                ext = ext[1..];
                try
                {
                    FileType type = (FileType)Enum.Parse(typeof(FileType), ext);
                    result.Add(childPath);
                }
                catch { }
            }
        }
        foreach (string childPath in Directory.GetDirectories(path))
        {
            result.AddRange(GetFiles(childPath));
        }
        return result;
    }
}
