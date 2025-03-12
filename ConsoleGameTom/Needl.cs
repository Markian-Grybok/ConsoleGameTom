using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameTom
{
    public enum Position
    {
        Up,
        Down,
        Left,
        Right
    }

    public sealed class Needl : Pixcel
    {

        #region ---- CONSTS ----

        private const char PIX = '+';

        #endregion

        #region ---- FIELDS ----

        private Position needlDirection;
        #endregion

        #region ---- CTORS ----
        public Needl(int _x, int _y, ConsoleColor _needlColor, int _sizePix, Position _needlDirection) :
            base(_x, _y, _needlColor, _sizePix)
        {
            needlDirection = _needlDirection;

            Draw();
        }

        #endregion

        #region ---- FUNKS ----
        public override void Draw()
        {
            switch (needlDirection)
            {
                case Position.Up:
                    {
                        Console.ForegroundColor = Color;

                        for (int i = 0; i < SizePix; i++)
                        {
                            Console.SetCursorPosition(X * SizePosition + i, Y * SizePosition);
                            Console.Write(PIX);
                        }
                    }
                    break;
                case Position.Down:
                    {
                        Console.ForegroundColor = Color;

                        for (int i = 0; i < SizePix; i++)
                        {
                            Console.SetCursorPosition(X * SizePosition + i, Y * SizePosition + 4);
                            Console.Write(PIX);
                        }
                    }
                    break;
                case Position.Left:
                    {
                        Console.ForegroundColor = Color;

                        for (int i = 0; i < SizePix; i++)
                        {
                            Console.SetCursorPosition(X * SizePosition, Y * SizePosition + i);
                            Console.Write(PIX);
                        }
                    }
                    break;
                case Position.Right:
                    {
                        Console.ForegroundColor = Color;

                        for (int i = 0; i < SizePix; i++)
                        {
                            Console.SetCursorPosition(X * SizePosition + 4, Y * SizePosition + i);
                            Console.Write(PIX);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region ---- CHECK FUNKS ----
        public override bool Equals(object? obj)
        {
            return obj is Needl needl &&
                   X == needl.X &&
                   Y == needl.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Tom player, Needl needl)
        {
            return player.X == needl.X && player.Y == needl.Y
                    || player.X == needl.X && player.Y == needl.Y
                    || player.X == needl.X && player.Y == needl.Y
                    || player.X == needl.X && player.Y == needl.Y;
        }

        public static bool operator !=(Tom player, Needl needl)
        {
            return player.X != needl.X && player.Y != needl.Y
                    || player.X != needl.X && player.Y != needl.Y
                    || player.X != needl.X && player.Y != needl.Y
                    || player.X != needl.X && player.Y != needl.Y;
        }

        #endregion

    }
}
