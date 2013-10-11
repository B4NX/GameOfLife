using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGameofLife {
    class Program {
        static void Main(string[] args) {
            createGrid();
            GV.printGrid();
            Console.ReadKey();
        }
        private static void createGrid() {
            Cell[,] grid = GV.grid;

            for (int row = 5; row <= 195; row++) {
                for (int col = 5; col <= 195; col++) {
                    grid[row, col] = new Cell(true, row, col);
                }
            }

            GV.grid = grid;
        }
    }
}
