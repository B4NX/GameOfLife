using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGameofLife {
    class Program {
        static void Main(string[] args) {
            Grid.Create();
            Grid.printGrid();
            //Console.ReadKey();
            Console.WriteLine();
            Grid.Update();
            Grid.printGrid();
            Console.ReadKey();
        }
    }
}
