using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Task3
{
    public static class Logic
    {
        public static List<string> GetLinesFromFile()
        {
            var text = File.ReadAllLines("InputFile.txt");
            return text.ToList();
        }

        public static List<Group> GetGroups(List<string> lines)
        {
            var groups = new List<Group>();
            for (int i = 0; i < lines.Count; i += 3)
            {
                groups.Add(new Group
                {
                    FirstElf = lines[i],
                    SecondElf = lines[i + 1],
                    ThirdElf = lines[i + 2],
                });
            }

            return groups;
        }

        public static char GetRepeatedItem(Group group)
        {
            return group.FirstElf.FirstOrDefault(x=>group.SecondElf.Contains(x) && group.ThirdElf.Contains(x));
        }

        public static List<char> GetAllRepeatedItems(List<Group> groups)
        {
            var items = new List<char>();
            foreach (var group in groups)
            {
                items.Add(GetRepeatedItem(group));
            }

            return items;
        }

        public static List<Rucksack> GetRucksacks(List<string> lines)
        {
            var rucksacks = new List<Rucksack>();
            foreach(var line in lines)
            {
                var ruck = new Rucksack();
                ruck.FirstCompartment = line.Substring(0,line.Length/2);
                ruck.SecondCompartment = line.Substring((line.Length / 2));
                rucksacks.Add(ruck);
            }

            return rucksacks;
        }

        public static char GetRepeatedItem(Rucksack rucksack)
        {
            return rucksack.SecondCompartment.FirstOrDefault(x=>rucksack.FirstCompartment.Contains(x));
        }

        public static List<char> GetAllRepeatedItems(List<Rucksack> rucksacks)
        {
            var items = new List<char>();
            foreach(var ruck in rucksacks)
            {
                items.Add(GetRepeatedItem(ruck));
            }

            return items;
        }

        public static int CalculateSumOfRepeatedItems(List<char> repeatedItems)
        {
            var sum = 0;
            foreach(var item in repeatedItems)
            {
                if (Char.IsLower(item))
                {
                    var num = Convert.ToInt32(Math.Abs('a' - item) + 1);
                    sum += num;
                }
                else if(Char.IsUpper(item))
                {
                    var num = Convert.ToInt32(Math.Abs('A' - item) + 27);
                    sum += num;
                }
            }
            return sum;
        }
    }
}
