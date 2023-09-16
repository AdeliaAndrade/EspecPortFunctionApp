using EspecPortFunctionApp.Dtos;
using EspecPortFunctionApp.Services.Export;
using EspecPortFunctionApp.Services.ProcessAnalyzes;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EspecPortFunctionApp.Controllers.ProcessAnalyzes
{
    public class ProcessAnalyzesController : IProcessAnalyzesController
    {
        private readonly IConfiguration _configuration;
        private readonly IProcessAnalyzesService _processAnalyzesService;
        private readonly IExportService _exportService;
        public ProcessAnalyzesController(IConfiguration configuration, IProcessAnalyzesService processAnalyzesService, IExportService exportService)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _processAnalyzesService = processAnalyzesService ?? throw new ArgumentNullException(nameof(processAnalyzesService));
            _exportService = exportService ?? throw new ArgumentNullException(nameof(exportService));
        }

        public ProcessAnalysesResultDto Process(ProcessAnalysesDto data)
        {
            var result = _processAnalyzesService.Process(data);

            return result;
        }

        public void ExportToWord(ExportValuesDto data)
        {
            _exportService.ExportToWord(data);
        }
    }
}
