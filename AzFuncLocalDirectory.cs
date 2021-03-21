using System.IO;
using System.Threading.Tasks;
using AzFuncLocalDirectory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Microsoft.Function
{
    public class AzFuncLocalDirectory
    {
        private readonly AzureFunctionsServiceConfig _service;

        public AzFuncLocalDirectory(AzureFunctionsServiceConfig service)
        {
            _service = service;
        }

        [FunctionName("AzFuncLocalDirectory")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log, ExecutionContext context)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            string responseMessage = requestBody + $". Current directory {_service.RootDirectory}";

            return new OkObjectResult(responseMessage);
        }
    }
}

