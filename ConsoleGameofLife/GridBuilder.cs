using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleGameofLife {
    public static class GridBuilder {

        public static void MakeGrid(string path) {

            string ft;
            List<int> aliveList = new List<int>();

            try {
                ft = File.ReadAllText(path);
            } catch (FileNotFoundException e) {
                ft = "";
                System.Diagnostics.Debug.Write(e);
                Environment.Exit(-1);
            }

            String[] wholeText = ft.Split('\n');

            Char[] temp;
            int row=0, col=0;
            foreach (String s in wholeText) {
                row++;

                temp = s.ToArray();
                for (int i = 0; i < temp.GetLength(0); i++) {
                    int num;
                    if (Int32.TryParse(temp[i].ToString(),out num)) {
                        col++;
                        aliveList.Add(num);
                    }
                }
            }
        }
    }
}
