using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.MazeCreation.MazeContent
{
    internal class Personnage : IMazeObject
    {
        public char Symbol { private init; get; } = 'O';

        // ???? position voir version 3, qqch d'autre pour la position
        public MazePosition? Position { set; get; }
    }
}
