using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.Exceptions
{
    internal class MazeCharacterCollisionException : MazeException
    {
        public MazeCharacterCollisionException() : base() { }

        public MazeCharacterCollisionException(string message) : base(message) { }
    }
}
