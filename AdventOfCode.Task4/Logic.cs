using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Task4
{
    public static class Logic
    {
        public static List<string> GetLinesFromFile()
        {
            var text = File.ReadAllLines("InputFile.txt");
            return text.ToList();
        }

        public static List<Boundings> GetRegionBounds(List<string> lines)
        {
            var boundings = new List<Boundings>();
            foreach (var line in lines)
            {
                var split = line.Split(new[] { ',', '-' });
                boundings.Add(new Boundings(split));
            }
            return boundings;
        }

        public static int GetNumerOfContainingPairs(List<Boundings> boundings)
        {
            var number = 0;
            foreach(var bounding in boundings)
            {
                if (CheckIfContains(bounding))
                {
                    number++;
                }
            }

            return number;
        }

        private static bool CheckIfContains(Boundings bounding)
        {
            if (bounding.FirstRegionStart <= bounding.SecondRegionStart && bounding.FirstRegionEnd >= bounding.SecondRegionEnd) return true;
            if (bounding.FirstRegionStart >= bounding.SecondRegionStart && bounding.FirstRegionEnd <= bounding.SecondRegionEnd) return true;

            return false;
        }

        public static int GetNumerOfOverlapingPairs(List<Boundings> boundings)
        {
            var number = 0;
            foreach (var bounding in boundings)
            {
                if (CheckIfOverlap(bounding))
                {
                    number++;
                }
            }

            return number;
        }

        private static bool CheckIfOverlap(Boundings bounding)
        {
            return bounding.FirstRegionStart<=bounding.SecondRegionEnd && bounding.SecondRegionStart<= bounding.FirstRegionEnd;
        }
    }
}
