using Maze.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.MazeCreation.MazeContent.Mobs_Characters
{
    internal abstract class Combattants : IMazeObject
    {
        public string Name { protected init; get; }
        public char Symbol { protected init; get; }

        public MazePosition? Position { set; get; }

        public int Life { set; get; }
        public int Strength { set; get;  }
        public int Defense { set; get; }

        public void Use(Personnage personnage)
        {
            throw new UnusableObjectException("On ne peut pas consommer une personne...");
        }

        public abstract void Visit(Personnage personnage);
    }
}
