using System.Text;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

namespace PDFer;
public abstract class PDF
{
    private string _path;
    private string _src;
    private string _dest;
    private PdfReader _pdfReader;
    private PdfDocument _pdfDocument;

    public PDF(string src, string dest)
    {
        _path = System.IO.Path.GetDirectoryName(src);
        _src = src;
        _dest = dest; 
        _pdfReader = new PdfReader(_src);
        _pdfDocument = new PdfDocument(_pdfReader);
    }

    public string Path
    {
        get { return _path; }
    }
    public string Source
    {
        get { return _src; }
    }
    public string Destination
    {
        get { return _dest; }
    }

    public PdfReader PdfReader
    {
        get { return _pdfReader; }
    }
    
    public PdfDocument PdfDocument
    {
        get { return _pdfDocument; }
    }

    public int PageCount
    {
        get { return _pdfDocument.GetNumberOfPages();  }
    }

    public string GetPageText(int x)
    {
        LocationTextExtractionStrategy strategy = new LocationTextExtractionStrategy();
        var page = _pdfDocument.GetPage(x);
        string text = PdfTextExtractor.GetTextFromPage(page, strategy);
        return text;
    }
    
    public string GetPagesText(int x, int y)
    {
        StringBuilder text = new StringBuilder();
        
        for (int i = x; i <= y; i++)
        {
            LocationTextExtractionStrategy strategy = new LocationTextExtractionStrategy();
            var page = _pdfDocument.GetPage(i);
            text.Append(PdfTextExtractor.GetTextFromPage(page, strategy) + "\n");
        }
        
        return text.ToString();
        
    }

    public abstract void Save();
    // {
    //     try
    //     {
    //         if (!Directory.Exists(Destination))
    //         {
    //             Directory.CreateDirectory(Destination);
    //         }
    //
    //         this.Pdf.SaveAs(Destination + "/" + fileName);
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine("The process failed; {0}", e.ToString());
    //     }
    // }
    
    public abstract void Split();
}