using SBRunScr.user;
using Microsoft.Data.Sqlite;
using SBRunScr.resources;

namespace SBRunScr.db;

public class DataBase
{
    public DataBase()
    {
        CreateTables();
    }

    private void Execute(SqliteConnection connection, string sql)
    {
        using SqliteCommand command = new(sql, connection);
        command.ExecuteNonQuery();
    }

    private SqliteConnection Connect(bool readOnly = false)
    {
        string file = new User().UserFile();
        string mode = readOnly ? "Mode=ReadOnly;" : "";
        SqliteConnection result = new($"Data Source={file};Foreign Keys=True;{mode}");
        result.Open();
        return result;
    }

    private void CreateTables()
    {
        using SqliteConnection connection = Connect();
        Execute(connection, Resources.GetSql("createTableLists"));
        Execute(connection, Resources.GetSql("createTableFiles"));
        Execute(connection, Resources.GetSql("createTableSettings"));
    }

    public bool AddList(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return false;
        }
        using SqliteConnection connection = Connect();
        using SqliteCommand command = new(Resources.GetSql("addList"), connection);
        command.Parameters.Add(new SqliteParameter("@name", name));
        return command.ExecuteNonQuery() > 0;
    }
}