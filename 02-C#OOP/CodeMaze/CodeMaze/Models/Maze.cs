using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMaze.Models
{
    internal class Maze
    {
        private int _width;
        private int _height;
        private Player _Player;
        private IMazeObject[,] _MazeObjectsArray;

        public Maze(int width, int height)
        {
            _height = height;
            _width = width;
            _MazeObjectsArray = new IMazeObject[width, height];
            _Player = new()
            {
                X = 1,
                Y = 1,
            };
        }

        public void DrawMaze()
        {
            Console.Clear();
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (y == _height - 2 && x == _width -1)
                    {
                        _MazeObjectsArray[x, y] = new EmptySpace();

                        Console.Write(_MazeObjectsArray[x, y].Icon);
                    }else if (y == 0 || y == _height -1 || x == 0 || x == _width -1)
                    {
                        _MazeObjectsArray[x,y] = new Wall();

                        Console.Write(_MazeObjectsArray[x, y].Icon);
                    }
                    else if(x == _Player.X && y == _Player.Y)
                    {

                        Console.Write(_Player.Icon);
                    }
                    else if(x % 3 == 0 && y%3 ==0)
                    {
                        _MazeObjectsArray[x, y] = new Wall();

                        Console.Write(_MazeObjectsArray[x, y].Icon);
                    }
                    else
                    {
                        _MazeObjectsArray[x,y] = new EmptySpace();

                        Console.Write(_MazeObjectsArray[x,y].Icon);
                    }
                }
                Console.WriteLine();
            }
        }

        public void MovePlayer()
        {
            ConsoleKeyInfo userKeyInput = Console.ReadKey();

            ConsoleKey key = userKeyInput.Key;

            switch(key)
            {
                case ConsoleKey.UpArrow:
                    UpdatePlayer(0, -1);
                        break;
                case ConsoleKey.DownArrow:
                    UpdatePlayer(0,1);
                    break;
                case ConsoleKey.LeftArrow:
                    UpdatePlayer(-1,0);
                    break;
                case ConsoleKey.RightArrow:
                    UpdatePlayer(1, 0);
                    break;
            }
        }

        public void UpdatePlayer(int dx, int dy)
        {
            int newx = dx + _Player.X;
            int newy = dy + _Player.Y;

            if(newx < _width && newy < _height && newx >= 0 && newy >= 0 && !_MazeObjectsArray[newx,newy].IsSolid)
            {
                _Player.X = newx;
                _Player.Y = newy;
            }
            DrawMaze();
        }
    }
}
