using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Maze.MazeCreation.MazeContent;
using Maze.Exceptions;

namespace Maze
{
    internal class MazeModel : IEnumerable<KeyValuePair<MazePosition, IMazeElement>>
    {
        public string Name { private init; get; }
        private SortedDictionary<MazePosition, IMazeElement> _Grid { set; get; }
        public Personnage Personnage { private set; get; }

        /*
         * CONSTRUCTORS
         */
        public MazeModel(string name)
        {
            Name = name;
            _Grid = new();
        }

        /*
         * INDEXEUR
         */
        public IMazeElement this[int line, int col]
        {
            set
            {
                _Grid[new MazePosition(line, col)] = value;
                if(value.Content is Personnage)
                    this.Personnage = (Personnage)value.Content;
            }
            get 
            {
                return _Grid[new MazePosition(line, col)];
            }
        }

        /*
         * METHODS
         */

        public void Move(Direction direction)
        {
            MazePosition destinationPosition = this.Personnage.Position[direction];
            if(_Grid.TryGetValue(destinationPosition, out IMazeElement value))
            {
                try
                {
                    value.Visit(this.Personnage);
                    if(_Grid.TryGetValue(this.Personnage.Position, out IMazeElement originElement))
                    {
                        originElement.Content = null;
                    }
                    this.Personnage.Position = destinationPosition;
                }
                catch (OutOfMazeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                this.Personnage.Position = null;
                throw new OutOfMazeException("Le personnage est sorti du labyrinthe !");
            }
        }

        public IEnumerator<KeyValuePair<MazePosition, IMazeElement>> GetEnumerator()
        {
            return _Grid.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }



    }
}
