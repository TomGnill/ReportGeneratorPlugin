using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportGeneratorPlugin.Core.Generator;

namespace ReportGeneratorPlugin.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            ReportGenerator generator = new ReportGenerator("C:\\test\\test.docx");
            var filter = new List<string>()
            {
                ".cs", ".xaml"
            };
            generator.GenerateReport(@"C:\Users\andri\source\repos\NYSS_CourseWork.Server", "какое-то заключение", "какое-то вступление", filter);

        }
    }
}
