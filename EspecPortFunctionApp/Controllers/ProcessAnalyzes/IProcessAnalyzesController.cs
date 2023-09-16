using EspecPortFunctionApp.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EspecPortFunctionApp.Controllers.ProcessAnalyzes
{
    public interface IProcessAnalyzesController
    {
        ProcessAnalysesResultDto Process(ProcessAnalysesDto data);

        void ExportToWord(ExportValuesDto data);
    }
}
