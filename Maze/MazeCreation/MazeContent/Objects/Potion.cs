using Maze.MazeCreation.MazeContent.Mobs_Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.MazeCreation.MazeContent.Objects
{
    internal class Potion : IMazeObject, IUsable
    {
        public string Name { get; }
        public char Symbol { get; }

        private Action<Personnage> _potionEffect;

        public Potion(string name, char symbol, Action<Personnage> effect)
        {
            Name = name;
            Symbol = symbol;
            _potionEffect = effect;
        }

        public void Visit(Personnage personnage)
        {
            personnage.Bag.Add(this);
        }

        public void Use(Personnage personnage)
        {
            _potionEffect(personnage);
        }
    }
}
