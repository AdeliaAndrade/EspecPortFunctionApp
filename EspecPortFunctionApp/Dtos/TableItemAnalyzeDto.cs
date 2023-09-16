using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EspecPortFunctionApp.Dtos
{
    public class TableItemAnalyzeDto
    {
        public decimal AbsorbanceAt470nm { get; set; }
        public decimal AbsorbanceAt647nm { get; set; }
        public decimal AbsorbanceAt663nm { get; set; }
        public decimal TransmittanceAt470nm { get; set; }
        public decimal TransmittanceAt647nm { get; set; }
        public decimal TransmittanceAt663nm { get; set; }
        public decimal Ca { get; set; }
        public decimal Cb { get; set; }
        public decimal Ct { get; set; }
        public decimal R { get; set; }
    }
}
