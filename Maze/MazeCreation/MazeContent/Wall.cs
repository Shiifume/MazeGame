using System;
using System.Collections.Generic;
using System.Text;
using Maze.Exceptions;

namespace Maze.MazeCreation.MazeContent
{
    internal class Wall : IMazeElement
    {
        public char Symbol { private init; get; } = '*';
        public IMazeObject? Content 
        { 
            get
            {
                return null;
            }
            set
            {
                throw new MazeException("Un mur ne contient pas d'objet !");
            }
        }

        /*
         * METHODS
         */
        public void Visit(Personnage personnage)
        {
            throw new MazeException("Les personnages ne peuvent pas traverser les murs.");
        }
    }
}
