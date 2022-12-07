// See https://aka.ms/new-console-template for more information

using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Layout.Element;
using PDFer;

ReportCard rc = new ReportCard("/Users/michaelharrop/Projects/Work/Test.pdf",
    "/Users/michaelharrop/Projects/Work/Split/");

rc.Split();

List<int> test = new List<int>();
// Console.WriteLine(rc.GetPageText(110));
// Console.WriteLine(rc.GetPageText(2));
// Console.WriteLine(rc.GetPageText(2));

// Console.WriteLine(rc.GetPagesText(1, 2));
// Console.WriteLine(rc.GetPagesText(1, 2));
