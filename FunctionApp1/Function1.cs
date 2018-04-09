
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Net;

namespace FunctionApp1
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string CompanyID = req.Query["CompanyID"];

            //https://prod-15.northeurope.logic.azure.com/workflows/4d47173280444086ae56767160a1ae2a/triggers/request/paths/invoke/CompanySearch/2800989-1?api-version=2016-10-01&sp=%2Ftriggers%2Frequest%2Frun&sv=1.0&sig=i6nY9_1hb1OthK_fBnxG17VT2-IgBPiP9qjr3CGr5J8


            string resultContent = "";

            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create($"https://prod-15.northeurope.logic.azure.com/workflows/4d47173280444086ae56767160a1ae2a/triggers/request/paths/invoke/CompanySearch/{CompanyID}?api-version=2016-10-01&sp=%2Ftriggers%2Frequest%2Frun&sv=1.0&sig=i6nY9_1hb1OthK_fBnxG17VT2-IgBPiP9qjr3CGr5J8");
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            resultContent = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();


            return !String.IsNullOrEmpty(CompanyID)
                ? (ActionResult)new OkObjectResult(resultContent)
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
