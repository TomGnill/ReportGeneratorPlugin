using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportGeneratorPlugin.Core.Models;

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

        public void CreateDocFile()
        {

        }
    }
}
