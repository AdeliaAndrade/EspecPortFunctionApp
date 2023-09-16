using EspecPortFunctionApp.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EspecPortFunctionApp.Services.ProcessAnalyzes
{
    public interface IProcessAnalyzesService
    {
        ProcessAnalysesResultDto Process(ProcessAnalysesDto data);
    }
}
