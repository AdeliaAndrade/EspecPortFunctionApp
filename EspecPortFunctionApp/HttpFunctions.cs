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

        [FunctionName("ExportWord")]
        public async Task<IActionResult> ExportWord(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "ExportWord")] HttpRequest req,
            ILogger log)
        {
            var data = new ExportValuesDto
            {
                LeiloeiroNome = "GG",
                LeiloeiroTipo = "GG Tipo",
                Jucesp = "123456",
                ComercialTelefone = "(19) 99999-9999",
                PessoalTelefone = "(19) 99999-9999",
                Rg = "xx.xxx.xxx-x",
                Cpf = "xxx.xxx.xxx-xx",
                CidadeResidencialJunta = "Piracicaba",
                ResidencialJuntaEndereco = "Rua tal",
                ResidencialJuntaNumero = "555",
                BairroResidencialJunta = "Bairro tal",
                CepResidencialJunta = "77777-777",
                RicoEmail = "rico@rico.com",
                ComercialEndereco = "Rua tal comercial",
                ComercialNumero = "777",
                ComplementoComercial = "complemento",
                BairroComercial = "Bairro comercial",
                CidadeComercial = "Rio das Pedras",
                ComercialUf = "SP",
                CepComercial = "55555-555",
                Site = "www.teste.com",
                PessoalEmail = "teste@teste.com",
                TemplatePath = "Services/Export/Templates/Template_D_I_S_O.docx",
                OutputPath = "C:/Users/delit/Desktop/TCC/novo_documento.docx"
            };

            _processAnalyzesController.ExportToWord(data);

            return new OkObjectResult(true);
        }
    }
}
