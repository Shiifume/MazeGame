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
            model[new MazePosition(line, col)] = new Room();
        }

        public void AddWall(int line, int col)
        {
            model[new MazePosition(line, col)] = new Wall();
        }

        public void AddDoor(int line, int col)
        {
            model[new MazePosition(line, col)] = new Door();
        }

        public void AddFighter(int line, int col, char c)
        {
            MazePosition pos = new MazePosition(line, col);


            if (_temporaryFighterHolder is not null && _temporaryFighterHolder.TryGetValue(c, out Combattants fighter))
            {
                model[pos] = new Room(fighter);
            }

            ((Combattants)model[pos].Content).Position = pos;
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
            model[new MazePosition(line, col)] = new Room(new MazeKey());
        }

        public void AddHealPotion(int line, int col)
        {
            model[new MazePosition(line, col)] = new Room(new Potion("Potion de soin", '&', p => p.Life += 5 ));
        }
        public void AddStrengthPotion(int line, int col)
        {
            model[new MazePosition(line, col)] = new Room(new Potion("Potion de force", '@', p => p.Strength += 2));
        }
        public void AddDefensePotion(int line, int col)
        {
            model[new MazePosition(line, col)] = new Room(new Potion("Potion de défense", '+', p => p.Defense += 2));
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
