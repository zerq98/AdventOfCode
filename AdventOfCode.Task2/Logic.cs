using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Task2
{
    public static class Logic
    {
        public static List<string> GetLinesFromFile()
        {
            var text = File.ReadAllLines("InputFile.txt");
            return text.ToList();
        }

        public static int CalculateAllGamesResult(List<string> lines,bool withExpectedResult)
        {
            var result = 0;
            foreach (var line in lines)
            {
                var selections = line.Split(" ");
                if (withExpectedResult)
                {
                    result += CalculateRoundResult(selections[0], (ExpectedResultEnum)selections[1][0]);
                }
                else
                {
                    result += CalculateRoundResult(selections[0], selections[1]);
                }
            }

            return result;
        }

        private static int CalculateRoundResult(string enemy, string you)
        {
            switch (enemy)
            {
                case "A":
                    switch (you)
                    {
                        case "X":
                            return 4;
                        case "Y":
                            return 8;
                        case "Z":
                            return 3;
                    }
                    break;
                case "B":
                    switch (you)
                    {
                        case "X":
                            return 1;
                        case "Y":
                            return 5;
                        case "Z":
                            return 9;
                    }
                    break;
                case "C":
                    switch (you)
                    {
                        case "X":
                            return 7;
                        case "Y":
                            return 2;
                        case "Z":
                            return 6;
                    }
                    break;
            }

            return 0;
        }

        private static int CalculateRoundResult(string enemy, ExpectedResultEnum expectedResult)
        {
            switch (expectedResult)
            {
                case ExpectedResultEnum.Win:
                    switch (enemy)
                    {
                        case "A":
                            return 8;
                        case "B":
                            return 9;
                        case "C":
                            return 7;
                    }
                    break;
                case ExpectedResultEnum.Draw:
                    switch (enemy)
                    {
                        case "A":
                            return 4;
                        case "B":
                            return 5;
                        case "C":
                            return 6;
                    }
                    break;
                case ExpectedResultEnum.Lose:
                    switch (enemy)
                    {
                        case "A":
                            return 3;
                        case "B":
                            return 1;
                        case "C":
                            return 2;
                    }
                    break;
            }

            return 0;
        }
    }
}
