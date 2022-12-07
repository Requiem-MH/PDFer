using System.Collections.Generic;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using Exception = System.Exception;

namespace PDFer;
public class ReportCard : PDF
{
    private string _genericName = "_Report Card 2022-2023 Grade";
    // public Dictionary<int, PdfDocument> ExtractedPdfs = new Dictionary<int, PdfDocument>();

    public ReportCard(string source, string destination) : base(source, destination) {}

    public override void Save(List<int> pages, string name)
    {
        try
        {
            //Create save directory if it doesn't exist
            if (!Directory.Exists(Destination))
            {
                DirectoryInfo di = Directory.CreateDirectory(Destination);
                Console.WriteLine("The save directory was created.");
            }
            
            //Save pages from source file to destination file
            PdfDocument destDoc = new PdfDocument(new PdfWriter(Destination + name).SetSmartMode(true));
            PdfDocu.CopyPagesTo(pages, destDoc);
            destDoc.Close();
            
            Console.WriteLine($"File saved: {name}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"The process failed while trying to save, please try again. Error: {e}");
        }
    }

    public override void Split()
    {
        string prevStudentId = null;
        string prevStudentName = null;
        string prevStudentGrade = null;

        List<int> savePageList = new List<int>();
        
        foreach (int page in Enumerable.Range(1, 5))
        {
            string pageText = GetPageText(page);
            
            //Skip Blank Pages
            if (String.IsNullOrEmpty(pageText))
            {
                Console.WriteLine($"Page {page} is a blank page, skipping.");
                continue;
            }

            string studentId = Search(pageText, @"StudentID:\s*(\d\d\d\d\d\d\d\d\d)");
            string studentName = Search(pageText, @"Student Name:\s*(\D*)[ \t]+");
            string studentGrade = Search(pageText, @"Grade:\s*(\d*)");
            
            if (!String.IsNullOrEmpty(studentId) && prevStudentId != studentId) // Start new PDF output
            {
                if (prevStudentId is not null)
                {
                    // New student, save output and start new output
                    Save(savePageList, $"{prevStudentId}{_genericName} {prevStudentGrade} {prevStudentName}.pdf");
                    savePageList.Clear();
                }
                
                prevStudentId = studentId;
                prevStudentName = String.IsNullOrEmpty(studentId) ? $"Page {page}" : studentName;
                prevStudentGrade = studentGrade;
            }
            
            //Add page to output PDF
            savePageList.Add(page);
        }
        
        // Save output at end of file
        Save(savePageList, $"{prevStudentId}{_genericName} {prevStudentGrade} {prevStudentName}.pdf");
    }
}