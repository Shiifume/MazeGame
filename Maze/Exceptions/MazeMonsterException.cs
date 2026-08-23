using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.Exceptions
{
    internal class MazeMonsterException : MazeException
    {
        public MazeMonsterException(string message) : base(message) { }

        public MazeMonsterException() : base() { }
    }
}
