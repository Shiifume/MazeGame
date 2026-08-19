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
