using EspecPortFunctionApp.Dtos;
using EspecPortFunctionApp.Enumerators;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace EspecPortFunctionApp.Services.Export
{
    public class ExportService : IExportService
    {
        private readonly IConfiguration _configuration;
        public ExportService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void ExportToWord(ExportValuesDto data)
        {
            try
            {
                string templatePath = data.TemplatePath;
                string outputPath = data.OutputPath;

                File.Copy(templatePath, outputPath, true);

                using (WordprocessingDocument document = WordprocessingDocument.Open(outputPath, true))
                {
                    ReplaceTextInPart(document.MainDocumentPart, "#LeiloeiroNome", data.LeiloeiroNome);
                    ReplaceTextInPart(document.MainDocumentPart, "#LeiloeiroTipo", data.LeiloeiroTipo);
                    ReplaceTextInPart(document.MainDocumentPart, "#Jucesp", data.Jucesp);
                    ReplaceTextInPart(document.MainDocumentPart, "#ComercialTelefone", data.ComercialTelefone);
                    ReplaceTextInPart(document.MainDocumentPart, "#PessoalTelefone", data.PessoalTelefone);
                    ReplaceTextInPart(document.MainDocumentPart, "#Rg", data.Rg);
                    ReplaceTextInPart(document.MainDocumentPart, "#Cpf", data.Cpf);
                    ReplaceTextInPart(document.MainDocumentPart, "#CidadeResidencialJunta", data.CidadeResidencialJunta);
                    ReplaceTextInPart(document.MainDocumentPart, "#ResidencialJuntaEndereco", data.ResidencialJuntaEndereco);
                    ReplaceTextInPart(document.MainDocumentPart, "#ResidencialJuntaNumero", data.ResidencialJuntaNumero);
                    ReplaceTextInPart(document.MainDocumentPart, "#BairroResidencialJunta", data.BairroResidencialJunta);
                    ReplaceTextInPart(document.MainDocumentPart, "#CepResidencialJunta", data.CepResidencialJunta);
                    ReplaceTextInPart(document.MainDocumentPart, "#RicoEmail", data.RicoEmail);
                    ReplaceTextInPart(document.MainDocumentPart, "#ComercialEndereco", data.ComercialEndereco);
                    ReplaceTextInPart(document.MainDocumentPart, "#ComercialNumero", data.ComercialNumero);
                    ReplaceTextInPart(document.MainDocumentPart, "#ComplementoComercial", data.ComplementoComercial);
                    ReplaceTextInPart(document.MainDocumentPart, "#BairroComercial", data.BairroComercial);
                    ReplaceTextInPart(document.MainDocumentPart, "#CidadeComercial", data.CidadeComercial);
                    ReplaceTextInPart(document.MainDocumentPart, "#ComercialUf", data.ComercialUf);
                    ReplaceTextInPart(document.MainDocumentPart, "#CepComercial", data.CepComercial);
                    ReplaceTextInPart(document.MainDocumentPart, "#Site", data.Site);
                    ReplaceTextInPart(document.MainDocumentPart, "#PessoalEmail", data.PessoalEmail);

                    foreach (HeaderPart headerPart in document.MainDocumentPart.HeaderParts)
                    {
                        ReplaceTextInPart(headerPart, "TextoOriginal", "Este é o novo texto para o cabeçalho.");
                        ReplaceTextInPart(headerPart, "#LeiloeiroNome", data.LeiloeiroNome);
                        ReplaceTextInPart(headerPart, "#LeiloeiroTipo", data.LeiloeiroTipo);
                        ReplaceTextInPart(headerPart, "#Jucesp", data.Jucesp);
                        ReplaceTextInPart(headerPart, "#ComercialTelefone", data.ComercialTelefone);
                        ReplaceTextInPart(headerPart, "#PessoalTelefone", data.PessoalTelefone);
                        ReplaceTextInPart(headerPart, "#Rg", data.Rg);
                        ReplaceTextInPart(headerPart, "#Cpf", data.Cpf);
                        ReplaceTextInPart(headerPart, "#CidadeResidencialJunta", data.CidadeResidencialJunta);
                        ReplaceTextInPart(headerPart, "#ResidencialJuntaEndereco", data.ResidencialJuntaEndereco);
                        ReplaceTextInPart(headerPart, "#ResidencialJuntaNumero", data.ResidencialJuntaNumero);
                        ReplaceTextInPart(headerPart, "#BairroResidencialJunta", data.BairroResidencialJunta);
                        ReplaceTextInPart(headerPart, "#CepResidencialJunta", data.CepResidencialJunta);
                        ReplaceTextInPart(headerPart, "#RicoEmail", data.RicoEmail);
                        ReplaceTextInPart(headerPart, "#ComercialEndereco", data.ComercialEndereco);
                        ReplaceTextInPart(headerPart, "#ComercialNumero", data.ComercialNumero);
                        ReplaceTextInPart(headerPart, "#ComplementoComercial", data.ComplementoComercial);
                        ReplaceTextInPart(headerPart, "#BairroComercial", data.BairroComercial);
                        ReplaceTextInPart(headerPart, "#CidadeComercial", data.CidadeComercial);
                        ReplaceTextInPart(headerPart, "#ComercialUf", data.ComercialUf);
                        ReplaceTextInPart(headerPart, "#CepComercial", data.CepComercial);
                        ReplaceTextInPart(headerPart, "#Site", data.Site);
                        ReplaceTextInPart(headerPart, "#PessoalEmail", data.PessoalEmail);
                    }

                    foreach (FooterPart footerPart in document.MainDocumentPart.FooterParts)
                    {
                        ReplaceTextInPart(footerPart, "TextoOriginal", "Este é o novo texto para o cabeçalho.");
                        ReplaceTextInPart(footerPart, "#LeiloeiroNome", data.LeiloeiroNome);
                        ReplaceTextInPart(footerPart, "#LeiloeiroTipo", data.LeiloeiroTipo);
                        ReplaceTextInPart(footerPart, "#Jucesp", data.Jucesp);
                        ReplaceTextInPart(footerPart, "#ComercialTelefone", data.ComercialTelefone);
                        ReplaceTextInPart(footerPart, "#PessoalTelefone", data.PessoalTelefone);
                        ReplaceTextInPart(footerPart, "#Rg", data.Rg);
                        ReplaceTextInPart(footerPart, "#Cpf", data.Cpf);
                        ReplaceTextInPart(footerPart, "#CidadeResidencialJunta", data.CidadeResidencialJunta);
                        ReplaceTextInPart(footerPart, "#ResidencialJuntaEndereco", data.ResidencialJuntaEndereco);
                        ReplaceTextInPart(footerPart, "#ResidencialJuntaNumero", data.ResidencialJuntaNumero);
                        ReplaceTextInPart(footerPart, "#BairroResidencialJunta", data.BairroResidencialJunta);
                        ReplaceTextInPart(footerPart, "#CepResidencialJunta", data.CepResidencialJunta);
                        ReplaceTextInPart(footerPart, "#RicoEmail", data.RicoEmail);
                        ReplaceTextInPart(footerPart, "#ComercialEndereco", data.ComercialEndereco);
                        ReplaceTextInPart(footerPart, "#ComercialNumero", data.ComercialNumero);
                        ReplaceTextInPart(footerPart, "#ComplementoComercial", data.ComplementoComercial);
                        ReplaceTextInPart(footerPart, "#BairroComercial", data.BairroComercial);
                        ReplaceTextInPart(footerPart, "#CidadeComercial", data.CidadeComercial);
                        ReplaceTextInPart(footerPart, "#ComercialUf", data.ComercialUf);
                        ReplaceTextInPart(footerPart, "#CepComercial", data.CepComercial);
                        ReplaceTextInPart(footerPart, "#Site", data.Site);
                        ReplaceTextInPart(footerPart, "#PessoalEmail", data.PessoalEmail);
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private static void ReplaceTextInPart(OpenXmlPart part, string search, string replace)
        {
            foreach (var text in part.RootElement.Descendants<Text>())
            {
                if (text.Text.Contains(search))
                {
                    text.Text = text.Text.Replace(search, replace);
                }
            }
        }
    }
}
