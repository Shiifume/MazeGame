using System;
using System.Collections.Generic;
using System.Text;
using Maze.MazeCreation.MazeContent;
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
                Console.Write($"{elem.Value.Symbol} ");
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
    }
}
