using MySql.Data.MySqlClient;
using System.Data;

namespace Killer_App_Windows_Forms
{
    public enum Result { MySqlException, Success };

    class DatabaseConnection
    {
        private MySqlConnection mySqlConnection;

        private string server = "SERVER_NAME_HERE";
        private string database = "DATABASE_NAME_HERE";
        private string uid = "UID_HERE";
        private string password = "DATABASE_PASSWORD_HERE";

        public Result openDatabaseConnection()
        {
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            mySqlConnection = new MySqlConnection(connectionString);

            //Probeer een databaseconnectie te beginnen en return aan de hand van de uitslag
            //een waarde uit de enum Result.
            try
            {
                mySqlConnection.Open();
                return Result.Success;
            }
            catch (MySqlException)
            {
                closeDatabaseConnection();
                return Result.MySqlException;
            }  
        }

        public DataSet getDistinctStationNamesInformation()
        {
            MySqlCommand cmd = mySqlConnection.CreateCommand();
            // Verkrijg de gehele kolom FromStationName van de tabel traininformation en haal daar de unieke entries uit.
            cmd.CommandText = "SELECT DISTINCT FromStationName FROM traininformation";
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds, "stationnameinformation");

            closeDatabaseConnection();

            return ds;
        }

        public DataSet getConnectedStations(string station, string column1, string column2)
        {
            MySqlCommand cmd = mySqlConnection.CreateCommand();
            // Selecteer de doorgegeven column1 en 'Distance' van de tabel traininformatie
            // en geef de waarde en bijbehorende afstand die gelijk zijn aan de doorgegeven stationsnaam uit column2 terug.
            cmd.CommandText = "SELECT " + column1 + ", Distance FROM traininformation WHERE " + column2 + " = '"+ station + "'";
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds, "connectedstations");

            closeDatabaseConnection();

            return ds;
        }
        
        private void closeDatabaseConnection()
        {
            //Verbreek de verbinding met de database als die nog open staat.
            if (mySqlConnection.State == ConnectionState.Open)
            {
                mySqlConnection.Close();
            }
        }

    }
}
