using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using EspecPortFunctionApp.Dtos;
using Microsoft.Extensions.Configuration;
using EspecPortFunctionApp.Controllers.ProcessAnalyzes;

namespace EspecPortFunctionApp
{
    public class HttpFunctions
    {
        private readonly IConfiguration _configuration;
        private readonly IProcessAnalyzesController _processAnalyzesController;
        public HttpFunctions(IConfiguration configuration, IProcessAnalyzesController processAnalyzesController)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _processAnalyzesController = processAnalyzesController ?? throw new ArgumentNullException(nameof(processAnalyzesController));
        }

        [FunctionName("PostProcessAnalyzes")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "ProcessAnalyzes")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<ProcessAnalysesDto>(requestBody);

            var response = _processAnalyzesController.Process(data);

            return new OkObjectResult(response);
        }
    }
}
