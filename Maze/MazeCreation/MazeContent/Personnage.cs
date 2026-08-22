using System;
using System.Collections.Generic;
using System.Text;
using Maze.Exceptions;

namespace Maze.MazeCreation.MazeContent
{
    internal class Personnage : IMazeObject
    {
        public char Symbol { private init; get; }

        public string Name { get; private init; }
        public MazePosition? Position { set; get; }

        public ICollection<IMazeObject> Bag;

        public Personnage(char symbol)
        {
            Symbol = symbol;
            Name = symbol.ToString();
            Bag = new HashSet<IMazeObject>();
        }

        public void Visit(Personnage personnage)
        {
            foreach (IMazeObject obj in personnage.Bag)
            {
                this.Bag.Add(obj);
                personnage.Bag.Remove(obj);
            }
            throw new MazeCharacterCollisionException($"Inventaire transféré de {personnage.Symbol} to {this.Symbol}");
        }


    }
}
