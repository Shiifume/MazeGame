using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Maze.MazeCreation
{
    internal class MazeFileReader
    {
        private IMazeBuilder _builder;
        private Dictionary<char, ElementRead> elementsReader;
        
        public MazeFileReader(IMazeBuilder builder)
        {
            _builder = builder;
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
                        if (currentCharacter != ' ')
                        {
                            Console.WriteLine($"char : {(char)readerCharacter}, row : {row}, col : {col} ");
                        }
                        col++;    
                    }

                }

                _builder.Finish();
            }
        }
    }
}
