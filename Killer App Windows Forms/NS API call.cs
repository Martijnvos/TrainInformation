using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Killer_App_Windows_Forms
{
    enum Results { Success, APICallError};

    class NS_API_call
    {
        private const string URL = "http://webservices.ns.nl/ns-api-treinplanner";
        private string APICallResult = "";
        XmlDocument doc;

        //Roep de NS API call aan en vervorm daarbij de input uit de combobox voor 's-Hertogenbosch.
        //De NS API herkent namelijk alleen s-Hertogenbosch. Voeg de benodigde stations aan de URL toe.
        public async Task<Results> callAPI(string departureStation, string arrivalStation)
        {
            string urlParameters;

            if (arrivalStation == "s-Hertogenbosch")
            {
                urlParameters = "?fromStation=" + departureStation + "&toStation=%27" + arrivalStation;
            } else if (departureStation == "s-Hertogenbosch")
            {
                urlParameters = "?fromStation=%27" + departureStation + "&toStation=" + arrivalStation;
            } else
            {
                urlParameters = "?fromStation=" + departureStation + "&toStation=" + arrivalStation;
            }

            HttpClient client = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes("NS_API_KEY_HERE");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            //Roep de NS API aan met de ingevulde gegevens en inloginformatie in de header.
            //Return het resultaat.
            try
            {
                HttpResponseMessage response = await client.GetAsync(URL + urlParameters);
                response.EnsureSuccessStatusCode();
                APICallResult = await response.Content.ReadAsStringAsync();

                doc = new XmlDocument();
                if (APICallResult != "")
                {
                    doc.LoadXml(APICallResult);
                    return Results.Success;
                } else
                {
                    return Results.APICallError;
                }   
            }
            catch (Exception)
            {
                return Results.APICallError;
            }

        }

        //Return de hoeveelheid reismogelijkheden vanuit de API informatie.
        public int amountOfReismogelijkheden()
        {
            XmlNodeList nodeList = doc.DocumentElement.SelectNodes("/ReisMogelijkheden/ReisMogelijkheid");
            int numberOfReismogelijkheden = nodeList.Count;

            return numberOfReismogelijkheden;
        }

        //Return de overstapinformatie vanuit de API informatie.
        public List<string> returnAantalKeerOverstappen()
        {
            List<string> aantalKeerOverstappenList = new List<string>();

            XmlNodeList overStapList = doc.DocumentElement.SelectNodes("/ReisMogelijkheden/ReisMogelijkheid");
            foreach (XmlNode overStap in overStapList)
            {
                string aantalOverstappen = overStap["AantalOverstappen"].InnerText;
                aantalKeerOverstappenList.Add(aantalOverstappen);
            }
 
            return aantalKeerOverstappenList;
        }

        //Return de actuele vertrektijd vanuit de API informatie.
        public List<string> returnActueleVertrekTijd()
        {
            List<string> actueleVertrekTijdList = new List<string>();

            XmlNodeList reisMogelijkheidList = doc.DocumentElement.SelectNodes("/ReisMogelijkheden/ReisMogelijkheid");
            foreach (XmlNode reisMogelijkheid in reisMogelijkheidList)
            {
                string actueleVertrekTijd = reisMogelijkheid["ActueleVertrekTijd"].InnerText;
                string actueleVertrekTijdTrimmed = actueleVertrekTijd.Remove(0, 11).Remove(8);
                actueleVertrekTijdList.Add(actueleVertrekTijdTrimmed);
            }
  
            return actueleVertrekTijdList;
        }

        //Return de actuele aankomsttijd vanuit de API informatie.
        public List<string> returnActueleAankomstTijd()
        {
            List<string> actueleAankomstTijdList = new List<string>();

            XmlNodeList reisMogelijkheidList = doc.DocumentElement.SelectNodes("/ReisMogelijkheden/ReisMogelijkheid");
            foreach (XmlNode reisMogelijkheid in reisMogelijkheidList)
            {
                string actueleAankomstTijd = reisMogelijkheid["ActueleAankomstTijd"].InnerText;
                string actueleAankomstTijdTrimmed = actueleAankomstTijd.Remove(0, 11).Remove(8);
                actueleAankomstTijdList.Add(actueleAankomstTijdTrimmed);
            }

            return actueleAankomstTijdList;
        }

        //Return het vervoertype informatie vanuit de API informatie.
        public List<string> returnVervoerTypes()
        {
            List<string> vervoerTypeList = new List<string>();

            XmlNodeList vervoerTypeNodeList = doc.DocumentElement.SelectNodes("/ReisMogelijkheden/ReisMogelijkheid/ReisDeel");
            foreach (XmlNode vervoerType in vervoerTypeNodeList)
            {
                string vervoerTypeString = vervoerType["VervoerType"].InnerText;
                vervoerTypeList.Add(vervoerTypeString);
            }

            return vervoerTypeList;
        }

        //Return de status informatie vanuit de API informatie.
        public List<string> returnStatus()
        {
            List<string> statusList = new List<string>();

            XmlNodeList statusNodeList = doc.DocumentElement.SelectNodes("/ReisMogelijkheden/ReisMogelijkheid");
            foreach (XmlNode status in statusNodeList)
            {
                string statusString = status["Status"].InnerText;
                statusList.Add(statusString);
            }

            return statusList;
        }

        //Return de reistijd informatie vanuit de API informatie.
        public List<string> returnActueleReistijd()
        {
            List<string> actueleReistijdList = new List<string>();

            XmlNodeList actueleReisTijdList = doc.DocumentElement.SelectNodes("/ReisMogelijkheden/ReisMogelijkheid");
            foreach (XmlNode actueleReisTijd in actueleReisTijdList)
            {
                string actueleReistijd = actueleReisTijd["ActueleReisTijd"].InnerText;
                actueleReistijdList.Add(actueleReistijd);
            }

            return actueleReistijdList;
        }
    }
}
