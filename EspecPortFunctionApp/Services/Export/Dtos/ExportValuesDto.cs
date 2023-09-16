using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EspecPortFunctionApp.Dtos
{
    public class ExportValuesDto
    {
        public string LeiloeiroNome { get; set; }
        public string LeiloeiroTipo { get; set; }
        public string Jucesp { get; set; }
        public string ComercialTelefone { get; set; }
        public string PessoalTelefone { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string CidadeResidencialJunta { get; set; }
        public string ResidencialJuntaEndereco { get; set; }
        public string ResidencialJuntaNumero { get; set; }
        public string BairroResidencialJunta { get; set; }
        public string CepResidencialJunta { get; set; }
        public string RicoEmail { get; set; }
        public string ComercialEndereco { get; set; }
        public string ComercialNumero { get; set; }
        public string ComplementoComercial { get; set; }
        public string BairroComercial { get; set; }
        public string CidadeComercial { get; set; }
        public string ComercialUf { get; set; }
        public string CepComercial { get; set; }
        public string Site { get; set; }
        public string PessoalEmail { get; set; }
        public string TemplatePath { get; set; }
        public string OutputPath { get; set; }
    }
}
