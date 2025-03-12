namespace SBRunScr.item;

public class HotKey
{
    public Keys Key { get; set; }
    public Keys Modifiers { get; set; }
    public bool Win { get; set; }

    public HotKey()
    {
        Clean();
    }
    public HotKey(string source)
    {
        Clean();
        Parse(source);
    }

    private void Clean()
    {
        Key = Keys.None;
        Modifiers = Keys.None;
        Win = false;
    }

    public override string ToString()
    {
        if (Key == Keys.None)
        {
            return string.Empty;
        }
        return Win + ", " + Modifiers + ", " + Key;
    }

    private void Parse(string source)
    {
        string[] values = source.Split(", ");
        if (values.Length < 2)
        {
            return;
        }
        int first = 0;
        int last = values.Length - 1;
        Win = Convert.ToBoolean(values[first]);
        if (Enum.TryParse(values[last], false, out Keys hotKeyResult))
        {
            Key = hotKeyResult;
        }
        first++;
        for (int i = first; i < last; i++)
        {
            if (Enum.TryParse(values[i], false, out Keys modifierResult))
            {
                Modifiers |= modifierResult;
            }
        }
    }
}