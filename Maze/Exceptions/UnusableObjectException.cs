using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.Exceptions
{
    internal class UnusableObjectException : MazeException
    {
        public UnusableObjectException() : base() { }

        public UnusableObjectException(string message) : base(message) { }
    }
}
