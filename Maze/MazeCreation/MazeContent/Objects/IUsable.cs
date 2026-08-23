using Maze.MazeCreation.MazeContent.Mobs_Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.MazeCreation.MazeContent.Objects
{
    internal interface IUsable
    {
        public void Use(Personnage perso);
    }
}
