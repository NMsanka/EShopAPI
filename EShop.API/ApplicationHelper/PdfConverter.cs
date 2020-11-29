using EShop.API.Models;
using SelectPdf;
using System.IO;
using System.Web.Configuration;

namespace EShop.API
{
    public static class PdfConverter
    {
        public static void ConvertHtmlCodeToPdf(PdfModel model)
        {
            HtmlToPdf converter = new HtmlToPdf();            

            if (model.HeaderUrl != null)
            {
                // header settings
                converter.Options.DisplayHeader = true;
                converter.Header.DisplayOnFirstPage = true;
                converter.Header.DisplayOnOddPages = true;
                converter.Header.DisplayOnEvenPages = true;
                converter.Header.Height = 70;

                // add some html content to the header
                PdfHtmlSection headerHtml = new PdfHtmlSection(model.HeaderUrl);
                headerHtml.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
                headerHtml.AutoFitWidth = HtmlToPdfPageFitMode.AutoFit; 
                converter.Header.Add(headerHtml);
            }

            if (model.FooterUrl != null)
            {
                // footer settings
                converter.Options.DisplayFooter = true;
                converter.Footer.DisplayOnFirstPage = true;
                converter.Footer.DisplayOnOddPages = true;
                converter.Footer.DisplayOnEvenPages = true;
                converter.Footer.Height = 50;

                // add some html content to the footer
                PdfHtmlSection footerHtml = new PdfHtmlSection(model.FooterUrl,"");
                footerHtml.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
                converter.Footer.Add(footerHtml);
            }            

            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            converter.Options.MarginLeft = 10;
            converter.Options.MarginRight = 10;
            converter.Options.MarginTop = 20;
            converter.Options.MarginBottom = 20;

            PdfDocument doc = converter.ConvertHtmlString(model.HtmlString, null);

            doc.Save(model.RepositoryPath);
            doc.Close();


        }

        public static void ConvertContractHtmlCodeToPdf(PdfModel model)
        {
            HtmlToPdf converter = new HtmlToPdf();

            if (model.HeaderUrl != null)
            {
                // header settings
                converter.Options.DisplayHeader = true;
                converter.Header.DisplayOnFirstPage = true;
                converter.Header.DisplayOnOddPages = true;
                converter.Header.DisplayOnEvenPages = true;
                converter.Header.Height = 70;

                // add some html content to the header
                PdfHtmlSection headerHtml = new PdfHtmlSection(model.HeaderUrl);
                headerHtml.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
                headerHtml.AutoFitWidth = HtmlToPdfPageFitMode.AutoFit;
                converter.Header.Add(headerHtml);
            }

            if (model.FooterUrl != null)
            {
                // footer settings
                converter.Options.DisplayFooter = true;
                converter.Footer.DisplayOnFirstPage = true;
                converter.Footer.DisplayOnOddPages = true;
                converter.Footer.DisplayOnEvenPages = true;
                converter.Footer.Height = 60;

                // add some html content to the footer
                PdfHtmlSection footerHtml = new PdfHtmlSection(model.FooterUrl, "");
                footerHtml.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
                converter.Footer.Add(footerHtml);

                PdfTextSection text = new PdfTextSection(0, 10, "Page: {page_number} of {total_pages}  ", new System.Drawing.Font("Arial", 8));
                text.HorizontalAlign = PdfTextHorizontalAlign.Right;
                converter.Footer.Add(text);
            }
            
            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            converter.Options.MarginLeft = 30;
            converter.Options.MarginRight = 30;
            converter.Options.MarginTop = 20;
            converter.Options.MarginBottom = 25;

            PdfDocument doc= converter.ConvertHtmlString(model.HtmlString);
            
            doc.Save(model.RepositoryPath);
            doc.Close();
        }

        public static void ConvertUrlToPdf(string url)
        {
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(url);

            // save pdf document
            doc.Save(null, false, "Sample.pdf");

            // close pdf document
            doc.Close();
        }

        public static void ConvertHtmlStringToPdf(PdfModel model)
        {
            // Render any HTML fragment or document to HTML
            var Renderer = new IronPdf.HtmlToPdf();

            Renderer.PrintOptions.PaperSize = IronPdf.PdfPrintOptions.PdfPaperSize.A4;
            Renderer.PrintOptions.PaperOrientation = IronPdf.PdfPrintOptions.PdfPaperOrientation.Portrait;
            Renderer.PrintOptions.MarginTop = 10;  //millimeters
            Renderer.PrintOptions.MarginBottom = 10; //millimeters
            Renderer.PrintOptions.MarginLeft = 10;  //millimeters
            Renderer.PrintOptions.MarginRight = 10; //millimeters
            Renderer.PrintOptions.CssMediaType = IronPdf.PdfPrintOptions.PdfCssMediaType.Print;
            Renderer.PrintOptions.Header = new IronPdf.SimpleHeaderFooter()
            {
                DrawDividerLine = true,
                FontSize = 16
            };


            string source = model.HtmlString;
            var pdf = Renderer.RenderHtmlAsPdf(source);

            if (!Directory.Exists(model.Directory))
                Directory.CreateDirectory(model.Directory);

            pdf.SaveAs(model.RepositoryPath);

            // This neat trick opens our PDF file so we can see the result in our default PDF viewer
            // System.Diagnostics.Process.Start(model.RepositoryPath);

        }
    }


}