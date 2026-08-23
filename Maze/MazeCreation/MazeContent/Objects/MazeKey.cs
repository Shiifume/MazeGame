using System;
using System.Collections.Generic;
using System.Text;
using Maze.MazeCreation.MazeContent.Mobs_Characters;

namespace Maze.MazeCreation.MazeContent.Objects
{
    internal class MazeKey : IMazeObject
    {
        public char Symbol { get; } = 'f';
        public string Name { get; } = "clé";

        public void Visit(Personnage perso)
        {
            perso.Bag.Add(this);
        }
    }
}
