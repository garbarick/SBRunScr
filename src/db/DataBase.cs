using SBRunScr.user;
using Microsoft.Data.Sqlite;
using SBRunScr.resources;
using SBRunScr.item;

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

    public long AddList(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return 0;
        }
        using SqliteConnection connection = Connect();
        using SqliteCommand command = new(Resources.GetSql("addList"), connection);
        command.Parameters.Add(new SqliteParameter("@name", name));
        return Convert.ToInt64(command.ExecuteScalar());
    }

    public List<ListItem> GetLists()
    {
        List<ListItem> result = new();
        using SqliteConnection connection = Connect(true);
        using SqliteCommand command = new(Resources.GetSql("getLists"), connection);
        using SqliteDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                long id = reader.GetInt64(0);
                string name = reader.GetString(1);
                long count = reader.GetInt64(2);
                result.Add(new ListItem(id, name, count));
            }
        }
        return result;
    }

    public bool RenameList(long id, string name)
    {
        using SqliteConnection connection = Connect();
        using SqliteCommand command = new(Resources.GetSql("renameList"), connection);
        command.Parameters.Add(new SqliteParameter("@id", id));
        command.Parameters.Add(new SqliteParameter("@name", name));
        return command.ExecuteNonQuery() > 0;
    }

    public bool DeleteList(long id)
    {
        using SqliteConnection connection = Connect();
        using SqliteCommand command = new(Resources.GetSql("deleteList"), connection);
        command.Parameters.Add(new SqliteParameter("@id", id));
        return command.ExecuteNonQuery() > 0;
    }
}