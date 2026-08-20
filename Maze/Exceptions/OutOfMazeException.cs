using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.Exceptions
{
    internal class OutOfMazeException : MazeException
    {
        public OutOfMazeException() : base() { }

        public OutOfMazeException(string message) : base(message) { }

    }
}
