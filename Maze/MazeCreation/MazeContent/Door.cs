using Maze.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.Concurrent;

namespace Maze.MazeCreation.MazeContent
{
    internal class Door : IMazeElement
    {
        public IMazeObject? Content { get; set; }

        private bool Open { get; set; }

        public char Symbol { get => Open == false ? '|' : (Content is null ? '_' : Content.Symbol); }

        /*
         * CONSTRUCTEURS
         */
        
        public Door()
        {
            Open = false;
            Content = null;
        }
        
        
        /*
         * METHODS
         */

        public void Visit(Personnage personnage)
        {
            if(Open)
                Content = personnage; 
            else 
            {
                IMazeObject? keyToRemove = null;

                foreach (object item in personnage.Bag)
                {
                    if (item is MazeKey && keyToRemove is null)
                    {
                        keyToRemove = (MazeKey)item;
                    }
                }

                if (keyToRemove is not null)
                {
                    this.Open = true;
                    Content = personnage;
                    personnage.Bag.Remove(keyToRemove);
                }
                else
                {
                    throw new MazeException("La porte est fermée...");
                }
            }
            
        }
    }
}
