using System.Text;
using System.Text.RegularExpressions;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

namespace PDFer;
public abstract class PDF
{
    private string _path;
    private string _src;
    private string _dest;
    private PdfReader _pdfRdr;
    private PdfDocument _pdfDocu;

    public PDF(string src, string dest)
    {
        _path = System.IO.Path.GetDirectoryName(src);
        _src = src;
        _dest = dest; 
        _pdfRdr = new PdfReader(_src);
        _pdfDocu = new PdfDocument(_pdfRdr);
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

    public PdfReader PdfRdr
    {
        get { return _pdfRdr; }
    }
    
    public PdfDocument PdfDocu
    {
        get { return _pdfDocu; }
    }

    public int PageCount
    {
        get { return _pdfDocu.GetNumberOfPages();  }
    }

    public string GetPageText(int x)
    {
        LocationTextExtractionStrategy strategy = new LocationTextExtractionStrategy();
        var page = _pdfDocu.GetPage(x);
        string text = PdfTextExtractor.GetTextFromPage(page, strategy);
        return text;
    }
    
    public string GetPagesText(int x, int y)
    {
        StringBuilder text = new StringBuilder();
        
        for (int i = x; i <= y; i++)
        {
            LocationTextExtractionStrategy strategy = new LocationTextExtractionStrategy();
            var page = _pdfDocu.GetPage(i);
            text.Append(PdfTextExtractor.GetTextFromPage(page, strategy) + "\n");
        }
        
        return text.ToString();
        
    }

    public string Search(string text, string pattern)
    {
        Regex r = new Regex(pattern);
        Match m = r.Match(text);
        Group g = m.Groups[1];

        return g.ToString();
    }

    public abstract void Save(List<int> pages, string name);
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