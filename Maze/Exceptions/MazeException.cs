using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.Exceptions
{
    internal class MazeException : Exception
    {
        public MazeException() : base(){}

        public MazeException(string message) : base(message){}

    }
}
