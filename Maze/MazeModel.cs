using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Maze.MazeCreation.MazeContent.Mobs_Characters;
using Maze.Exceptions;
using Maze.MazeCreation.MazeContent.Elements;

namespace Maze
{
    internal class MazeModel : IEnumerable<KeyValuePair<MazePosition, IMazeElement>>
    {
        public string Name { private init; get; }
        private SortedDictionary<MazePosition, IMazeElement> _Grid { set; get; }
        public Personnage Personnage { private set; get; }

        private Dictionary<char, Personnage> _PersonnagesMap { set; get; }

        private List<char> _PersonnagesKey { set; get; }

        private int PersonnageActif { set; get; }

        public IEnumerator<Personnage> ActivePersonnages { get => _PersonnagesKey.Select(character => _PersonnagesMap[character]).GetEnumerator(); }


        /*
         * CONSTRUCTORS
         */
        public MazeModel(string name)
        {
            Name = name;
            _Grid = new();
            _PersonnagesMap = new();
            _PersonnagesKey = new();
            PersonnageActif = 0;

        }

        /*
         * INDEXEUR
         */
        public IMazeElement this[int line, int col]
        {
            set
            {
                _Grid[new MazePosition(line, col)] = value;
                if (value.Content is Personnage)
                {
                    if(this.Personnage is null)
                        this.Personnage = (Personnage)value.Content;
                    _PersonnagesMap.Add(value.Content.Symbol, (Personnage)value.Content);
                    _PersonnagesKey.Add(value.Content.Symbol);
                }
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
                    if (_Grid.TryGetValue(this.Personnage.Position, out IMazeElement originElement))
                    {
                        originElement.Content = null;
                    }
                    this.Personnage.Position = destinationPosition;
                }
                catch (MazeMonsterDiedException e)
                {
                    _Grid[destinationPosition].Content = null;
                    throw new MazeMonsterException(e.Message);
                }
                catch (OutOfMazeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                if (_Grid.TryGetValue(this.Personnage.Position, out IMazeElement originElement))
                {
                    originElement.Content = null;
                }

                this.Personnage.Position = null;

                if(_PersonnagesKey.Count > 1)
                {
                    _PersonnagesKey.Remove(Personnage.Symbol);
                    ActivatePersonnage();
                }
                else
                {
                    throw new OutOfMazeException($"Tout le monde est sorti du labyrinthe !");
                }

            }
        }

        public void ActivatePersonnage()
        {
            if(PersonnageActif < _PersonnagesKey.Count()-1)
            {
                PersonnageActif++;
            }
            else
            {
                PersonnageActif = 0;
            }

            if(_PersonnagesMap.TryGetValue(_PersonnagesKey[PersonnageActif], out Personnage perso))
            {
                Personnage = perso;
            }
        }

        public void ActivatePersonnage(char c)
        {

            char upperC = c.ToString().ToUpper()[0];

            if(_PersonnagesKey.Contains(upperC))
            {
                if (_PersonnagesMap.TryGetValue(upperC, out Personnage perso))
                {
                    Personnage = perso;
                }
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
