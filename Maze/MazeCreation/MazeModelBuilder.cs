using Maze.MazeCreation.MazeContent;
using System;
using System.Collections.Generic;
using System.Text;
using Maze.MazeCreation.MazeContent.Elements;
using Maze.MazeCreation.MazeContent.Mobs_Characters;
using Maze.MazeCreation.MazeContent.Objects;

namespace Maze.MazeCreation
{
    internal class MazeModelBuilder : IMazeBuilder
    {

        private MazeModel model;

        private Dictionary<char, Combattants> _temporaryFighterHolder;

        public void AddRoom(int line, int col)
        {
            model[line, col] = new Room();
        }

        public void AddWall(int line, int col)
        {
            model[line, col] = new Wall();
        }

        public void AddDoor(int line, int col)
        {
            model[line, col] = new Door();
        }

        public void AddFighter(int line, int col, char c)
        {
            if(_temporaryFighterHolder is not null && _temporaryFighterHolder.TryGetValue(c, out Combattants fighter))
            {
                model[line, col] = new Room(fighter);
            }

            ((Combattants)model[line, col].Content).Position = new MazePosition(line, col);
        }

        public void DefineFighter(char symbol, int life, int strength, int defense)
        {
            _temporaryFighterHolder ??= new();
            _temporaryFighterHolder.Add(symbol, char.IsUpper(symbol) ? new Personnage(symbol) : new Monster(symbol));

            _temporaryFighterHolder[symbol].Life = life;
            _temporaryFighterHolder[symbol].Strength = strength;
            _temporaryFighterHolder[symbol].Defense = defense;
           
        }

        public void AddKey(int line, int col)
        {
            model[line, col] = new Room(new MazeKey());
        }

        public void AddHealPotion(int line, int col)
        {
            model[line, col] = new Room(new HealPotion());
        }
        public void AddStrengthPotion(int line, int col)
        {
            model[line, col] = new Room(new StrengthPotion());
        }
        public void AddDefensePotion(int line, int col)
        {
            model[line, col] = new Room(new DefensePotion());
        }

        public void Finish()
        { }

        public void Start(string name)
        {
            model = new(name);
        }

        public MazeModel Build()
        {
            return model;
        }
    }
}
