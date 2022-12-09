using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Task8
{
    public static class Logic
    {
        public static List<string> GetTextFromFile()
        {
            return File.ReadAllLines("InputFile.txt").ToList();
        }

        public static List<List<int>> GenerateGrid(List<string> lines)
        {
            var grid = new List<List<int>>();
            foreach(var line in lines)
            {
                var gridLine = new List<int>();
                foreach(var digit in line)
                {
                    gridLine.Add(Convert.ToInt32(digit.ToString()));
                }
                grid.Add(gridLine);
            }

            return grid;
        }

        public static int GetNumberOfVisibleTrees(List<List<int>> grid)
        {
            var rows = grid.Count();
            var cols = grid.Max(x=>x.Count());
            var numberOfVisibleTrees = rows * 2 + (cols - 2) * 2;

            for(int r = 1; r < rows-1; r++)
            {
                for(int c = 1; c < cols-1; c++)
                {
                    if (IsVisible(c,r,grid,rows,cols))
                    {
                        numberOfVisibleTrees++;
                    }
                }
            }

            return numberOfVisibleTrees;
        }

        public static int GetBestPositionsOfVisibleTrees(List<List<int>> grid)
        {
            var retList = new List<int>();
            var rows = grid.Count();
            var cols = grid.Max(x => x.Count());
            var numberOfVisibleTrees = rows * 2 + (cols - 2) * 2;

            for (int r = 1; r < rows - 1; r++)
            {
                for (int c = 1; c < cols - 1; c++)
                {
                    retList.Add(CalculateVisibilityScore(c, r, grid, rows, cols));
                }
            }

            return retList.OrderByDescending(x=>x).First();
        }

        public static bool IsVisible(int column, int row, List<List<int>> grid,int rowCount,int colCount)
        {
            var value = grid[row][column];
            var visibilityCount = 0;
            for (int c = 0; c < column; c++)
            {
                if (grid[row][c] < value) visibilityCount++;
            }
            if (visibilityCount == column) return true;
            visibilityCount = 0;

            for (int c = column+1; c < colCount; c++)
            {
                if (grid[row][c] < value) visibilityCount++;
            }

            if (visibilityCount == (colCount-(column+1))) return true;
            visibilityCount = 0;

            for (int r = row+1; r < rowCount; r++)
            {
                if (grid[r][column] < value) visibilityCount++;
            }
            if (visibilityCount == (rowCount - (row + 1))) return true;
            visibilityCount = 0;

            for (int r = 0; r < row; r++)
            {
                if (grid[r][column] < value) visibilityCount++;
            }
            if (visibilityCount == row) return true;
            visibilityCount = 0;

            return false;
        }

        public static int CalculateVisibilityScore(int column, int row, List<List<int>> grid, int rowCount, int colCount)
        {
            var value = grid[row][column];
            var score = 1;
            var visibilityCount = 0;

            for (int c = column-1; c > -1; c--)
            {
                visibilityCount++;
                if (grid[row][c] >= value)
                {
                    break;
                }
            }
            if (visibilityCount == 0) visibilityCount = 1;

            score *= visibilityCount;

            visibilityCount= 0;

            for (int c = column +1; c < colCount; c++)
            {
                visibilityCount++;
                if (grid[row][c] >= value)
                {
                    break;
                }
            }
            if (visibilityCount == 0) visibilityCount = 1;

            score *= visibilityCount;

            visibilityCount = 0;

            for (int r = row - 1; r > -1; r--)
            {
                visibilityCount++;
                if (grid[r][column] >= value)
                {
                    break;
                }
            }
            if (visibilityCount == 0) visibilityCount = 1;

            score *= visibilityCount;

            visibilityCount = 0;

            for (int r = row + 1; r < rowCount; r++)
            {
                visibilityCount++;
                if (grid[r][column] >= value)
                {
                    break;
                }
            }
            if (visibilityCount == 0) visibilityCount = 1;

            score *= visibilityCount;

            return score;
        }
    }
}
