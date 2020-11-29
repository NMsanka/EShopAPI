using SelectPdf;
using System.Web;

namespace EShop.API.Models
{
    public class PdfModel
    {
        public PdfModel()
        {
            PdfPageOrientation = PdfPageOrientation.Portrait;
            MarginLeft = 10;
            MarginRight = 10;
            MarginTop = 20;
            MarginBottom = 20;
            HeaderHight = 50;
            FooterHight = 50; 
        }
        
        public string RepositoryPath { get; set; }

        public string Directory { get; set; }

        public string RepositoryUrl { get; set; }

        public string HtmlString { get; set; }

        public PdfPageOrientation PdfPageOrientation { get; set; }

        public int MarginLeft { get; set; }

        public int MarginRight { get; set; }

        public int MarginTop { get; set; }

        public int MarginBottom { get; set; }

        public HttpResponse Response { get; set; }

        public string HeaderUrl { get; set; }

        public bool IsShowHeaderOnFirstPage { get; set; }

        public bool IsShowHeaderOnOddPages { get; set; }

        public bool IsShowHeaderOnEvenPages { get; set; }

        public int HeaderHight { get; set; }

        public string FooterUrl { get; set; }

        public bool IsShowFooterOnFirstPage { get; set; }

        public bool IsShowFooterOnOddPages { get; set; }

        public bool IsShowFooterOnEvenPages { get; set; }

        public int FooterHight { get; set; }
    }
}