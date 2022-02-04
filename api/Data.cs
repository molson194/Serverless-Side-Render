using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ServerlessSideRender
{
    public static class GetData
    {
        [FunctionName("GetData")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "api/data")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Get data.");
            return new OkObjectResult(Data.GetData());
        }
    }

    public static class PostData
    {
        [FunctionName("PostData")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "api/data")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Post data.");
            string name = req.Form["name"];
            Data.AppendData(name);
            return new AcceptedResult("http://localhost:7071/Home", "Data accepted. Note to self: prevent default submit action to change form href location.");
        }
    }

    public static class Data
    {
        private static IList<string> RawData = new List<string>
        {
            "a",
            "b",
        };

        public static IList<string> GetData()
        {
            return RawData;
        }

        public static void AppendData(string data)
        {
            RawData.Add(data);
        }
    }
}
