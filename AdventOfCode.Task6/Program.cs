using AdventOfCode.Task6;

var input = Logic.GetTextFromFile();
var marker = Logic.GetMarker(input,4);
Console.WriteLine("Chars before marker: " + marker);
marker = Logic.GetMarker(input, 14);
Console.WriteLine("Chars before message: " + marker);