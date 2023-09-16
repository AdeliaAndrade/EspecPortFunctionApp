using EspecPortFunctionApp.Dtos;
using EspecPortFunctionApp.Enumerators;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EspecPortFunctionApp.Services.ProcessAnalyzes
{
    public class ProcessAnalyzesService : IProcessAnalyzesService
    {
        private readonly IConfiguration _configuration;
        public ProcessAnalyzesService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public ProcessAnalysesResultDto Process(ProcessAnalysesDto data)
        {
            var result = new ProcessAnalysesResultDto();

            result.TableAnalyzes = CalcItems(data);

            result.AmountOfCarotenoids = CalcAmountOfCarotenoids(result.TableAnalyzes);

            result.StandardDeviation = CalcStandardDeviation(result.TableAnalyzes);

            result.Ratio = CalcRatio(result.AmountOfCarotenoids);

            result.MaturationLevel = ClassifyMaturation(result.Ratio);

            return result;
        }

        private List<TableItemAnalyzeDto> CalcItems(ProcessAnalysesDto data)
        {
            var items = new List<TableItemAnalyzeDto>();

            if(data != null)
            {
                foreach(var process in data.ProcessAnalysesItems)
                {
                    var startValue = 50.0M;

                    if(process.Index >= 35 && process.Index <= 50)
                    {
                        startValue = 5.7M;
                    }else if(process.Index >= 17 && process.Index <= 34)
                    {
                        startValue = 7.4M;
                    }
                    else
                    {
                        startValue = 50.0M;
                    }

                    process.Transmittance = CalcTransmittance(process.Value, startValue);
                    process.Absorbance = CalcAbsorbance(process.Transmittance.Value);
                }

                //663nm
                var itemsFor663nm = data.ProcessAnalysesItems.FindAll(x => x.Index >= 35 && x.Index <= 50);
                itemsFor663nm = itemsFor663nm.OrderByDescending(x => x.Absorbance).ToList().GetRange(1, 3);

                //647nm
                var itemsFor647nm = data.ProcessAnalysesItems.FindAll(x => x.Index >= 17 && x.Index <= 34);
                itemsFor647nm = itemsFor647nm.OrderByDescending(x => x.Absorbance).ToList().GetRange(1, 3);

                //470nm
                var itemsFor470nm = data.ProcessAnalysesItems.FindAll(x => x.Index >= 1 && x.Index <= 16);
                itemsFor470nm = itemsFor470nm.OrderByDescending(x => x.Absorbance).ToList().GetRange(0, 3);

                for (int i = 0; i < 3; i++)
                {
                    var transmittanceAt663nm = itemsFor663nm[i].Transmittance.Value;
                    var transmittanceAt647nm = itemsFor647nm[i].Transmittance.Value;
                    var transmittanceAt470nm = itemsFor470nm[i].Transmittance.Value;

                    var absorbanceAt663nm = itemsFor663nm[i].Absorbance.Value;
                    var absorbanceAt647nm = itemsFor647nm[i].Absorbance.Value;
                    var absorbanceAt470nm = itemsFor470nm[i].Absorbance.Value;

                    var ca = (12.25M * absorbanceAt663nm) - (2.79M * absorbanceAt647nm);
                    var cb = (21.5M * absorbanceAt647nm) - (5.1M * absorbanceAt663nm);
                    var ct = ((1000M * absorbanceAt470nm) - (1.82M * ca) - (85.02M * cb)) / 198M;

                    var item = new TableItemAnalyzeDto
                    {
                        TransmittanceAt470nm = Math.Round(transmittanceAt470nm, 3),
                        TransmittanceAt647nm = Math.Round(transmittanceAt647nm, 3),
                        TransmittanceAt663nm = Math.Round(transmittanceAt663nm, 3),
                        AbsorbanceAt470nm = Math.Round(absorbanceAt470nm, 3),
                        AbsorbanceAt647nm = Math.Round(absorbanceAt647nm, 3),
                        AbsorbanceAt663nm = Math.Round(absorbanceAt663nm, 3),
                        Ca = Math.Round(ca, 3),
                        Cb = Math.Round(cb, 3),
                        Ct = Math.Round(ct, 3),
                        R = Math.Round(ct, 3)
                    };

                    items.Add(item);
                }
            }

            return items;
        }

        private decimal CalcTransmittance(decimal value, decimal startValue)
        {
            return (100 * value) / startValue;
        }

        private decimal CalcAbsorbance(decimal value)
        {
            decimal logResult = (decimal)Math.Log10((double)value);
            return 2 - logResult;
        }

        private decimal CalcRatio(decimal value)
        {
            return Math.Round(((value - 2.256M) / 0.277M), 3);
        }

        private EMaturationLevel ClassifyMaturation(decimal ratio)
        {
            if(ratio < 13.5M)
            {
                return EMaturationLevel.Unripe;
            }
            else if(ratio >= 13.5M && ratio <= 18)
            {
                return EMaturationLevel.Mature;
            }
            else
            {
                return EMaturationLevel.Past;
            }
        }

        private decimal CalcAmountOfCarotenoids(List<TableItemAnalyzeDto> table)
        {
            int count = table.Count;
            var amountOfCarotenoids = 0.0M;

            foreach (var item in table)
            {
                amountOfCarotenoids += item.R;
            }

            return amountOfCarotenoids / count;
        }

        private decimal CalcStandardDeviation(List<TableItemAnalyzeDto> table)
        {
            decimal result = 0;

            if (table.Any())
            {
                double average = (double)table.Average(x => x.R);
                double sum = table.Sum(d => Math.Pow((double)(d.R) - average, 2));
                result = (decimal)Math.Sqrt((sum) / table.Count());
            }
            return result;
        }
    }
}
