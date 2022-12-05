using System.Collections.Generic;
using iText.Kernel.Pdf;
using iText.Layout.Element;

namespace PDFer;
public class ReportCard : PDF
{
    private string GenericName = "_Report Card 2022-2023 Grade 11 Cooper Adams";
    public Dictionary<int, PdfDocument> ExtractedPdfs = new Dictionary<int, PdfDocument>();

    public ReportCard(string source, string destination) : base(source, destination) {}

    public override void Save()
    {
        throw new NotImplementedException();
    }

    public override void Extract()
    {
        throw new NotImplementedException();
    }
}