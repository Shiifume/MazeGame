using Maze;
using Maze.MazeCreation;
using System.Text;


internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        MazeFactory factory = new();
        MazeModel model = factory.CreateMaze("firstReel");
        MazeVue vue = new();

        MazeControler controler = new() { Vue = vue, Model = model };

        controler.Start();

    }
}