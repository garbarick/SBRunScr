using SBRunScr.item;

namespace SBRunScr.db;

public class Settings
{
    private readonly DataBase dataBase = new();

    public long GetLastList()
    {
        return dataBase.GetLongValue("lastList", 0);
    }

    public void SetLastList(long id)
    {
        dataBase.SetLongValue("lastList", id);
    }

    public long GetLastFile(long listId)
    {
        return dataBase.GetLongValue(listId + ".lastFile", 0);
    }

    public void SetLastFile(long listId, long fileId)
    {
        dataBase.SetLongValue(listId + ".lastFile", fileId);
    }

    public FileItem? GetCurrentFile()
    {
        return dataBase.GetCurrentFile();
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
        SetLastFile(dataBase.GetNextFileId());
    }

    public void SetPreviousFile()
    {
        SetLastFile(dataBase.GetPreviousFileId());
    }
}