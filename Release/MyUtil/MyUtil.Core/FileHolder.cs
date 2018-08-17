using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUtil.Core
{
    public class FileHolder
    {
        public MemoryStream Content { get; set; }
        public string FileName { get; set; }

        public FileHolder() { }

        public FileHolder(MemoryStream content, string fileName)
        {
            this.Content = content;
            this.FileName = fileName;
        }
    }
}
