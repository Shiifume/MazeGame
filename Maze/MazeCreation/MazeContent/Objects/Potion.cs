using Maze.MazeCreation.MazeContent.Mobs_Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.MazeCreation.MazeContent.Objects
{
    internal abstract class Potion : IMazeObject, IUsable
    {
        public string Name { get; }
        public char Symbol { get; }

        public Potion(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public void Visit(Personnage personnage)
        {
            personnage.Bag.Add(this);
        }

        public abstract void Use(Personnage personnage);
    }

    internal class HealPotion : Potion 
    {
        public HealPotion() : base("potion de soin", '&') { }

        public override void Use(Personnage personnage)
        {
            personnage.Life += 5;
        }
    }

    internal class StrengthPotion : Potion 
    {
        public StrengthPotion() : base("potion de force", '@') { }

        public override void Use(Personnage personnage)
        {
            personnage.Strength += 2;
        }
    }

    internal class DefensePotion : Potion
    {
        public DefensePotion() : base("potion de défense", '+') { }

        public override void Use(Personnage personnage)
        {
            personnage.Defense += 2;
        }
    }
}
