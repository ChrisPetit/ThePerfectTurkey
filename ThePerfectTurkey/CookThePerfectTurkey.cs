using System;
using System.IO;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ThePerfectTurkey
{
    public static class CookThePerfectTurkey
    {
        [FunctionName("CookThePerfectTurkey")]
        public static async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string weight = req.Query["weight"];
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            weight ??= data?.weight;
            double lbs;
            try
            {
                lbs = Convert.ToDouble(weight);
                if (weight == null)
                {
                    return new BadRequestObjectResult(
                        "Please pass a weight on the query string or in the request body");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new BadRequestObjectResult(
                    "Please pass a weight that is convertible to a double on the query string or in the request body");
            }

            var turkey = new Turkey() {Weight = lbs};
            var brine = new Brine(turkey);
            return new OkObjectResult(brine.CreateRecipe());
        }
    }
}