using SBRunScr.item;

namespace SBRunScr.db;

public class Settings
{
    private readonly DataBase dataBase = new();

    public long GetLastList()
    {
        return dataBase.GetLongValue(Constants.LastList, 0);
    }

    public void SetLastList(long id)
    {
        dataBase.SetLongValue(Constants.LastList, id);
    }

    public long GetLastFile(long listId)
    {
        return dataBase.GetLongValue(listId + "." + Constants.LastFile, 0);
    }

    public void SetLastFile(long listId, long fileId)
    {
        dataBase.SetLongValue(listId + "." + Constants.LastFile, fileId);
    }

    public FileItem? GetCurrentFile()
    {
        return dataBase.GetCurrentFile(Constants.LastList, Constants.LastFile);
    }

    public void SetLastFile(long fileId)
    {
        if (fileId == 0)
        {
            return;
        }
        long listId = GetLastList();
        if (listId == 0)
        {
            return;
        }
        SetLastFile(listId, fileId);
    }

    public void SetNextFile()
    {
        SetLastFile(dataBase.GetNextFileId(Constants.LastList, Constants.LastFile));
    }

    public void SetPreviousFile()
    {
        SetLastFile(dataBase.GetPreviousFileId(Constants.LastList, Constants.LastFile));
    }

    public void SetHotKey(string name, HotKey hotKey)
    {
        dataBase.SetStringValue(name + "." + Constants.HotKey, hotKey.ToString());
    }

    public HotKey GetHotKey(string name)
    {
        return new HotKey(dataBase.GetStringValue(name + "." + Constants.HotKey, string.Empty));
    }
}