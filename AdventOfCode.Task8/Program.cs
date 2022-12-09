using AdventOfCode.Task8;

var lines = Logic.GetTextFromFile();
var grid = Logic.GenerateGrid(lines);
var numberOfVisualTrees = Logic.GetNumberOfVisibleTrees(grid);
Console.WriteLine("Number of visible trees: "+numberOfVisualTrees.ToString());
var bestVisionScore = Logic.GetBestPositionsOfVisibleTrees(grid);
Console.WriteLine("Best vision score: " + bestVisionScore.ToString());