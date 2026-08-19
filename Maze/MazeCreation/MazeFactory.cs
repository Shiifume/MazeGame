using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.MazeCreation
{
    internal class MazeFactory
    {
        public MazeModel CreateMaze(string name)
        {

            MazeModelBuilder builder = new();

            MazeFileReader fileReader = new(builder);
            fileReader.Read(name);

            
            return builder.Build();
        }
    }
}
