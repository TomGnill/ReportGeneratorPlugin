using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using ReportGeneratorPlugin.Core.Models;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

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
            WordprocessingDocument doc = WordprocessingDocument.Create(path, WordprocessingDocumentType.Document);

            Body body = doc.MainDocumentPart.Document.Body;

            Paragraph para = body.AppendChild(new Paragraph());
            Run run = para.AppendChild(new Run());
            run.AppendChild(new Text(Files[0].Content));
            doc.Close();
        }
    }
}
