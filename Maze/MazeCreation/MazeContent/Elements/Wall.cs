using System;
using System.Collections.Generic;
using System.Text;
using Maze.Exceptions;
using Maze.MazeCreation.MazeContent.Mobs_Characters;

namespace Maze.MazeCreation.MazeContent.Elements
{
    internal class Wall : IMazeElement
    {
        public char Symbol { private init; get; } = '*';
        public IMazeObject? Content { get => null; set => throw new MazeException("Un mur ne contient pas d'objet !"); } 

        /*
         * METHODS
         */
        public void Visit(Personnage personnage)
        {
            throw new MazeException("Les personnages ne peuvent pas traverser les murs.");
        }
    }
}
