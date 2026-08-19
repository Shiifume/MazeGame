using Maze;
using Maze.MazeCreation;

internal class Program
{
    private static void Main(string[] args)
    {
        MazeFactory factory = new();
        MazeModel model = factory.CreateMaze("firstReel");
        MazeVue vue = new();

        MazeControler controler = new() { Vue = vue, Model = model };

        controler.Start();

    }
}