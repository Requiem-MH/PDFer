// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using iText.IO.Font.Otf;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Layout.Element;
using PDFer;

Stopwatch watch = new System.Diagnostics.Stopwatch();
watch.Start();

string startPath = "/Users/michaelharrop/Projects/Work/";
string savePath = "/Users/michaelharrop/Projects/Work/Split/";

string[] pdfFiles = Directory.GetFiles(startPath, "*.pdf", SearchOption.TopDirectoryOnly);

foreach (string file in pdfFiles)
{
    ReportCard rc = new ReportCard(file, savePath);
    rc.Split();
}

watch.Stop();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds / 1000} sec");