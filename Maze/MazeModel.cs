using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Maze.MazeCreation.MazeContent;

namespace Maze
{
    internal class MazeModel : IEnumerable<KeyValuePair<MazePosition, IMazeElement>>
    {
        public string Name { private init; get; }
        private SortedDictionary<MazePosition, IMazeElement> _Grid { set; get; }

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
            }
            get 
            {
                return _Grid[new MazePosition(line, col)];
            }
        }

        /*
         * METHODS
         */

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
