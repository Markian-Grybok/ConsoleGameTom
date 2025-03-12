using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameTom
{
    public sealed class BadGuy : Pixcel
    {

        #region ---- FIELDS ----

        private char[,] guyPix = new char[3, 3]
        {
            { '\\',' ','/' },
            { ' ','@',' ' },
            { '/',' ','\\' },
        };

        Map map = new Map();
        public Direction GuyDirection { get; set; }

        #endregion

        #region ---- CTORS ----

        public BadGuy(int _x, int _y, ConsoleColor _guyColor, int _sizePix, Direction _guyDirection) :
            base(_x, _y, _guyColor, _sizePix)
        {
            GuyDirection = _guyDirection;
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
                    if(map.walls[Y - 1, X] != '#')
                    {
                        Y = --Y;
                        Draw();
                    }
                    else
                    {
                        GuyDirection = Direction.Down;
                        Draw();
                    }
                    break;
                case Direction.Down:
                    if(map.walls[Y + 1, X] != '#')
                    {
                        Y = ++Y;
                        Draw();
                    }
                    else
                    {
                        GuyDirection = Direction.Up;
                        Draw();
                    }
                    break;
                case Direction.Left:
                    if (map.walls[Y, X - 1] != '#')
                    {
                        X = --X;
                        Draw();
                    }
                    else
                    {
                        GuyDirection = Direction.Right;
                        Draw();
                    }
                    break;
                case Direction.Right:
                    if (map.walls[Y, X + 1] != '#')
                    {
                        X = ++X;
                        Draw();
                    }
                    else
                    {
                        GuyDirection = Direction.Left;
                        Draw();
                    }                      
                    break;
                default:
                    break;
            }

        }

        public override void Draw()
        {
            Console.ForegroundColor = Color;

            for (int i = 0; i < SizePix; i++)
                for (int j = 0; j < SizePix; j++)
                {
                    Console.SetCursorPosition(X * SizePosition + i + 1, Y * SizePosition + j + 1);
                    Console.Write(guyPix[j, i]);
                   
                }
        }

        public override void Clear()
        {
            Console.ForegroundColor = Color;

            for (int i = 0; i < SizePix; i++)
                for (int j = 0; j < SizePix; j++)
                {
                    Console.SetCursorPosition(X * SizePosition + i + 1, Y * SizePosition + j + 1);
                    Console.Write(" ");
                }
        }

        #endregion

        #region ---- CHEСK FUNKS ----

        public override bool Equals(object? obj)
        {
            return obj is BadGuy guy &&
                   X == guy.X &&
                   Y == guy.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Tom player, BadGuy guy)
        {
            return player.X == guy.X && player.Y == guy.Y
                    || player.X == guy.X && player.Y == guy.Y
                    || player.X == guy.X && player.Y == guy.Y
                    || player.X == guy.X && player.Y == guy.Y;
        }

        public static bool operator !=(Tom player, BadGuy guy)
        {
            return player.X != guy.X && player.Y != guy.Y
                    || player.X != guy.X && player.Y != guy.Y
                    || player.X != guy.X && player.Y != guy.Y
                    || player.X != guy.X && player.Y != guy.Y;
        }

        #endregion

    }
}
