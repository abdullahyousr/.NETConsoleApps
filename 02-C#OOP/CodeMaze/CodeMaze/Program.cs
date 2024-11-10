





using CodeMaze.Models;

Console.WriteLine("Welcome to the maze game.");
Console.WriteLine("Use keyboard arrows to move the player");

Maze maze = new(40,20);

while(true)
{
maze.DrawMaze();
maze.MovePlayer();

}