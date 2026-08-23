using System;
using System.Collections.Generic;
using System.Text;
using Maze.Exceptions;

namespace Maze.MazeCreation.MazeContent.Mobs_Characters
{
    internal class Personnage : Combattants
    {

        public ICollection<IMazeObject> Bag;

        public Personnage(char symbol)
        {
            Symbol = symbol;
            Name = symbol.ToString();
            Bag = new HashSet<IMazeObject>();
        }

        public override void Visit(Personnage personnage)
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
