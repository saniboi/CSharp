using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using Spectre.Console;

namespace ADO.NET_SQLite_platformindependent;

internal class Program
{
    private readonly string databaseName;
    private readonly DbConnection connection;
    private const string TableName = "HighScores";
    private const string IdColumnName = "Id";
    private const string NameColumnName = "Name";
    private const string ScoreColumnName = "Score";

    public static void Main()
    {
        Program p = new();
        p.CreateASqliteDbAndWriteAndReadDataSoThatItWorksPlatformindependentlyOnWindowsAndMac();
    }

    public Program()
    {
        databaseName = "MyDatabase.sqlite";
        connection = new SQLiteConnection($"Data Source={databaseName};Version=3;");
    }

    private void CreateASqliteDbAndWriteAndReadDataSoThatItWorksPlatformindependentlyOnWindowsAndMac()
    {
        CreateDb();
        OpenConnection();
        CreateTable();
        WriteData();
        ReadData();
        CloseConnection();
    }

    private void CreateDb()
    {
        SQLiteConnection.CreateFile(databaseName);
    }

    private void OpenConnection()
    {

        connection.Open();
    }

    private void CreateTable()
    {
        string sql = $"create table {TableName} (Id integer primary key autoincrement not null, {NameColumnName} varchar(20), {ScoreColumnName} int)";
        var command = new SQLiteCommand(sql, connection as SQLiteConnection);
        command.ExecuteNonQuery();
    }

    private void WriteData()
    {
        Insert("Me", 3000);
        Insert("Myself", 6000);
        Insert("And I", 9001);
    }

    private void Insert(string name, int score)
    {
        string sql = $"insert into {TableName} ({IdColumnName}, {NameColumnName}, {ScoreColumnName}) values (null, '{name}', {score})";
        var command = new SQLiteCommand(sql, connection as SQLiteConnection);
        command.ExecuteNonQuery();
    }

    private void ReadData()
    {
        string sql = $"select * from {TableName} order by {ScoreColumnName} desc";

        try
        {
            DataSet highscoreDataSet = new();
            DbDataAdapter dataAdapter = new SQLiteDataAdapter(sql, connection as SQLiteConnection);

            dataAdapter.Fill(highscoreDataSet, TableName);
            PrintTable(highscoreDataSet);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }

    private void PrintTable(DataSet highscoreDataSet)
    {
        Table table = new();
        table.AddColumn(new TableColumn(IdColumnName).LeftAligned());
        table.AddColumn(new TableColumn(NameColumnName).LeftAligned());
        table.AddColumn(new TableColumn(ScoreColumnName).LeftAligned());

        foreach (DataRow row in highscoreDataSet.Tables[TableName]!.Rows)
        {
            Int64 id = (Int64)row[IdColumnName];
            string name = row[NameColumnName] as string ?? string.Empty;
            Int32 score = (Int32)row[ScoreColumnName];

            table.AddRow(new string[]{ id.ToString(), name, score.ToString() });
        }

        AnsiConsole.Write(table);
    }

    private void CloseConnection()
    {
        connection.Close();
    }
}