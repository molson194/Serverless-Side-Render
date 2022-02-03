using System;
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
    public static class Home
    {
        [FunctionName("Home")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Visit the home page.");

            var currentData = Data.GetData();

            // TODO: return css
            // TODO: form redirect
            // TODO: embed jsx/svelte for realtime frontend updates
            // TODO: create static html
            // TODO: upload functions and static site to azure
            // TODO: run speed test
            // TODO: share, patent, powerpoint
            return new ContentResult 
            { 
                Content = $@"<html>
<head>
<link rel='stylesheet' href='styles.css'>
</head>
<body>
    <h1>Serverless Side Render</h1>
    <p>Time rendered on server: {DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm")}</p>
    <p>Data: [{string.Join(',', currentData)}]</p>
    <form action='/api/data' method='post'>
        <input type='text' id='name' name='name' placeholder='data'>
        <button id='submit'>Submit</button>
    </form>
</body>
</html>", 
                ContentType = "text/html", 
                StatusCode = 200 
            };
        }
    }
}
