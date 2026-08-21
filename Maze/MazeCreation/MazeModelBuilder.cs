using Maze.MazeCreation.MazeContent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.MazeCreation
{
    internal class MazeModelBuilder : IMazeBuilder
    {

        private MazeModel model;
        
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

        public void AddCharacter(int line, int col, char c)
        {
            model[line, col] = new Room(new Personnage(c));
            ((Personnage)model[line, col].Content).Position = new MazePosition(line, col);
        }

        public void AddKey(int line, int col)
        {
            model[line, col] = new Room(new MazeKey());
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
