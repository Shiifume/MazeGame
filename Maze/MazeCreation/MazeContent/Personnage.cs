using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.MazeCreation.MazeContent
{
    internal class Personnage : IMazeObject
    {
        public char Symbol { private init; get; }
        public MazePosition? Position { set; get; }

        public ICollection<IMazeObject> Bag;

        public Personnage(char symbol)
        {
            Symbol = symbol;
            Bag = new HashSet<IMazeObject>();
        }

        public void Visit(Personnage personnage)
        {
            throw new NotImplementedException();
        }


    }
}
