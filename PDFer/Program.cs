// See https://aka.ms/new-console-template for more information

using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using PDFer;

ReportCard rc = new ReportCard("/Users/michaelharrop/Projects/Work/8 - North Cache.pdf",
    "/Users/michaelharrop/Projects/Work/Split/Test.pdf");

// rc.Split();
// Console.WriteLine(rc.GetPageText(1172));
// Console.WriteLine(rc.GetPageText(2));

Console.WriteLine(rc.GetPagesText(1, 2));
