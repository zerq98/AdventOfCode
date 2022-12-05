using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Task5
{
    public static class Logic
    {
        public static List<string> GetLinesFromFile(string path)
        {
            var text = File.ReadAllLines(path);
            return text.ToList();
        }

        public static List<List<string>> GetCargos(List<string> lines)
        {
            var containers = new List<List<string>>();
            foreach (var line in lines)
            {
                var counter = 0;
                for(int i=1;i<line.Length;i+=4)
                {
                    if (containers.Count < counter + 1)
                    {
                        containers.Add(new List<string>());
                    }
                    if (line[i].ToString() != " ")
                    {
                        containers[counter].Add(line[i].ToString());
                    }
                    counter++;
                }
            }

            foreach(var container in containers)
            {
                container.Reverse();
            }

            return containers;
        }

        internal static List<List<string>> MoveCargos(List<List<string>> cargos, List<string> instructions, bool isReversing)
        {
            foreach(var instruction in instructions)
            {
                var instr = instruction.Split(" ");
                var count = Convert.ToInt32(instr[1]);
                var from = Convert.ToInt32(instr[3])-1;
                var to = Convert.ToInt32(instr[5])-1;
                var movedItems = cargos[from].Skip(cargos[from].Count - count).Take(count).ToList();
                cargos[from].RemoveRange(cargos[from].Count - count, count);
                if(isReversing)
                {
                    movedItems.Reverse();
                }
                cargos[to].AddRange(movedItems);
            }

            return cargos;
        }

        public static string GetLastItemFromEachCargo(List<List<string>> cargos)
        {
            var cargoString = "";
            foreach(var item in cargos)
            {
                cargoString += item.Last().Replace("[", "").Replace("]", "");
            }
            return cargoString;
        }
    }
}
