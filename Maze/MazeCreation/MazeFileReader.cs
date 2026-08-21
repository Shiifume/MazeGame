using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;

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
                elementsReader.Add(character, (row, col, c) => _builder.AddCharacter(row, col, c));
            }
        }

        public void Read(string mazeName)
        {
            string filePath = "../../../MazeFiles/" + mazeName + ".maze";
            
            //to do : try catch on reader to check if file exists

            using (StreamReader lecteur = new StreamReader(filePath))
            {
                _builder.Start(mazeName);

                int readerCharacter, row = 0, col = 0;
                char currentCharacter;

                while((readerCharacter = lecteur.Read()) != -1)
                {
                    currentCharacter = (char)readerCharacter;

                    if(currentCharacter == '\n')
                    {
                        col = 0;
                        row++;
                    }
                    else if(currentCharacter != '\r')
                    {
                        if(elementsReader.TryGetValue(currentCharacter, out ElementRead? builderCommand))
                        {
                            builderCommand(row, col, currentCharacter);
                        }

                        col++;    
                    }

                }

                _builder.Finish();
            }
        }
    }
}
