using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EspecPortFunctionApp.Dtos
{
    public class ProcessAnalysesItemDto
    {
        public int Index { get; set; }
        public decimal Value { get; set; }
        public decimal? Absorbance { get; set; }
        public decimal? Transmittance { get; set; }
    }
}
