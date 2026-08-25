using System;
using System.Collections.Generic;
using System.Text;
using Maze.Exceptions;


namespace Maze.MazeCreation.MazeContent.Mobs_Characters
{
    internal class Personnage : Combattants
    {

        public OrderedSet<IMazeObject> Bag;

        public IMazeObject? ActiveObject { get; set; }

        public Personnage(char symbol)
        {
            Symbol = symbol;
            Name = symbol.ToString();
            Bag = new OrderedSet<IMazeObject>();
            ActiveObject = null;
        }

        public override void Visit(Personnage personnage)
        {
            this.Bag.AddRange(personnage.Bag);
            personnage.Bag.Clear();

            throw new MazeCharacterCollisionException($"Inventaire transféré de {personnage.Symbol} to {this.Symbol}");
        }

        public void ActivateBag()
        {
            if (this.Bag.Count() > 0)
                ActiveObject = Bag[0];
            else
                throw new MazeException($"Le sac de {this.Name} est vide.");
        }

        public void DeactivateBag()
        {
            ActiveObject = null;
        }

        public void NextObject()
        {
            int index = Bag.IndexOf(ActiveObject);
            ActiveObject = index < Bag.Count - 1 ? Bag[index + 1] : Bag[0];
        }

        public void PreviousObject()
        {
            int index = Bag.IndexOf(ActiveObject);
            ActiveObject = index > 0 ? Bag[index - 1] : Bag[Bag.Count - 1];
        }
    }
}
