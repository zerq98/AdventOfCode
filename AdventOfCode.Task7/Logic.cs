using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Task7
{
    public static class Logic
    {
        public static List<string> GetTextFromFile()
        {
            return File.ReadAllLines("InputFile.txt").ToList();
        }

        public static List<Directory> GetDirectoriesInfo(List<string> lines)
        {
            var directories = new List<Directory>
            {
                new Directory
                {
                    Id = Guid.NewGuid().ToString(),
                    Name="/",
                    ParentDirName="",
                    ParentDirId="",
                    FilesSize = 0,
                    FolderContainingSize=0,
                    CountOfFolders=0
                }
            };
            var activeDirectory = directories[0];
            var activeDirectoryIndex = 0;
            lines = lines.Skip(1).ToList();
            foreach (var line in lines)
            {
                if (line.StartsWith("$ cd"))
                {
                    var split = line.Split(" ");
                    if (split[2] == "..")
                    {
                        var dir = directories.FirstOrDefault(x => x.Id == activeDirectory.ParentDirId);
                        activeDirectory = dir;
                        activeDirectoryIndex = directories.IndexOf(dir);
                        var folders = directories.Where(x => x.ParentDirId == activeDirectory.Id).ToList();
                        directories[activeDirectoryIndex].FolderContainingSize=folders.Any()?folders.Sum(x=>x.TotalSize):0;
                    }
                    else
                    {
                        var dir = directories.FirstOrDefault(x => x.Name == split[2] && x.ParentDirId == activeDirectory.Id);
                        if (dir == null)
                        {
                            dir = new Directory
                            {
                                Name = split[2],
                                ParentDirName = activeDirectory.Name,
                                ParentDirId=activeDirectory.Id,
                                Id = Guid.NewGuid().ToString(),
                                CountOfFolders=0,
                                FilesSize = 0,
                                FolderContainingSize=0
                            };
                            directories.Add(dir);
                        }
                        activeDirectory = dir;
                        activeDirectoryIndex = directories.IndexOf(dir);
                    }
                }
                else if (line.StartsWith("$ ls"))
                {
                    continue;
                }
                else
                {
                    var split = line.Split(" ");
                    if (split[0] == "dir")
                    {
                        directories.Add(new Directory
                        {
                            Name = split[1],
                            ParentDirName = activeDirectory.Name,
                            ParentDirId = activeDirectory.Id,
                            Id = Guid.NewGuid().ToString(),
                            FilesSize = 0,
                            FolderContainingSize = 0
                        });
                    }
                    else
                    {
                        activeDirectory.FilesSize += Convert.ToInt32(split[0]);
                    }
                }
            }

            var parent = directories.FirstOrDefault(x => x.Id == activeDirectory.ParentDirId);
            var parentIndex = directories.IndexOf(parent);
            CalculateSum(parentIndex, directories);

            return directories;
        }

        private static void CalculateSum(int index,List<Directory> directories)
        {
            var parent = directories[index].ParentDirId;
            var folders = directories.Where(x => x.ParentDirId == directories[index].Id).ToList();
            directories[index].FolderContainingSize = folders.Any() ? folders.Sum(x => x.TotalSize) : 0;
            if (parent == "") return;
            var parentDir = directories.FirstOrDefault(x => x.Id == directories[index].ParentDirId);
            var parentIndex = directories.IndexOf(parentDir);
            CalculateSum(parentIndex, directories);
        }

        internal static int GetSumOfDirectoriesUnderOneHundred(List<Directory> directories)
        {
            return directories.Where(x => x.TotalSize < 100000).Sum(x => x.TotalSize);
        }

        public static int GetSizeOfDirectoryToDelete(List<Directory> directories)
        {
            var directoriesToDelete = new List<Directory>();
            var totalSpace = 70000000;
            var neededSpace = 30000000;
            var currentAvailableSpace = totalSpace - directories[0].TotalSize;
            var spaceNeededToBeFreedUp = neededSpace - currentAvailableSpace;
            foreach (var directory in directories)
            {
                if (spaceNeededToBeFreedUp <= directory.TotalSize)
                {
                    directoriesToDelete.Add(directory);
                }
            }

            directoriesToDelete = directoriesToDelete.OrderBy(x => x.TotalSize).ToList();
            return directoriesToDelete.FirstOrDefault().TotalSize;
        }
    }
}
