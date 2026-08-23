using System;
using System.Collections.Generic;
using System.Text;
using Maze.MazeCreation.MazeContent.Mobs_Characters;

namespace Maze.MazeCreation.MazeContent
{
    internal interface IMazeObject : ISymbol, IVisitablePersonnage
    {
        string Name { get; }
    }
}
