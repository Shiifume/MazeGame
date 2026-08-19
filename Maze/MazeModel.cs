using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    internal class MazeModel
    {
        public string Name { private init; get; }

        public MazeModel(string name)
        {
            Name = name;
        }
    }
}
