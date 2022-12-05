using AdventOfCode.Task5;

var items = Logic.GetLinesFromFile("InputFile.txt");
var instructions = Logic.GetLinesFromFile("Instructions.txt");
var cargos = Logic.GetCargos(items);
var movedCargos = Logic.MoveCargos(cargos, instructions,true);
var lastCargos = Logic.GetLastItemFromEachCargo(movedCargos);
Console.WriteLine("Last cargos: " + lastCargos);

cargos = Logic.GetCargos(items);
movedCargos = Logic.MoveCargos(cargos, instructions, false);
lastCargos = Logic.GetLastItemFromEachCargo(movedCargos);
Console.WriteLine("Last cargos without reversing: " + lastCargos);