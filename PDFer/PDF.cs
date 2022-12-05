using IronPdf;

namespace PDFer;
abstract class PDF
{
    protected string Path { get; }
    protected string Source { get; }
    protected string Destination { get; }
    protected PdfDocument Pdf { get; }
    protected int Pages { get; }

    public PDF(string source, string destination)
    {
        this.Path = System.IO.Path.GetDirectoryName(source);
        this.Source = source;
        this.Destination = destination;
        this.Pdf = PdfDocument.FromFile(source);
        this.Pages = Pdf.PageCount;
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