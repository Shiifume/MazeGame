using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.MazeCreation.MazeContent
{
    internal class Personnage : IMazeObject
    {
        public char Symbol { private init; get; } = 'O';
        public MazePosition? Position { set; get; }

        public void Visit(Personnage personnage)
        {
            throw new NotImplementedException();
        }
    }
}
