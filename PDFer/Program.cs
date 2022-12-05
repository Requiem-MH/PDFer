// See https://aka.ms/new-console-template for more information

using iText;
using iText.Kernel.Pdf;
using iText.Layout;
using PDFer;

ReportCard rc = new ReportCard("/Users/michaelharrop/Projects/Work/8 - North Cache.pdf.pdf",
    "/Users/michaelharrop/Projects/Work/Split");

PdfDocument pdfDoc = new PdfDocument(new PdfReader(rc.Source), new PdfWriter(rc.Destination));
Document document = new Document(pdfDoc);

pdfDoc.AddPage(rc.GetPage(1));
