using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace _01_ADO.NET
{
    /// <summary>
    /// Vorbereitung
    ///
    /// 1. SQLite/SQL Server Compact Toolbox installieren, damit man mit Visual Studio in die Datenbank schauen kann
    ///    analog wie es mit dem Microsoft SQL Server Management Studio bei Microsoft SQL Server möglich ist.
    ///    https://marketplace.visualstudio.com/items?itemName=ErikEJ.SQLServerCompactSQLiteToolbox
    ///
    /// 2. Den ADO.NET-Dataprovider "System.Data.SQLite.Core" für die SQLite-Datenbank mit dem NuGet-Paketmanager installieren
    ///    Die Bibliotheken werden in folgenden Ordner heruntergeladen: \CS2\01 Übungen\packages\System.Data.SQLite.Core.1.0.103
    /// </summary>

    public partial class Form1 : Form
    {
        private SQLiteConnection connection;
        private SQLiteDataAdapter dataAdapter;
        private DataSet highscoreDataSet;

        public Form1()
        {
            InitializeComponent();
        }

        private void DatenbankErstellen_Click(object sender, EventArgs e)
        {
            // https://stackoverflow.com/questions/15292880/create-sqlite-database-and-table

            string datenbankDateiname = "MeineDatenbank.sqlite";
            if (File.Exists(datenbankDateiname))
            {
                File.Delete(datenbankDateiname);
            }
            SQLiteConnection.CreateFile(datenbankDateiname); // Namensraum: using System.Data.SQLite;
            // Die Datenbank wird hier erstellt
            //      für das 32bit-Visual-Studio, sprich bis VS 2019: \Code\01_ADO.NET\bin\Debug\MeineDatenbank.sqlite
            //      für das 64bit-Visual-Studio, sprich ab  VS 2022: \Code\01_ADO.NET\bin\x64\Debug\MeineDatenbank.sqlite
            // Die noch leere Datenbank kann im SQLite/SQL Server Compact Toolbox betrachtet werden.
        }

        private void ÖffneOrdner_Click(object sender, EventArgs e)
        {
            Process.Start(".");
        }

        private void BaueDatenbankverbindungAuf_Click(object sender, EventArgs e)
        {
            connection = new SQLiteConnection("Data Source=MeineDatenbank.sqlite;Version=3;");  // https://www.connectionstrings.com/sqlite/
            connection.Open();
        }

        private void SchliesseDatenbankverbindung_Click(object sender, EventArgs e)
        {
            connection.Close();
        }

        private void ErstelleTabelle_Click(object sender, EventArgs e)
        {
            string sql = $"create table {Names.HighScores} ({Names.Id} integer primary key autoincrement not null, {Names.Name} varchar(20), {Names.Score} int)";
            var command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        private void FülleDatenEin_Click(object sender, EventArgs e)
        {
            Insert("Me", 3000);
            Insert("Myself", 6000);
            Insert("And I", 9001);
        }

        private void Insert(string name, int score)
        {
            string sql = $"insert into {Names.HighScores} ({Names.Id}, {Names.Name}, {Names.Score}) values (null, '{name}', {score})";
            var command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        private void LiesDaten_Click(object sender, EventArgs e)
        {
            string sql = $"select * from {Names.HighScores} order by {Names.Score} desc";

            try
            {
                // https://www.thoughtco.com/use-sqlite-from-a-c-application-958255
                highscoreDataSet = new DataSet();
                dataAdapter = new SQLiteDataAdapter(sql, connection);
                
                // Ohne Tabellenname
                //dataAdapter.Fill(highscoreDataSet);
                //dataGridView1.DataSource = highscoreDataSet.Tables[0].DefaultView;

                // Mit Tabellenname
                dataAdapter.Fill(highscoreDataSet, Names.HighScores);
                dataGridView1.DataSource = highscoreDataSet.Tables[Names.HighScores].DefaultView;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                throw;
            }
        }

        private void FülleDateInGridViewEin_Click(object sender, EventArgs e)
        {
            highscoreDataSet.Tables[Names.HighScores].Rows.Add(null, "John", 123);
        }

        private void SpeichereTabelleZurückInDieDatenbank_Click(object sender, EventArgs e)
        {
            var commandBuilder = new SQLiteCommandBuilder(dataAdapter);
            dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand(); // https://stackoverflow.com/questions/19228608/dataadapter-update-unable-to-find-tablemappingtable-or-datatable-table
            int count = dataAdapter.Update(highscoreDataSet, Names.HighScores);
            highscoreDataSet.Tables[Names.HighScores].AcceptChanges(); // https://www.codeproject.com/Questions/153263/Solved-concurrency-violation-Updated-0-of-the-exp
            Debug.WriteLine($"Update command: {commandBuilder.GetUpdateCommand().CommandText}");
            Debug.WriteLine($"Update count: {count}");
        }
    }
}
