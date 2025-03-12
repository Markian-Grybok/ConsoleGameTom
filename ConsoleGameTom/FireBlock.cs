using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameTom
{
    public sealed class FireBlock : Pixcel
    {

        #region ---- CONSTS ----

        private const char RED_FIRE_PIX = '+';

        #endregion

        #region ---- CTORS ----
        public FireBlock(int _x, int _y, ConsoleColor _fireColor, int _sizePix) :
           base(_x, _y, _fireColor, _sizePix)
        {
            Draw();
        }

        #endregion

        #region ---- FUNKS ----
        public void ChangeColorAndSize(ConsoleColor _fireColor, int _sizePix)
        {
            Color = _fireColor;
            SizePix = _sizePix;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public void DrawKillFire()
        {
            Console.ForegroundColor = Color;

            for (int i = 0; i < SizePix; i++)
                for (int j = 0; j < SizePix; j++)
                {
                    Console.SetCursorPosition(X * SizePosition + i - 2, Y * SizePosition + j - 2);
                    Console.Write(RED_FIRE_PIX);
                }
        }

        public void ClearKillFire()
        {
            Console.ForegroundColor = Color;

            for (int i = 0; i < SizePix; i++)
                for (int j = 0; j < SizePix; j++)
                {
                    Console.SetCursorPosition(X * SizePosition + i - 2, Y * SizePosition + j - 2);
                    Console.Write(' ');
                }
        }

        #endregion

        #region ---- CHECK FUNKS ----

        public override bool Equals(object? obj)
        {
            return obj is FireBlock fire &&
                   X == fire.X &&
                   Y == fire.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Tom player, FireBlock fire)
        {
            return player.X + 1 == fire.X && player.Y == fire.Y
                     || player.X - 1 == fire.X && player.Y == fire.Y
                     || player.X == fire.X && player.Y + 1 == fire.Y
                     || player.X == fire.X && player.Y - 1 == fire.Y
                     || player.X + 1 == fire.X && player.Y + 1 == fire.Y
                     || player.X - 1 == fire.X && player.Y - 1 == fire.Y
                     || player.X - 1 == fire.X && player.Y + 1 == fire.Y
                     || player.X + 1 == fire.X && player.Y - 1 == fire.Y;
        }

        public static bool operator !=(Tom player, FireBlock fire)
        {
            return player.X + 1 != fire.X && player.Y != fire.Y
                     || player.X - 1 != fire.X && player.Y != fire.Y
                     || player.X != fire.X && player.Y + 1 != fire.Y
                     || player.X != fire.X && player.Y - 1 != fire.Y
                     || player.X + 1 != fire.X && player.Y + 1 != fire.Y
                     || player.X - 1 != fire.X && player.Y - 1 != fire.Y
                     || player.X - 1 != fire.X && player.Y + 1 != fire.Y
                     || player.X + 1 != fire.X && player.Y - 1 != fire.Y;
        }

        #endregion

    }
}
