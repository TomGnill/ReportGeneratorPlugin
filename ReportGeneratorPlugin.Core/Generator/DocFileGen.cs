using System;
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
            document.InsertParagraph("introduction:")
                .FontSize(15)
                .Alignment = Alignment.left;
            document.InsertParagraph($"{Introduction}")
                .FontSize(12)
                .Alignment = Alignment.left;

            foreach (var fileContent in Files)
            {

               document.InsertParagraph(fileContent.Name + ":")
                   .Font("Consolas")
                   .FontSize(14)
                   .Alignment = Alignment.center;
               Table table = document.AddTable(1, 1);
               table.Alignment = Alignment.center;
               table.Rows[0].Cells[0].Paragraphs[0]
                   .Append(fileContent.Content)
                   .FontSize(10.5)
                   .Font("Consolas");
               document.InsertTable(table);
            }
            document.InsertParagraph("Conclusion:")
               .FontSize(15)
               .Alignment = Alignment.left;
           document.InsertParagraph($"{Conclusion}")
               .FontSize(12)
               .Alignment = Alignment.left;
            document.Save();
        }

        public void CreatePdfFile(string path)
        {
            if (path.EndsWith(".docx"))
            {
                path = path.Replace(".docx", ".pdf");
            }
            DocX document = DocX.Create(path, DocumentTypes.Pdf);
            document.InsertParagraph("introduction:")
                .FontSize(15)
                .Alignment = Alignment.left;
            document.InsertParagraph($"{Introduction}")
                .FontSize(12)
                .Alignment = Alignment.left;
            foreach (var fileContent in Files)
            {
                document.InsertParagraph(fileContent.Name + ":")
                    .Font("Consolas")
                    .FontSize(18)
                    .Alignment = Alignment.center;
                Table table = document.AddTable(1, 1);
                table.Design = TableDesign.LightList;
                table.Alignment = Alignment.center;
                table.Rows[1].Cells[0].Paragraphs[0]
                    .Append(fileContent.Content)
                    .FontSize(10.5)
                    .Font("Consolas");
                document.InsertTable(table);
            }
            document.InsertParagraph("Conclusion:")
                .FontSize(15)
                .Alignment = Alignment.left;
            document.InsertParagraph($"{Conclusion}")
                .FontSize(12)
                .Alignment = Alignment.left;
            document.Save();

        }
    }
}
