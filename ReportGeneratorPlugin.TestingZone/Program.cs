using System;
using System.Collections.Generic;
using ReportGeneratorPlugin.Core.Generator;

namespace ReportGeneratorPlugin.TestingZone
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
            generator.GenerateReport(@"C:\Users\andri\source\repos\NYSS_CourseWork.Server","какое-то заключение", "какое-то вступление",filter);
        }
    }
}
