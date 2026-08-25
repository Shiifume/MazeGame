using System;
using System.Collections.Generic;
using System.Text;
using Maze.MazeCreation.MazeContent;
using Maze.MazeCreation.MazeContent.Elements;
using Maze.MazeCreation.MazeContent.Mobs_Characters;

namespace Maze
{
    internal class MazeVue
    {
        public void Display(MazeModel model, string message)
        {

            int previousLine = 0, previousColumn = 0;

            Console.Clear();

            //diplays title
            Console.WriteLine($"{model.Name}");

            //diplays elements
            foreach(var elem in model)
            {
                while(elem.Key.Line > previousLine)
                {
                    Console.Write('\n');
                    previousLine++;
                    previousColumn = 0;
                }
                while(elem.Key.Col > previousColumn)
                {
                    Console.Write("  ");
                    previousColumn++;
                }
                Console.Write($"{(elem.Value is Wall ? GetWallChar(model, elem.Key) : elem.Value.Symbol)}{GetSeparatorChar(model, elem.Key)}");
                previousColumn++;
            }
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();

            //display of the players in the maze, who the current player is, and their stats/inventory
            var enumerator = model.ActivePersonnages;
            string activePerso = "=> ", inactivePerso = "   ", inventory = "";

            while (enumerator.MoveNext())
            {
                inventory = "";
                Personnage item = enumerator.Current;
                foreach(IMazeObject bagItem in item.Bag)
                {
                    if (!inventory.Equals(""))
                        inventory += ",";
                    inventory += bagItem == item.ActiveObject ? $"->{bagItem.Name}<-" : bagItem.Name;
                }

                Console.WriteLine($"{(item == model.Personnage ? activePerso : inactivePerso)} {item.Symbol} :{{ vie: {item.Life}, force: {item.Strength}, défense: {item.Defense}, inventaire [{inventory}] }}");
            }
        }

        public char GetWallChar(MazeModel model, MazePosition? wallPos)
        {
            WallConnections connections = WallConnections.NONE;

            //checks all neighbors
            if (model[wallPos[Direction.NORD]] is Wall || model[wallPos[Direction.NORD]] is Door)
                connections |= WallConnections.UP;
            if (model[wallPos[Direction.SUD]] is Wall || model[wallPos[Direction.SUD]] is Door)
                connections |= WallConnections.DOWN;
            if (model[wallPos[Direction.EST]] is Wall || model[wallPos[Direction.EST]] is Door)
                connections |= WallConnections.RIGHT;
            if (model[wallPos[Direction.OUEST]] is Wall || model[wallPos[Direction.OUEST]] is Door)
                connections |= WallConnections.LEFT;

            if (model[wallPos[Direction.NORD][Direction.EST]] is Wall || model[wallPos[Direction.NORD][Direction.EST]] is Door)
                connections |= WallConnections.DIAGUPRIGHT;
            if (model[wallPos[Direction.NORD][Direction.OUEST]] is Wall || model[wallPos[Direction.NORD][Direction.OUEST]] is Door)
                connections |= WallConnections.DIAGUPLEFT;
            if (model[wallPos[Direction.SUD][Direction.EST]] is Wall || model[wallPos[Direction.SUD][Direction.EST]] is Door)
                connections |= WallConnections.DIAGDOWNRIGHT;
            if (model[wallPos[Direction.SUD][Direction.OUEST]] is Wall || model[wallPos[Direction.SUD][Direction.OUEST]] is Door)
                connections |= WallConnections.DIAGDOWNLEFT;

            //checks flags
            char charToReturn = '!';

            if (connections == WallConnections.ALL)
                charToReturn = ' ';
            else
            {
                WallConnections normalConnections = connections & (WallConnections.UP | WallConnections.DOWN | WallConnections.RIGHT | WallConnections.LEFT);

                switch (normalConnections)
                {
                    case WallConnections.NONE:
                        charToReturn = '⛋';
                        break;

                    case WallConnections.UP | WallConnections.DOWN:
                        charToReturn = '║';
                        break;
                    case WallConnections.LEFT | WallConnections.RIGHT:
                        charToReturn = '═';
                        break;

                    case WallConnections.UP | WallConnections.LEFT:
                        charToReturn = '╝';
                        break;
                    case WallConnections.UP | WallConnections.RIGHT:
                        charToReturn = '╚';
                        break;
                    case WallConnections.DOWN | WallConnections.LEFT:
                        charToReturn = '╗';
                        break;
                    case WallConnections.DOWN | WallConnections.RIGHT:
                        charToReturn = '╔';
                        break;

                    case WallConnections.DOWN | WallConnections.LEFT | WallConnections.RIGHT:
                        charToReturn = '╦';
                        break;
                    case WallConnections.UP | WallConnections.LEFT | WallConnections.RIGHT:
                        charToReturn = '╩';
                        break;
                    case WallConnections.UP | WallConnections.DOWN |  WallConnections.RIGHT:
                        charToReturn = '╠';
                        break;
                    case WallConnections.UP | WallConnections.DOWN | WallConnections.LEFT :
                        charToReturn = '╣';
                        break;





                    case WallConnections.UP | WallConnections.DOWN | WallConnections.LEFT | WallConnections.RIGHT:
                        charToReturn = '╬';
                        break;
                }
            }


            return charToReturn;
        }
    
        public char GetSeparatorChar(MazeModel model, MazePosition wallPos)
        {
            if ((model[wallPos] is Wall || model[wallPos] is Door) && (model[wallPos[Direction.EST]] is Wall || model[wallPos[Direction.EST]] is Door))
                return '═';
            else
                return ' ';
        }

    }

    [Flags]
    public enum WallConnections
    {
        NONE = 0,
        UP = 1,
        DOWN = 2,
        RIGHT = 4,
        LEFT = 8, 

        DIAGUPRIGHT = 16,
        DIAGUPLEFT = 32,
        DIAGDOWNRIGHT = 64,
        DIAGDOWNLEFT = 128,

        ALL = UP | DOWN | RIGHT | LEFT | DIAGUPRIGHT | DIAGUPLEFT | DIAGDOWNRIGHT | DIAGDOWNLEFT
    }
}
