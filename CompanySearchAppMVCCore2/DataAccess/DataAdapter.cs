using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanySearchAppMVCCore2.Models;
using System.Net.Http;
using System.IO;
using System.Net;

namespace CompanySearchAppMVCCore2.DataAccess
{
    public class DataAdapter
    {
        public async Task<HomeViewModel> GetSearchResults(string SearchTerm)
        {
            String result = "";

            using (HttpClient client = new HttpClient())
            {
              var responseMessage = await client.GetAsync($"https://functionappphrsearch01.azurewebsites.net/api/Function1?CompanyID={SearchTerm}");
            }

            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create($"https://functionappphrsearch01.azurewebsites.net/api/Function1?CompanyID={SearchTerm}");
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();


            var data = JsonConvert.DeserializeObject<RootObject>(responseFromServer);

            HomeViewModel model = new HomeViewModel();

            model.Name = data.results[0].name;
            model.YTunnus = data.results[0].businessId;
            model.Toimipaikat = new List<RegistedOffice>();
            model.Toimipaikat.AddRange(data.results[0].registedOffices);

            return model;
        }

    }
}
