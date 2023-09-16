using EspecPortFunctionApp.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EspecPortFunctionApp.Services.Export
{
    public interface IExportService
    {
        void ExportToWord(ExportValuesDto data);
    }
}
