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

            // TODO: embed jsx/svelte/csml for realtime frontend updates
            //       routes folder with .csml files, components folder with components
            //       before build target, get all files routes folder
            //       generate cs and html needed for prerender (and good updating)
            //       use reflection to code-gen and include in the csproj dll
            // TODO: share, patent, powerpoint
            return new ContentResult 
            { 
                Content = $@"<html>
<head>
<link rel='stylesheet' href='home/styles.css'>
</head>
<body>
    <h1>Serverless Side Render</h1>
    <p>Time rendered on server: {DateTime.Now.ToString("dddd, yyyy-MM-ddTHH:mm:ss")}</p>
    <p>Data rendered on server: [{string.Join(',', currentData)}]</p>
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

    // Maybe everything should be compiled into javascript or html instead?
    public static class HomeCss
    {
        [FunctionName("HomeCss")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "Home/styles.css")] HttpRequest req,
            ILogger log)
        {
            return new ContentResult 
            { 
                Content = $@"body {{
  background-color: lightblue;
}}

h1 {{
  color: navy;
  margin-left: 20px;
}}", 
                ContentType = "text/css", 
                StatusCode = 200 
            };
        }
    }
}
