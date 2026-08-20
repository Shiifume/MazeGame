using System;
using System.Collections.Generic;
using System.Text;
//using Maze.MazeCreation.MazeContent;

namespace Maze
{
    internal class MazeVue
    {
        public void Display(MazeModel model, string message)
        {

            int previousLine = 0, previousColumn = 0;

            Console.Clear();
            
            foreach(var elem in model)
            {
                while(elem.Key.Line > previousLine)
                {
                    Console.Write('\n');
                    previousLine++;
                    previousColumn = 0;
                }
                while(elem.Key.Col > previousColumn)
                {
                    Console.Write("  ");
                    previousColumn++;
                }
                Console.Write($"{elem.Value.Symbol} ");
                previousColumn++;
            }
            Console.WriteLine();
            Console.WriteLine(message);
        }
    }
}
