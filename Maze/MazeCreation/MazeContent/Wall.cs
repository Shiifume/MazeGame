using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.MazeCreation.MazeContent
{
    internal class Wall : IMazeElement
    {
        public char Symbol { private init; get; } = '*';
    }
}
