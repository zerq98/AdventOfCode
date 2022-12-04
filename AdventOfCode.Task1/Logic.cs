using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Task1
{
    public static class Logic
    {
        public static List<string> GetLinesFromFile()
        {
            var text = File.ReadAllLines("InputFile.txt");
            return text.ToList();
        }

        public static List<double> GetCaloriesSum(List<string> inputData)
        {
            var calories = new List<double>();
            var sum = 0d;

            foreach(var calorie in inputData)
            {
                if (calorie.Trim() != "")
                {
                    var convertedVal = Convert.ToDouble(calorie);
                    sum += convertedVal;
                    continue;
                }
                calories.Add(sum);
                sum = 0;
            }

            return calories;
        }

        public static double GetMaxCalories(List<double> calorieList)
        {
            return calorieList.Max();
        }

        public static double GetSumOfTopThree(List<double> calorieList)
        {
            return calorieList.OrderByDescending(x=>x).Take(3).Sum();
        }
    }
}
