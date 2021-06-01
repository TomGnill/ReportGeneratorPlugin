using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGeneratorPlugin.Core.Generator
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
            DocFileGen gen = new DocFileGen(new SourceFileProvider(path, filters).GetFiles(), introdaction, conlution);
            gen.CreateDocFile(docPath);
        }
    }
}
