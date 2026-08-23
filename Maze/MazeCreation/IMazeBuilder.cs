using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.MazeCreation
{
    internal interface IMazeBuilder
    {
        public void Start(string name);

        public void AddRoom(int line, int col);

        public void AddWall(int line, int col);

        public void AddFighter(int line, int col, char c);

        public void DefineFighter(char symbol, int life, int strength, int defense);

        public void AddHealPotion(int line, int col);
        public void AddStrengthPotion(int line, int col);
        public void AddDefensePotion(int line, int col);

        public void AddDoor(int line, int col);

        public void AddKey(int line, int col);

        public void Finish();
    }
}
