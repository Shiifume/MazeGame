using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Maze.MazeCreation
{
    internal class MazeFileReader
    {
        private IMazeBuilder _builder;

        private delegate void ElementRead(int row, int col, char c);
        private Dictionary<char, ElementRead> elementsReader;
        
        public MazeFileReader(IMazeBuilder builder)
        {
            _builder = builder;
            elementsReader = new Dictionary<char, ElementRead> 
            {
                { '*', (row, col, _) => _builder.AddWall(row, col) },
                { '.', (row, col, _) => _builder.AddRoom(row, col) },
                { '|', (row, col, _) => _builder.AddDoor(row, col) },
                { 'f', (row, col, _) => _builder.AddKey(row, col) }
            };

            for(char character = 'A'; character <= 'Z'; character++)
            {
                elementsReader.Add(character, (row, col, c) => _builder.AddFighter(row, col, c));
            }

            for(char character = 'm'; character <= 'z'; character++)
            {
                elementsReader.Add(character, (row, col, c) => _builder.AddFighter(row, col, c));
            }
        }

        public void Read(string mazeName)
        {
            string filePath = "../../../MazeFiles/" + mazeName + ".maze";
            
            //to do : try catch on reader to check if file exists

            using (StreamReader lecteur = new StreamReader(filePath))
            {
                _builder.Start(mazeName);

                int row = 0;
                string? line;

                Regex myRegex = new Regex(@"^([A-Za-z])\:([0-9]+)\,([0-9]+)\,([0-9]+)$");

                while((line = lecteur.ReadLine()) != null)
                {
                    Match match = myRegex.Match(line);

                    if (match.Success)
                    {
                        char symbol = match.Groups[1].Value[0];
                        int life = int.Parse(match.Groups[2].Value);
                        int strength = int.Parse(match.Groups[3].Value);
                        int defense = int.Parse(match.Groups[4].Value);
                        _builder.DefineFighter(symbol, life, strength, defense);
                    }

                    else
                    { 
                        for (int col = 0; col < line.Length; col++)
                        {
                            char currentCharacter = line[col];

                            if (elementsReader.TryGetValue(currentCharacter, out ElementRead? builderCommand))
                            {
                                builderCommand(row, col, currentCharacter);
                            }
                        }

                        row++;
                    }
                }

                _builder.Finish();
            }
        }
    }
}
