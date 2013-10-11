using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGameofLife {
    public static class GV {
        public static Cell[,] grid = new Cell[200, 200];

        public static void printGrid() {
            for (int r = 0; r <= grid.GetLength(0) - 1; r++) {
                for (int c = 0; c <= grid.GetLength(1) - 1; c++) {
                    if (grid[r, c].IsAlive) {
                        Console.Write(1+" ");
                        continue;
                    }
                    Console.Write(0+" ");
                    continue;
                }
                Console.WriteLine();
            }
        }
    }
}
