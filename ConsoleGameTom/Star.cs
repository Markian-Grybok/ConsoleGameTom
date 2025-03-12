using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameTom
{
    public sealed class Star : Pixcel
    {

        #region ---- FIELDS ----

        private char[,] starPix = new char[3, 3]
        {
            { ' ','■',' ' },
            { '■','+','■' },
            { ' ','■',' ' },
        };

        #endregion

        #region ---- CTORS ----
        public Star(int _x, int _y, ConsoleColor _starColor, int _sizePix) :
           base(_x, _y, _starColor, _sizePix)
        {
            Draw();
        }

        #endregion

        #region ---- FUNKS ----
        public override void Draw()
        {
            Console.ForegroundColor = Color;

            for (int i = 0; i < SizePix; i++)
                for (int j = 0; j < SizePix; j++)
                {
                    Console.SetCursorPosition(X * SizePosition + i + 1, Y * SizePosition + j + 1);
                    Console.Write(starPix[j, i]);
                }
        }

        #endregion

        #region ---- CHECK FUNKS ----
        public override bool Equals(object? obj)
        {
            return obj is Star star &&
                   X == star.X &&
                   Y == star.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Tom player, Star star)
        {
            return player.X == star.X && player.Y == star.Y
                    || player.X == star.X && player.Y == star.Y
                    || player.X == star.X && player.Y == star.Y
                    || player.X == star.X && player.Y == star.Y;
        }

        public static bool operator !=(Tom player, Star star)
        {
            return player.X != star.X && player.Y != star.Y
                    || player.X != star.X && player.Y != star.Y
                    || player.X != star.X && player.Y != star.Y
                    || player.X != star.X && player.Y != star.Y;
        }

        #endregion

    }
}
