using iText;
using iText.Kernel.Pdf;

namespace PDFer;
public abstract class PDF
{
    private string _path;
    private string _src;
    private string _dest;
    private PdfDocument _pdf;

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

    public PdfDocument Pdf
    {
        get { return _pdf; }
    }

    public int NumberOfPages
    {
        get { return _pdf.GetNumberOfPages();  }
    }

    public PDF(string src, string dest)
    {
        this._path = System.IO.Path.GetDirectoryName(src);
        this._src = src;
        this._dest = dest;
        this._pdf = new PdfDocument (new PdfReader(src));
    }

    public PdfPage GetPage(int x)
    {
        return this._pdf.GetPage(x);
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
    
    public abstract void Extract();
}