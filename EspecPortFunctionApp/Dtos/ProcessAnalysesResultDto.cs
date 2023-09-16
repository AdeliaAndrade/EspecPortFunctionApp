using EspecPortFunctionApp.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EspecPortFunctionApp.Dtos
{
    public class ProcessAnalysesResultDto
    {
        public List<TableItemAnalyzeDto> TableAnalyzes { get; set; }
        public decimal StandardDeviation { get; set; }
        public decimal AmountOfCarotenoids { get; set; }
        public decimal Ratio { get; set; }
        public EMaturationLevel MaturationLevel { get; set; }
    }
}
