using System.Collections.Generic;
using System.IO;
using ReportGeneratorPlugin.Core.Models;
using System.Linq;
using System.Net.Sockets;

namespace ReportGeneratorPlugin.Core.Generator
{
    public class SourceFileProvider
    {
        public string RepositoryPath { get; set; }
        public List<string> Filters { get; set; }

        public  SourceFileProvider(string path, List<string> fileFilters)
        {
            RepositoryPath = path;
            Filters = fileFilters;
        }

        public List<FileModel> GetFiles()
        {
            var files = new List<FileModel>();

            foreach (var file in Directory.EnumerateFiles(RepositoryPath, "*", SearchOption.AllDirectories))
            {
                FileInfo info = new FileInfo(file);
                foreach (var fileType in Filters)
                {
                    if (info.Name.EndsWith(fileType))
                    {
                        files.Add(new FileModel(info.Name, File.ReadAllText(info.FullName)));
                    }
                }
            }
            return files;
        }
    }
}
