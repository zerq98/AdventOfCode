using AdventOfCode.Task1;

var lines = Logic.GetLinesFromFile();
var calories = Logic.GetCaloriesSum(lines);
var highestCalories = Logic.GetMaxCalories(calories);
var top3 = Logic.GetSumOfTopThree(calories);
Console.WriteLine("Elf with most calories in snacks: "+highestCalories.ToString());
Console.WriteLine("Sum of top 3 calories in snacks: " + top3.ToString());