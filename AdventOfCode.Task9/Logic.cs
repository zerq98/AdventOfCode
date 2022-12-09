using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Task9
{
    public static class Logic
    {
        public static List<string> GetTextFromFile()
        {
            return File.ReadAllLines("InputFile.txt").ToList();
        }

        public static List<int> CalculateStartPointAndSize(List<string> lines)
        {
            var sizes = new List<int> { 0, 0, 0, 0 };
            var val = 0;
            foreach (var line in lines)
            {
                var split = line.Split(" ").ToList();
                switch (split[0])
                {
                    case "L":
                        val = Convert.ToInt32(split[1]);
                        if (val > sizes[0])
                        {
                            sizes[0] = val;
                        }
                        break;
                    case "U":
                        val = Convert.ToInt32(split[1]);
                        if (val > sizes[1])
                        {
                            sizes[1] = val;
                        }
                        break;
                    case "R":
                        val = Convert.ToInt32(split[1]);
                        if (val > sizes[2])
                        {
                            sizes[2] = val;
                        }
                        break;
                    case "D":
                        val = Convert.ToInt32(split[1]);
                        if (val > sizes[3])
                        {
                            sizes[3] = val;
                        }
                        break;
                }
            }
            var axisX = sizes[0] > sizes[2] ? sizes[0] + 1 : sizes[2] + 1;
            var axisY = sizes[1] > sizes[3] ? sizes[1] + 1 : sizes[3] + 1;
            var x = 0;
            var y = 0;
            switch (lines[0][0].ToString())
            {
                case "L":
                    x = axisX;
                    break;
                case "U":
                    y = axisY;
                    break;
                case "R":
                    x = 0;
                    break;
                case "D":
                    y = 0;
                    break;
            }

            switch (lines[1][0].ToString())
            {
                case "L":
                    x = axisX-1;
                    break;
                case "U":
                    y = axisY-1;
                    break;
                case "R":
                    x = 0;
                    break;
                case "D":
                    y = 0;
                    break;
            }

            return new List<int> { axisX, axisY, x, y };
        }

        public static int CalculateCountOfTailPosition(List<int> data,List<string> lines)
        {
            var visited = new List<string>();
            var headX = data[2];
            var headY = data[3];
            var tailX = data[2];
            var tailY = data[3];
            visited.Add($"{tailX},{tailY}");
            foreach (var line in lines)
            {
                //Console.WriteLine($"== {line} ==");
                var split = line.Split(" ").ToList();
                for(int i = 0; i < Convert.ToInt32(split[1]); i++)
                {
                    var tailEdges = new List<string>();
                    for(int tx = tailX - 1; tx <= tailX + 1; tx++)
                    {
                        for (int ty = tailY - 1; ty <= tailY + 1; ty++)
                        {
                            tailEdges.Add($"{tx},{ty}");
                        }
                    }
                    var prevHeadX=headX;
                    var prevHeadY=headY;

                    switch (split[0])
                    {
                        case "L":
                            headX--;
                            break;
                        case "U":
                            headY--;
                            break;
                        case "R":
                            headX++;
                            break;
                        case "D":
                            headY++;
                            break;
                    }

                    var headPos = $"{headX},{headY}";

                    if (!tailEdges.Contains(headPos))
                    {
                        tailX = prevHeadX;
                        tailY=prevHeadY;
                    }

                    if (!visited.Contains($"{tailX},{tailY}"))
                    {
                        visited.Add($"{tailX},{tailY}");
                    }

                }
            }

            return visited.Count();
        }

        public static int CalculateCountOfNinthTailPosition(List<int> data, List<string> lines)
        {
            var visited = new List<string>();
            var headX = data[2];
            var headY = data[3];
            var prevCords = new List<string>();
            var actualCords = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                prevCords.Add($"{headX},{headY}");
                actualCords.Add($"{headX},{headY}");
            }
            visited.Add($"{headX},{headY}");
            foreach (var line in lines)
            {
                for (int i = 0; i < 10; i++)
                {
                    prevCords[i]=actualCords[i];
                }
                var split = line.Split(" ").ToList();
                for (int i = 0; i < Convert.ToInt32(split[1]); i++)
                {
                    var tailEdges = new List<List<string>>();
                    for(int g=1;g<10;g++)
                    {
                        var tailX = Convert.ToInt32(actualCords[g].Split(",")[0]);
                        var tailY = Convert.ToInt32(actualCords[g].Split(",")[1]);
                        var tailEdge = new List<string>();
                        for (int tx = tailX - 1; tx <= tailX + 1; tx++)
                        {
                            for (int ty = tailY - 1; ty <= tailY + 1; ty++)
                            {
                                tailEdge.Add($"{tx},{ty}");
                            }
                        }
                        tailEdges.Add(tailEdge);
                    }

                    switch (split[0])
                    {
                        case "L":
                            headX--;
                            break;
                        case "U":
                            headY--;
                            break;
                        case "R":
                            headX++;
                            break;
                        case "D":
                            headY++;
                            break;
                    }

                    actualCords[0] = $"{headX},{headY}";

                    for (int g = 1; g < 10; g++)
                    {
                        if (!tailEdges[g-1].Contains(actualCords[g - 1]))
                        {
                            actualCords[g] = prevCords[g - 1];
                        }
                    }

                    if (!visited.Contains(actualCords[9]))
                    {
                        visited.Add(actualCords[9]);
                    }

                }
            }

            return visited.Count();
        }

        private static void DrawBridge(int headX, int headY, int tailX, int tailY, int v1, int v2)
        {
            for(int i=0;i<v2;i++)
            {
                for(int j=0;j<v1;j++)
                {
                    if(headX==tailX&& headY==tailY)
                    {
                        Console.Write("H ");
                    }
                    else if(headX==j && headY == i)
                    {
                        Console.Write("H ");
                    }
                    else if(tailX == j && tailY == i)
                    {
                        Console.Write("T ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
