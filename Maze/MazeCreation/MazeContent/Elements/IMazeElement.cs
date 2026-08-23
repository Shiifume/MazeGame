using System;
using System.Collections.Generic;
using System.Text;
using Maze.MazeCreation.MazeContent.Mobs_Characters;

namespace Maze.MazeCreation.MazeContent.Elements
{
    internal interface IMazeElement : ISymbol, IVisitablePersonnage
    {
        public IMazeObject? Content { get; set; }
    }
}
