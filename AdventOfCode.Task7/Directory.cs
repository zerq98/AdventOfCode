using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Task7
{
    public class Directory
    {
        public string ParentDirName { get; set; }
        public string Id { get; set; }
        public string ParentDirId { get; set; }
        public string Name { get; set; }
        public int TotalSize
        {
            get
            {
                return FilesSize + FolderContainingSize;
            }
        }

        public int FolderContainingSize { get; set; }
        public int FilesSize { get; set; }
        public int CountOfFolders { get; internal set; }
    }
}
