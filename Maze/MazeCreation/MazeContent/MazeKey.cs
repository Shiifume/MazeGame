using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.MazeCreation.MazeContent
{
    internal class MazeKey : IMazeObject
    {
        public char Symbol { get; } = 'f';

        public void Visit(Personnage perso)
        {
            perso.Bag.Add(this);
        }
    }
}
