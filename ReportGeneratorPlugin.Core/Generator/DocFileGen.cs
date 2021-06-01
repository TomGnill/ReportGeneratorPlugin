using System.Collections.Generic;
using ReportGeneratorPlugin.Core.Models;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace ReportGeneratorPlugin.Core.Generator
{
    public class DocFileGen
    {
        public List<FileModel> Files { get; set; }
        public string Introduction { get; set; }
        public string Conclusion { get; set; }

        public DocFileGen(List<FileModel> files, string introduction, string conclusion)
        {
            Files = files;
            Introduction = introduction;
            Conclusion = conclusion;
        }

        public void CreateDocFile(string path)
        {
            if (path.EndsWith(".pdf"))
            {
                path = path.Replace(".pdf", ".docx");
            }
            DocX document = DocX.Create(path, DocumentTypes.Document);

           foreach (var fileContent in Files)
           {
               document.InsertParagraph(fileContent.Name + ":")
                   .Font("Calibri")
                   .FontSize(18)
                   .Alignment = Alignment.center;
               document.InsertParagraph(fileContent.Content)
                   .Font("Calibri")
                   .FontSize(12)
                   .Alignment = Alignment.left;
           }

           document.Save();
        }

        public void CreatePdfFile(string path)
        {
            if (path.EndsWith(".docx"))
            {
                path = path.Replace(".docx", ".pdf");
            }
            DocX document = DocX.Create(path, DocumentTypes.Pdf);

            foreach (var fileContent in Files)
            {
                document.InsertParagraph(fileContent.Name + ":")
                    .Font("Calibri")
                    .FontSize(18)
                    .Alignment = Alignment.center;
                document.InsertParagraph(fileContent.Content)
                    .Font("Calibri")
                    .FontSize(12)
                    .Alignment = Alignment.left;
            }

            document.Save();

        }
    }
}
