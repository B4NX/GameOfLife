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

        public Cell(int i, int r, int c)
        {
            switch (i)
            {
                case(1):
                    this.isAlive = true;
                    break;
                default:
                    this.isAlive = false;
                    break;
            }
            this.row = r;
            this.col = c;
            this.neighbors = getNeighbors(r, c);
        }
        public Cell(bool isAlive, int r, int c) {
            this.isAlive = isAlive;
            this.row = r;
            this.col = c;
            this.neighbors = getNeighbors(r,c);
            Console.Write("");
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
                    if (!isValidIndex(row, col)) {
                        continue;
                    }

                    temp.Add(new Tuple<int, int>(row, col));
                }
            }
            return temp;
        }
        private static bool isValidIndex(int row,int col) {
            if (row < 0 || col < 0) {
                return false;
            }else if(row>=Grid.grid.GetLength(0)||col>=Grid.grid.GetLength(1)){
                return false;
            }
            return true;
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

            foreach (Tuple<int, int> t in this.neighbors) {
                if (Grid.grid[t.Item1, t.Item2].IsAlive) {
                    alive++;
                }
            }

            return alive;
        }

        public bool IsAlive {
            get { return this.isAlive; }
            set { this.isAlive = value; }
        }

        public override string ToString()
        {
            if (this.isAlive)
            {
                return "1 ";
            }
            return "0 ";
        }
    }
}
