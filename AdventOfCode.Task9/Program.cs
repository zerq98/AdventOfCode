using AdventOfCode.Task9;

var lines = Logic.GetTextFromFile();
var sizes = Logic.CalculateStartPointAndSize(lines);
var count = Logic.CalculateCountOfTailPosition(sizes,lines);
Console.WriteLine("Number of fields visited by tail: "+count.ToString());
count = Logic.CalculateCountOfNinthTailPosition(sizes, lines);
Console.WriteLine("Number of fields visited by ninth tail: " + count.ToString());