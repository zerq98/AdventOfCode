using AdventOfCode.Task4;

var lines = Logic.GetLinesFromFile();
var boundings = Logic.GetRegionBounds(lines);
var pairs = Logic.GetNumerOfContainingPairs(boundings);
Console.WriteLine("Number of containing pairs: " + pairs.ToString());

pairs = Logic.GetNumerOfOverlapingPairs(boundings);
Console.WriteLine("Number of overlapping pairs: " + pairs.ToString());
