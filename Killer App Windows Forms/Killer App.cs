using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Http;
using Newtonsoft.Json;
using System.Xml;

namespace Killer_App_Windows_Forms
{
    public partial class Form : System.Windows.Forms.Form
    {

        CalculateTravelInformation dijkstra;
        DatabaseConnection databaseConnectionClass;
        NS_API_call nsApiCall;

        List<string> distinctStationNames;
        List<string> actueleVertrekTijdList;
        List<string> actueleAankomstTijdList;
        List<string> aantalOverstappenList;
        List<string> vervoerTypeList;
        List<string> statusList;
        List<string> reisTijdList;

        private string departureStation;
        private string arrivalStation;

        public Form()
        {
            InitializeComponent();

            //Probeer de databaseconnectie te starten door de openDatabaseConnection
            //methode aan te roepen in de DatabaseConnection klasse en handel het resultaat af.
            databaseConnectionClass = new DatabaseConnection();
            Result resultMessage =  databaseConnectionClass.openDatabaseConnection();
            if (resultMessage == Result.MySqlException)
            {
                MessageBox.Show("Could not connect to the database. Please try again.");
            }

            nsApiCall = new NS_API_call();

        }

        //Clear de listbox waar de uitkomst van het Dijkstra algoritme in komt
        //en de textbox voor het resultaat van de NS API call.
        //Ook wordt een methode aangeroepen die een query uitvoert
        //op de database met behulp van de DatabaseConnection klasse.
        private void buttonGetShortestPath_Click(object sender, EventArgs e)
        {
            listBoxShortestPath.Items.Clear();

            departureStation = comboBoxDepartureStation.Text;
            arrivalStation = comboBoxArrivalStation.Text;

            getDistinctStationNamesInformation();
            
            //NS API verwerking
            textBoxNSApi.Clear();
            NSApiCall(departureStation, arrivalStation);
        }

        //Verkrijg de unieke stationsnamen in de database.
        public void getDistinctStationNamesInformation()
        {
            DataSet dsStations = databaseConnectionClass.getDistinctStationNamesInformation();

            DataTable dt = new DataTable();
            dt = dsStations.Tables["stationnameinformation"];

            distinctStationNames = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                distinctStationNames.Add(row[0].ToString());
            }
            // Alle unieke stationsnamen staan nu in de list distinctStationNames.

            fillDijkstra();

        }

        private void fillDijkstra()
        {
            //Verkrijg voor ieder station de stations die ernaast liggen met hun afstanden
            //en vul deze in zoals het Dijkstra algoritme de informatie wil ontvangen.
            dijkstra = new CalculateTravelInformation();
            foreach (string station in distinctStationNames)
            {
                Dictionary<string, int> connectedStationsDictionary = new Dictionary<string, int>();

                DataSet connectedStations = databaseConnectionClass.getConnectedStations(station, "ToNearStationName", "FromStationName");

                DataTable dt = new DataTable();
                dt = connectedStations.Tables["connectedstations"];

                foreach (DataRow row in dt.Rows)
                {
                    string connectedStationName = row[0].ToString();
                    int connectedStationDistance = Convert.ToInt32(row[1]);

                    connectedStationsDictionary.Add(connectedStationName, connectedStationDistance);
                }
                dijkstra.add_vertex(station, connectedStationsDictionary);
            }

            //Voeg de tussenstations toe aan de listbox.
            List<string> list = dijkstra.shortest_path(departureStation, arrivalStation);
            list.Reverse();
            list.ForEach(x => listBoxShortestPath.Items.Add(x));
        }

        public async void NSApiCall(string departureStation, string arrivalStation)
        {
            //Roep de NS API aan met behulp van de NS API Call klasse.
            //Het resultaat wordt gecheckt op fouten en wordt vervolgens ontleed tot de benodigde informatie.
            Results APICallResult = await nsApiCall.callAPI(departureStation, arrivalStation);
            if (APICallResult == Results.Success)
            {
                int numberOfReismogelijkheden = nsApiCall.amountOfReismogelijkheden();

                if (numberOfReismogelijkheden > 0)
                {
                    actueleVertrekTijdList = nsApiCall.returnActueleVertrekTijd();
                    actueleAankomstTijdList = nsApiCall.returnActueleAankomstTijd();
                    aantalOverstappenList = nsApiCall.returnAantalKeerOverstappen();
                    vervoerTypeList = nsApiCall.returnVervoerTypes();
                    statusList = nsApiCall.returnStatus();
                    reisTijdList = nsApiCall.returnActueleReistijd();

                    //Vul de benodigde informatie op de juiste plek in de zin in en 
                    //schrijf deze zin naar de textbox.
                    for (var i = 0; i < numberOfReismogelijkheden; i++)
                    {
                        textBoxNSApi.Text += String.Format("Actuele vertrektijd: {0},{6}Actuele aankomsttijd: {1},{6}Reistijd: {2},{6}Aantal keer overstappen: {3},{6}Vervoertype: {4},{6}Status: {5}.{6}{6}",
                        actueleVertrekTijdList.ElementAt(i),
                        actueleAankomstTijdList.ElementAt(i),
                        reisTijdList.ElementAt(i),
                        aantalOverstappenList.ElementAt(i),
                        vervoerTypeList.ElementAt(i),
                        statusList.ElementAt(i),
                        Environment.NewLine);
                    }
                }
            }
        }

        //End of form
    }
}
