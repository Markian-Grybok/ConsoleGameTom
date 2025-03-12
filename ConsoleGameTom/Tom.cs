using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameTom
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public sealed class Tom : Pixcel
    {

        #region ---- FIELDS ----

        private char[,] playerPix = new char[5, 5]
        {
            { '+','+','+','+','+' },
            { '+','+',' ','+','+' },
            { '+',' ','+',' ','+' },
            { '+',' ',' ',' ','+' },
            { '+','+','+','+','+' },
        };

        Map map = new Map();

        public Direction playerDirection { get; set; }

        #endregion

        #region ---- CTORS ----
        public Tom(int _x, int _y, ConsoleColor _playerColor, int _sizePix, Direction _playerDirection)
            : base(_x, _y, _playerColor, _sizePix)
        {
            playerDirection = _playerDirection;
            Draw();
        }

        #endregion

        #region ---- FUNKS ----
        public void Move(Direction direction)
        {
            Clear();


            switch (direction)
            {
                case Direction.Up:
                    if (map.walls[Y - 1, X] != '#')
                        Y = --Y;
                    break;
                case Direction.Down:
                    if (map.walls[Y + 1, X] != '#')
                        Y = ++Y;
                    break;
                case Direction.Left:
                    if (map.walls[Y, X - 1] != '#')
                        X = --X;
                    break;
                case Direction.Right:
                    if (map.walls[Y, X + 1] != '#')
                        X = ++X;
                    break;
                default:
                    break;
            }

            Draw();

        }

        public override void Draw()
        {
            Console.ForegroundColor = Color;

            for (int i = 0; i < SizePix; i++)
                for (int j = 0; j < SizePix; j++)
                {
                    Console.SetCursorPosition(X * SizePosition + i, Y * SizePosition + j);
                    Console.Write(playerPix[j, i]);
                }
        }

        #endregion

    }
}
