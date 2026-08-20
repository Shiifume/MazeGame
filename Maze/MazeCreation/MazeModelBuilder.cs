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

        public void AddCharacter(int line, int col)
        {
            model[line, col] = new Room(new Personnage());
            ((Personnage)model[line, col].Content).Position = new MazePosition(line, col);
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
