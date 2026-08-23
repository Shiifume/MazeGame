using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.Exceptions
{
    internal class MazeMonsterDiedException : MazeException
    {
        public MazeMonsterDiedException(string message) : base(message) { }

        public MazeMonsterDiedException() : base() { }
    }
}
