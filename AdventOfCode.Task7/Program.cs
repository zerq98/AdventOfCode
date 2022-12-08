using AdventOfCode.Task7;

var lines = Logic.GetTextFromFile();
var directories = Logic.GetDirectoriesInfo(lines);
var sum = Logic.GetSumOfDirectoriesUnderOneHundred(directories);
Console.WriteLine("Sum of directories with total size < 100000: " + sum.ToString());
Console.WriteLine("Size of directory to delete: "+Logic.GetSizeOfDirectoryToDelete(directories));