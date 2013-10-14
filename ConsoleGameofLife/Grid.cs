using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGameofLife
{
    public class Grid
    {
        public static Cell[,] grid= new Cell[5,5];

        public static void Create()
        {
            for (int row = 0; row <= Grid.grid.GetLength(0)-1; row++)
            {
                for (int col = 0; col <= Grid.grid.GetLength(1)-1; col++)
                {
                    grid[row, col] = new Cell(true, row, col);
                }
            }
        }

        new public static string ToString()
        {
            string temp="";
            for (int r = 0; r <= grid.GetLength(0) - 1; r++)
            {
                for (int c = 0; c <= grid.GetLength(1) - 1; c++)
                {
                    if (grid[r, c].IsAlive)
                    {
                        temp+=(1 + " ");
                        continue;
                    }
                    temp+=(0 + " ");
                    continue;
                }
                temp += "\n";
            }
            return temp;
        }

        public static void Update()
        {
            for (int r = 0; r <= grid.GetLength(0) - 1; r++)
            {
                for (int c = 0; c <= grid.GetLength(1) - 1; c++)
                {
                    grid[r, c].Update();
                }
            }
        }
    }
}
