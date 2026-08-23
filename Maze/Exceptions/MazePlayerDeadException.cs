using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.Exceptions
{
    internal class MazePlayerDeadException : MazeException
    {
        public MazePlayerDeadException(string message) : base(message) { }

        public MazePlayerDeadException() : base() { }
    }
}
