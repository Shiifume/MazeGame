using Maze.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    internal class MazeControler
    {
        public MazeVue Vue { set; get; }

        public MazeModel Model { set; get; }

        public void Start()
        {
            bool running = true;
            string errorMessage;
            Vue.Display(Model, "");

            while (running)
            {
                errorMessage = "";
                ConsoleKeyInfo key = Console.ReadKey(true);

                try
                {
                    switch(key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            Model.Move(Direction.NORD);
                            break;
                        case ConsoleKey.LeftArrow:
                            Model.Move(Direction.OUEST);
                            break;
                        case ConsoleKey.DownArrow:
                            Model.Move(Direction.SUD);
                            break;
                        case ConsoleKey.RightArrow:
                            Model.Move(Direction.EST);
                            break;
                    }
                }
                catch (OutOfMazeException e)
                {
                    errorMessage = e.Message;
                    running = false;
                }
                catch (MazeException e)
                {
                    errorMessage = e.Message;
                }

                if (key.Key == ConsoleKey.Q && key.Modifiers.HasFlag(ConsoleModifiers.Control) && key.Modifiers.HasFlag(ConsoleModifiers.Shift))
                {
                    running = false;
                    errorMessage = "Exiting game";
                }
                Vue.Display(Model, errorMessage);
            }
        }
    }
}
