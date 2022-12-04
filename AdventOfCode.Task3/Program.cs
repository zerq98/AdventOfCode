using AdventOfCode.Task3;

var lines = Logic.GetLinesFromFile();
var rucksacks = Logic.GetRucksacks(lines);
var items = Logic.GetAllRepeatedItems(rucksacks);
var repeated = Logic.CalculateSumOfRepeatedItems(items);
Console.WriteLine("Sum of repeated items: " + repeated.ToString());

var groups = Logic.GetGroups(lines);
var groupItems = Logic.GetAllRepeatedItems(groups);
repeated = Logic.CalculateSumOfRepeatedItems(groupItems);
Console.WriteLine("Sum of repeated group items: " + repeated.ToString());
