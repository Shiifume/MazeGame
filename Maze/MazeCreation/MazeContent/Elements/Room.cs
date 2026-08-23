using Maze.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Maze.MazeCreation.MazeContent.Mobs_Characters;

namespace Maze.MazeCreation.MazeContent.Elements
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

        /*
         * METHODS
         */

        public void Visit(Personnage personnage)
        {
            if(Content is not null)
            { 
                Content.Visit(personnage);
            }
            Content = personnage;
        }
    }
}
