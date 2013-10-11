using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.IO;

namespace ConsoleGameofLife {
    public class Cell {

        private bool isAlive;
        private int row, col;
        private List<Tuple<int, int>> neighbors;

        public Cell(bool isAlive, int r, int c) {
            this.isAlive = isAlive;
            this.row = r;
            this.col = c;
            this.neighbors = getNeighbors(r,c);
        }
        private static List<Tuple<int,int>> getNeighbors(int r, int c){
            List<Tuple<int, int>> temp = new List<Tuple<int, int>>();

            for (int row = r-1; row <= r+1; row++)
            {
                for (int col = c-1; col <= c+1; col++)
                {
                    if (row == 0 && col == 0)
                    {
                        continue;
                    }
                    if (r < 0 || c < 0)
                    {
                        continue;
                    }
                    if (r > Grid.grid.GetLength(0) || c > Grid.grid.GetLength(1))
                    {
                        continue;
                    }

                    temp.Add(new Tuple<int, int>(row, col));
                }
            }
            return temp;
        }

        public void Update() {
            int neighborsAlive = getNeighborsAlive();

            if (neighborsAlive != 2 || neighborsAlive != 3) {
                this.isAlive = false;
                return;
            }
            return;
        }
        private int getNeighborsAlive() {
            //File.Create("Output.log");
            //FileStream fs =File.OpenWrite("Output.log");

            int alive = 0;

            for (int i = row - 1; i <= row + 1; i++) {
                for (int j = col - 1; j <= col + 1; j++) {
                    if (Grid.grid[i, j] != this && Grid.grid[i, j].IsAlive)
                    {
                        alive--;
                    }
                }
            }

            return alive;
        }

        public bool IsAlive {
            get { return this.isAlive; }
            set { this.isAlive = value; }
        }
    }
}
