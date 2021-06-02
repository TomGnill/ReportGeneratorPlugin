namespace ReportGeneratorPlugin.UI.Generator
{
   public class FileModel 
   { public string Name { get; set; }
        public string Content { get; set; }

        public FileModel(string name, string content)
        {
            Name = name;
            Content = content;
        }
    }
}
