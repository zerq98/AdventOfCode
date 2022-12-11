using AdventOfCode.Task11;

var monkeys = Logic.GetDataFromInputFile();
var inspectTimes = Logic.GetTwoMostInspectTimes(monkeys,true,20);
Console.WriteLine("The level of monkey business after 20 rounds of stuff-slinging simian shenanigans: " + (inspectTimes[0] * inspectTimes[1]).ToString());

monkeys = Logic.GetDataFromInputFile();
inspectTimes = Logic.GetTwoMostInspectTimes(monkeys,false,10000);
long calcValue = (Convert.ToInt64(inspectTimes[0]) * Convert.ToInt64(inspectTimes[1]));
Console.WriteLine("The level of monkey business after 10000 rounds of stuff-slinging simian shenanigans: " + calcValue.ToString());