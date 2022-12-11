using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Task11
{
    public static class Logic
    {
        public static List<Monkey> GetDataFromInputFile()
        {
            var monkeys = new List<Monkey>();
            var lines = File.ReadAllLines("InputFile.txt");
            for(int i = 0; i < lines.Count(); i += 7)
            {
                var startingItems = lines[i + 1].Split(":").ToList()[1].Split(",").ToList().Select(x=>Convert.ToInt64(x)).ToList();
                var operation = lines[i + 2].Split("=")[1];
                var divider = Convert.ToInt32(lines[i + 3].Split("by")[1]);
                var ifTrue = Convert.ToInt32(lines[i + 4].Split("monkey")[1]);
                var ifFalse = Convert.ToInt32(lines[i + 5].Split("monkey")[1]);
                var newMonkey = new Monkey
                {
                    StartingItems = startingItems,
                    Operation = operation,
                    Divider = divider,
                    ThrowToNumbers = new List<int> { ifTrue, ifFalse }
                };
                monkeys.Add(newMonkey);
            }

            return monkeys;
        }

        public static List<int> GetTwoMostInspectTimes(List<Monkey> monkeys,bool lowWorryLevel,int numberOfRounds)
        {
            int commonDivider = monkeys.Select(x => x.Divider).Aggregate(1, (x, y) => x * y);

            for(int r = 0; r < numberOfRounds; r++)
            {
                foreach(var monkey in monkeys)
                {
                    for(int i = 0; i < monkey.StartingItems.Count(); i++)
                    {
                        monkey.InspectTimes++;
                        var item = Convert.ToInt64(new DataTable().Compute(monkey.Operation.Replace("old", $"{monkey.StartingItems[i]}.0"), ""));
                        if (lowWorryLevel)
                        {
                            item /= 3;
                        }
                        else
                        {
                            item %=commonDivider;
                        }
                        if (item % monkey.Divider == 0)
                        {
                            monkeys[monkey.ThrowToNumbers[0]].StartingItems.Add(item);
                        }
                        else
                        {
                            monkeys[monkey.ThrowToNumbers[1]].StartingItems.Add(item);
                        }
                    }

                    monkey.StartingItems = new List<long>();
                }
            }

            return monkeys.OrderByDescending(x => x.InspectTimes).ToList().Take(2).ToList().Select(x=>x.InspectTimes).ToList();
        }

    }
}
