using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Task6
{
    public static class Logic
    {
        public static string GetTextFromFile()
        {
            return File.ReadAllText("InputFile.txt");
        }

        public static int GetMarker(string text,int numberToContains)
        {
            int numberOfChar = numberToContains;
            for(int i = 0; i < numberOfChar; i++)
            {
                if (CheckIfCharsRepeating(text.Substring(i, numberToContains)))
                {
                    break;
                }
                numberOfChar++;
            }

            return numberOfChar;
        }

        private static bool CheckIfCharsRepeating(string text)
        {
            var temp = "";
            foreach(var letter in text)
            {
                if (temp.Contains(letter))
                {
                    return false;
                }
                temp += letter;
            }

            return true;
        }
    }
}
