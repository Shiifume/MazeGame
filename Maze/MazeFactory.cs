using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    internal class MazeFactory
    {
        public MazeModel CreateMaze(string name)
        {
            return new MazeModel(name);
        }
    }
}
