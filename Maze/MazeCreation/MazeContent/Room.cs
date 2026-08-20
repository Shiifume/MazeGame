using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.MazeCreation.MazeContent
{
    internal class Room : IMazeElement
    {
        public char Symbol
        {
            //private init;
            get
            {
                return Content is null ? field : Content.Symbol;
            }
        } = '.';

        public IMazeObject? Content { get; set; }

        /*
         * CONSTRUCTEURS
         */

        public Room() 
        {
            this.Content = null;
        }

        public Room(IMazeObject content)
        {
            this.Content = content; 
        }
    }
}
