using System.Collections.Generic;
using iText.Kernel.Pdf;

namespace PDFer;
public class ReportCard : PDF
{
    private string GenericName = "_Report Card 2022-2023 Grade 11 Cooper Adams";
    // public Dictionary<int, PdfDocument> ExtractedPdfs = new Dictionary<int, PdfDocument>();

    public ReportCard(string source, string destination) : base(source, destination) {}

    public override void Save()
    {
        throw new NotImplementedException();
    }

    public override void Split()
    {
        // foreach (int page in Enumerable.Range(1, PageCount))
        foreach (int page in Enumerable.Range(1, 5))
        {
            string pageText = GetPageText(page);

            if (!String.IsNullOrEmpty(pageText))
            {
                Console.WriteLine($"Page {page}: Report Card");
            }
            else
            {
                Console.WriteLine($"Page {page}: Blank Page");
            }

        }
    }
}