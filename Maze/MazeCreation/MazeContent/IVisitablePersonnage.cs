using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.MazeCreation.MazeContent.Mobs_Characters
{
    internal interface IVisitablePersonnage
    {
        public void Visit(Personnage personnage);
    }
}
