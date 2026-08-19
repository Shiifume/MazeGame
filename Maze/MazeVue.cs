using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    internal class MazeVue
    {
        public void Display(MazeModel model, string message)
        {
            Console.WriteLine($"{model.Name} {message}");
        }
    }
}
