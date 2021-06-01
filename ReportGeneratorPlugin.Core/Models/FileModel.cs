﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGeneratorPlugin.Core.Models
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