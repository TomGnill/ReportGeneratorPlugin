using System.Collections.Generic;

namespace ReportGeneratorPlugin.UI.Generator
{
    public class ReportGenerator
    {
        public string docPath { get; set; }

        public ReportGenerator(string path)
        {
            docPath = path;
        }
        public void GenerateReport(string path, string conlution, string introdaction, List<string> filters)
        {
            UI.Generator.DocFileGen gen = new UI.Generator.DocFileGen(new SourceFileProvider(path, filters).GetFiles(), introdaction, conlution);
            gen.CreateDocFile(docPath);
        }
    }
}
