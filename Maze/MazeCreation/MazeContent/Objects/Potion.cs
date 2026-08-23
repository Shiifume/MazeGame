using Maze.MazeCreation.MazeContent.Mobs_Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.MazeCreation.MazeContent.Objects
{
    internal abstract class Potion : IMazeObject
    {
        public string Name { get; }
        public char Symbol { get; }

        public Potion(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public abstract void Visit(Personnage personnage);
    }

    internal class HealPotion : Potion 
    {
        public HealPotion() : base("Heal Potion", '&') { }

        public override void Visit(Personnage personnage)
        {
            personnage.Life += 5;
        }
    }

    internal class StrengthPotion : Potion 
    {
        public StrengthPotion() : base("Strength Potion", '@') { }

        public override void Visit(Personnage personnage)
        {
            personnage.Strength += 2;
        }
    }

    internal class DefensePotion : Potion
    {
        public DefensePotion() : base("Defense Potion", '+') { }

        public override void Visit(Personnage personnage)
        {
            personnage.Defense += 2;
        }
    }
}
