using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameTom
{
    public abstract class Pixcel
    {

        #region ---- CONSTS ----

        public const int SizePosition = 5;
        private const char MyPixcel = '▓';

        #endregion

        #region ---- FIELDS ----

        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }
        public int SizePix { get; set; }

        #endregion

        #region ---- CTORS ----

        protected Pixcel()
        {
                
        }

        public Pixcel(int _x, int _y, ConsoleColor _color, int _sizePix)
        {
            X = _x;
            Y = _y;
            Color = _color;
            SizePix = _sizePix;
        }

        #endregion

        #region ---- FUNKS ----

        public virtual void Draw()
        {
            Console.ForegroundColor = Color;

            for (int i = 0; i < SizePix; i++)
                for (int j = 0; j < SizePix; j++)
                {
                    Console.SetCursorPosition(X * SizePosition + i, Y * SizePosition + j);
                    Console.Write(MyPixcel);
                }

        }

        public virtual void Clear()
        {
            for (int i = 0; i < SizePix; i++)
                for (int j = 0; j < SizePix; j++)
                {
                    Console.SetCursorPosition(X * SizePosition + i, Y * SizePosition + j);
                    Console.Write(' ');
                }
        }

        #endregion

    }
}
