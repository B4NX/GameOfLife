using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleGameofLife {
    public static class GridBuilder {

        public static Cell[,] MakeGrid(string path) {
            String[] wholeText = getFileTextArray(path);
            int row, col;
            List<Cell> cellList=getCellList(wholeText,out row, out col);
            return getGrid(cellList, row, col);
        }

        private static String[] getFileTextArray(string path) {
            string ft;
            try {
                ft = File.ReadAllText(path);
            } catch (FileNotFoundException e) {
                ft = "";
                System.Diagnostics.Debug.Write(e);
                Environment.Exit(-1);
            }
            String[] wholeText = ft.Split('\n');
            return wholeText;
        }

        private static List<Cell> getCellList(String[] text, out int row, out int col)
        {
            List<Cell> ls = new List<Cell>();
            Char[] temp;
            row = 0;
            int j=0, k=0;
            foreach (String s in text)
            {
                j++;
                k = 0;
                temp = s.ToArray();
                for (int i = 0; i < temp.GetLength(0); i++)
                {
                    int num;
                    if (Int32.TryParse(temp[i].ToString(), out num))
                    {
                        k++;
                        ls.Add(new Cell(num, j, k));
                    }
                }
            }
            row = j;
            col = k;
            return ls;
        }
        
        private static Cell[,] getGrid(List<Cell> cells, int r, int c)
        {
            Cell[,] temp = new Cell[r, c];
            int i = 0;
            for (int row = 0; row <= r-1; row++)
            {
                for (int col = 0; col <= c-1; col++)
                {
                    temp[row, col] = cells[i++];
                }
            }
            return temp;
        }
    }
}
