using Maze.Exceptions;
using Maze.MazeCreation.MazeContent.Mobs_Characters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Maze.MazeCreation.MazeContent.Objects;

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
                        case ConsoleKey.Spacebar:
                            if(Model.Personnage.Bag.Count() > 0)
                                ExploreBag();
                            break;
                        case ConsoleKey.Tab:
                            Model.ActivatePersonnage();
                            break;
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
                        default:
                            if (char.IsLetter(key.KeyChar))
                            {
                                Model.ActivatePersonnage(key.KeyChar);
                            }
                            break;
                    }
                }
                catch (UnusableObjectException e)
                {
                    errorMessage = e.Message;
                }
                catch (OutOfMazeException e)
                {
                    errorMessage = e.Message;
                    running = false;
                }
                catch (MazeCharacterCollisionException e)
                {
                    errorMessage = e.Message;
                }
                catch (MazePlayerDeadException e)
                {
                    errorMessage = e.Message;
                    running = false;
                }
                catch (MazeMonsterException e)
                {
                    errorMessage = e.Message;
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

        public void ExploreBag()
        {
            bool running = true;

            Model.Personnage.ActivateBag();

            Vue.Display(Model, "");

            while(running)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch(key.Key)
                {
                    case ConsoleKey.Enter:
                        if (Model.Personnage.ActiveObject is IUsable usableObject)
                        {
                            usableObject.Use(Model.Personnage);
                            Model.Personnage.Bag.Remove(Model.Personnage.ActiveObject);
                            running = false;
                        }
                        else
                        {
                            Model.Personnage.DeactivateBag();
                            throw new UnusableObjectException("Cet objet ne peut pas être consommé.");
                        }
                        break;
                    case ConsoleKey.Escape:
                        running = false;
                        break;
                    case ConsoleKey.LeftArrow:
                        Model.Personnage.PreviousObject();
                        break;
                    case ConsoleKey.RightArrow:
                        Model.Personnage.NextObject(); 
                        break;
                }

                Vue.Display(Model, "");
            }
            Model.Personnage.DeactivateBag();
        }
    }
}
