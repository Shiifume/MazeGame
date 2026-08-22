using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.MazeCreation.MazeContent
{
    internal interface IMazeObject : ISymbol, IVisitablePersonnage
    {
        string Name { get; }
    }
}
