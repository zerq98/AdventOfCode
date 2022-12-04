
using AdventOfCode.Task2;

var lines = Logic.GetLinesFromFile();
var result = Logic.CalculateAllGamesResult(lines,false);
var expectedResult = Logic.CalculateAllGamesResult(lines, true);
Console.WriteLine("Result of games if everything went good: "+result.ToString());
Console.WriteLine("Result of games if file contains expectedResult: " + expectedResult.ToString());