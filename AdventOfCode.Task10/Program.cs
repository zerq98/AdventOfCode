using AdventOfCode.Task10;

var lines = Logic.GetLinesFromFile();
var sum = Logic.CalcualateCycles(lines);
Console.WriteLine("Sum of signal strentgths: " + sum.ToString());