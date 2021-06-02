using System.Collections.Generic;

namespace ReportGeneratorPlugin.UI.Generator
{
    public class ReportGenerator
    {
        public string DocPath { get; set; }

        public ReportGenerator(string path)
        {
            DocPath = path;
        }
        public void GenerateReport(string path, string сonclusion, string introdaction, List<string> filters, bool isPdf)
        {
            DocFileGen gen = new DocFileGen(new SourceFileProvider(path, filters).GetFiles(), introdaction, сonclusion);
            if(!isPdf)
                gen.CreateDocFile(DocPath);
            else
            
                gen.CreatePdfFile(DocPath);
            
        }
    }
}
