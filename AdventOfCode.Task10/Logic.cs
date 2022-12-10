using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Task10
{
    public static class Logic
    {
        public static List<string> GetLinesFromFile()
        {
            var text = File.ReadAllLines("InputFile.txt");
            return text.ToList();
        }

        public static int CalcualateCycles(List<string> lines)
        {
            List<int> pointsOfSave = new() { 20, 60, 100, 140, 180, 220 };
            List<int> lineBreaks = new() { 40, 80, 120, 160, 240 };
            var sum = 0;
            var x = 1;
            var cycle = 0;
            var pointer = 0; ;
            foreach(var line in lines)
            {
                var split = line.Split(" ");
                if (split[0]== "addx")
                {
                    for(int i = 0; i<2; i++)
                    {
                        cycle++;
                        Console.Write(((x - 1) == pointer || x == pointer || (x + 1) == pointer) ? "#" : ".");
                        pointer++;
                        if (pointsOfSave.Contains(cycle))
                        {
                            sum += x * cycle;
                        }
                        if (lineBreaks.Contains(pointer))
                        {
                            pointer = 0;
                            Console.WriteLine();
                        }
                    }
                    x += Convert.ToInt32(split[1]);
                }
                else
                {
                    cycle++;
                    Console.Write(((x - 1) == pointer || x == pointer || (x + 1) == pointer) ? "#" : ".");
                    pointer++;
                    if (pointsOfSave.Contains(cycle))
                    {
                        sum += x*cycle;
                    }
                    if (lineBreaks.Contains(pointer))
                    {
                        pointer = 0;
                        Console.WriteLine();
                    }
                }
            }

            return sum;
        }
    }
}
