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
}