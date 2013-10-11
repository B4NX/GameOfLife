using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleGameofLife {
    public class Cell {

        private bool isAlive;
        private int row, col;

        public Cell(bool isAlive, int r, int c) {
            this.isAlive = isAlive;
            this.row = r;
            this.col = c;
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
                    try
                    {
                        if (Grid.grid[i, j] != this && Grid.grid[i, j].IsAlive)
                        {
                            alive++;
                        }
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        System.Diagnostics.Debug.WriteLine(e);
                        continue;
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
