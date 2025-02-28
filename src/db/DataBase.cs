using SBRunScr.user;
using Microsoft.Data.Sqlite;
using SBRunScr.resources;

namespace SBRunScr.db;

public class DataBase
{
    public DataBase()
    {
        string file = new User().UserFile();
        using SqliteConnection connection = new($"Data Source={file};Foreign Keys=True");
        connection.Open();
        CreateTables(connection);
    }

    private void CreateTables(SqliteConnection connection)
    {
        SqliteCommand command = new();
        command.Connection = connection;
        command.CommandText = Resources.GetSql("createTableLists");
        command.ExecuteNonQuery();
        command.CommandText = Resources.GetSql("createTableFiles");
        command.ExecuteNonQuery();
        command.CommandText = Resources.GetSql("createTableSettings");
        command.ExecuteNonQuery();
    }
}