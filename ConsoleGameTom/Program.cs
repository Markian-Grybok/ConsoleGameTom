using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleGameTom
{

    public class Program
    {

        private const int SCREEN_WIDTH = 38 * 5;
        private const int SCREEN_HEIGHT = 25 * 5;

        private const int GUYS_FRAME = 20;
        private const int STOP_PLAYER_FRAME = 300;
        private const int PLAYER_FRAME = 35;
        private const int YELLOW_BLOCK_FRAME = 500;
        private const int RED_BLOCK_FRAME = 800;

        private const ConsoleColor GUYS_COLOR = ConsoleColor.Gray;
        private const ConsoleColor STARS_COLOR = ConsoleColor.Cyan;
        private const ConsoleColor NEEDLS_COLOR = ConsoleColor.Red;
        private const ConsoleColor FIRES_COLOR = ConsoleColor.DarkGreen;
        private const ConsoleColor WALLS_COLOR = ConsoleColor.DarkBlue;
        private const ConsoleColor PLAYER_COLOR = ConsoleColor.DarkYellow;


        static void Main()
        {
            SetWindowSize(SCREEN_WIDTH, SCREEN_HEIGHT);
            SetBufferSize(SCREEN_WIDTH, SCREEN_HEIGHT);
            CursorVisible = false;

            Intro();

            StartGame();

            ReadKey();

        }

        static void StartGame()
        {
            Map walls = new Map(0, 0, WALLS_COLOR, 5);

            Tom tom = new Tom(34, 23, PLAYER_COLOR, 5, Direction.Down);


            Stopwatch sw1 = new Stopwatch();

            List<FireBlock> fires = new List<FireBlock>
            {
                new FireBlock(26, 18, FIRES_COLOR, 5),
                new FireBlock(20, 19, FIRES_COLOR, 5),
                new FireBlock(3, 22, FIRES_COLOR, 5),
                new FireBlock(6, 14, FIRES_COLOR, 5),
                new FireBlock(2, 8, FIRES_COLOR, 5),
                new FireBlock(12, 5, FIRES_COLOR, 5),
                new FireBlock(14, 15, FIRES_COLOR, 5),
                new FireBlock(17, 11, FIRES_COLOR, 5),
                new FireBlock(21, 7, FIRES_COLOR, 5),
                new FireBlock(24, 12, FIRES_COLOR, 5),
                new FireBlock(28, 7, FIRES_COLOR, 5),
            };

            List<Needl> needles = new List<Needl>
            {
                 new Needl(24, 19, NEEDLS_COLOR, 5, Position.Left),
                 new Needl(24, 20, NEEDLS_COLOR, 5, Position.Left),
                 new Needl(24, 21, NEEDLS_COLOR, 5, Position.Left),
                 new Needl(29, 20, NEEDLS_COLOR, 5, Position.Up),
                 new Needl(24, 23, NEEDLS_COLOR, 5, Position.Right),
                 new Needl(21, 15, NEEDLS_COLOR, 5, Position.Down),
                 new Needl(14, 20, NEEDLS_COLOR, 5, Position.Left),
                 new Needl(12, 19, NEEDLS_COLOR, 5, Position.Right),
                 new Needl(12, 20, NEEDLS_COLOR, 5, Position.Right),
                 new Needl(12, 21, NEEDLS_COLOR, 5, Position.Right),
                 new Needl(12, 22, NEEDLS_COLOR, 5, Position.Right),
                 new Needl(7, 22, NEEDLS_COLOR, 5, Position.Right),
                 new Needl(6, 20, NEEDLS_COLOR, 5, Position.Up),
                 new Needl(1, 21, NEEDLS_COLOR, 5, Position.Left),
                 new Needl(1, 22, NEEDLS_COLOR, 5, Position.Left),
                 new Needl(1, 23, NEEDLS_COLOR, 5, Position.Left),
                 new Needl(2, 14, NEEDLS_COLOR, 5, Position.Left),
                 new Needl(2, 15, NEEDLS_COLOR, 5, Position.Left),
                 new Needl(5, 11, NEEDLS_COLOR, 5, Position.Up),
                 new Needl(4, 1, NEEDLS_COLOR, 5, Position.Right),
                 new Needl(18, 14, NEEDLS_COLOR, 5, Position.Right),
                 new Needl(1, 5, NEEDLS_COLOR, 5, Position.Up),
                 new Needl(2, 5, NEEDLS_COLOR, 5, Position.Up),
                 new Needl(25, 5, NEEDLS_COLOR, 5, Position.Down),
                 new Needl(25, 7, NEEDLS_COLOR, 5, Position.Up),
                 new Needl(24, 7, NEEDLS_COLOR, 5, Position.Up),
                 new Needl(23, 7, NEEDLS_COLOR, 5, Position.Up),
                 new Needl(21, 12, NEEDLS_COLOR, 5, Position.Down),
                 new Needl(10, 14, NEEDLS_COLOR, 5, Position.Down),
                 new Needl(33, 16, NEEDLS_COLOR, 5, Position.Right),
                 new Needl(31, 9, NEEDLS_COLOR, 5, Position.Left),
                 new Needl(31, 10, NEEDLS_COLOR, 5, Position.Left),
                 new Needl(32, 1, NEEDLS_COLOR, 5, Position.Right),
            };

            List<BadGuy> guys = new List<BadGuy>
            {
                 new BadGuy(27, 20, GUYS_COLOR, 3, Direction.Up),
                 new BadGuy(21, 17, GUYS_COLOR, 3, Direction.Left),
                 new BadGuy(14, 21, GUYS_COLOR, 3, Direction.Left),
                 new BadGuy(2, 21, GUYS_COLOR, 3, Direction.Up),
                 new BadGuy(6, 3, GUYS_COLOR, 3, Direction.Left),
                 new BadGuy(12, 7, GUYS_COLOR, 3, Direction.Down),
                 new BadGuy(12, 16, GUYS_COLOR, 3, Direction.Left),
                 new BadGuy(16, 6, GUYS_COLOR, 3, Direction.Left),
                 new BadGuy(17, 4, GUYS_COLOR, 3, Direction.Right),
                 new BadGuy(24, 4, GUYS_COLOR, 3, Direction.Up),
                 new BadGuy(23, 14, GUYS_COLOR, 3, Direction.Up),
                 new BadGuy(29, 14, GUYS_COLOR, 3, Direction.Left),
                 new BadGuy(28, 4, GUYS_COLOR, 3, Direction.Right),
                 new BadGuy(35, 2, GUYS_COLOR, 3, Direction.Down),
            };

            List<Star> stars = new List<Star>
            {
                 new Star(4, 14, STARS_COLOR, 3),
                 new Star(9, 10, STARS_COLOR, 3),
                 new Star(1, 12, STARS_COLOR, 3),
                 new Star(1, 1, STARS_COLOR, 3),
                 new Star(8, 1, STARS_COLOR, 3),
                 new Star(8, 17, STARS_COLOR, 3),
                 new Star(15, 1, STARS_COLOR, 3),
                 new Star(29, 23, STARS_COLOR, 3),
                 new Star(21, 14, STARS_COLOR, 3),
                 new Star(18, 23, STARS_COLOR, 3),
                 new Star(9, 21, STARS_COLOR, 3),
                 new Star(25, 1, STARS_COLOR, 3),
                 new Star(20, 10, STARS_COLOR, 3),
                 new Star(25, 9, STARS_COLOR, 3),
                 new Star(31, 13, STARS_COLOR, 3),
                 new Star(33, 10, STARS_COLOR, 3),
                 new Star(27, 1, STARS_COLOR, 3),
                 new Star(36, 7, STARS_COLOR, 3),
                 new Star(36, 14, STARS_COLOR, 3),
            };

            List<Star> score = new List<Star>();

            while (score.Count != stars.Count)
            {
                Cheaker(tom, sw1, guys, needles, stars, score);

                GuyMove(guys, tom, sw1, fires, needles, stars, score);

                foreach (var fire in fires)
                {
                    if (tom == fire)
                        BadContact(fire, tom, sw1, guys, needles, stars, score);
                }
            }

            Win(score);

            while(true) {}
        }

        static void BadContact(FireBlock fire, Tom tom, Stopwatch sw1, List<BadGuy> guys, List<Needl> needles, List<Star> stars, List<Star> score)
        {


            Stopwatch sw2 = new Stopwatch();
            sw2.Restart();
            var killfire = new FireBlock(fire.X, fire.Y, ConsoleColor.Yellow, fire.SizePix);
            while (sw2.ElapsedMilliseconds <= YELLOW_BLOCK_FRAME)
            {
                Cheaker(tom, sw1, guys, needles, stars, score);

                GuyMoveStan(guys, tom, sw1, needles, killfire, stars, score);
            }
            fire.Clear();
            killfire.ChangeColorAndSize(ConsoleColor.Red, fire.SizePix + 4);
            killfire.DrawKillFire();
            sw2.Restart();
            while (sw2.ElapsedMilliseconds <= RED_BLOCK_FRAME)
            {
                if (tom == killfire)
                    GameOver(score, stars);

                Cheaker(tom, sw1, guys, needles, stars, score);

                GuyMoveStan(guys, tom, sw1, needles, killfire, stars, score);
            }
            killfire.ClearKillFire();
            fire.Draw();
        }

        static void GuyMove(List<BadGuy> guys, Tom tom, Stopwatch sw1, List<FireBlock> fires, List<Needl> needles, List<Star> stars, List<Star> score)
        {
            foreach (var guy in guys)
            {
                Stopwatch sw = new Stopwatch();

                sw.Restart();

                while (sw.ElapsedMilliseconds <= GUYS_FRAME)
                {
                    Cheaker(tom, sw1, guys, needles, stars, score);

                    foreach (var fire in fires)
                        if (tom == fire)
                            BadContact(fire, tom, sw1, guys, needles, stars, score);
                }

                guy.Move(guy.GuyDirection);
            }
        }

        static void GuyMoveStan(List<BadGuy> guys, Tom tom, Stopwatch sw1, List<Needl> needles, FireBlock fire, List<Star> stars, List<Star> score)
        {
            foreach (var guy in guys)
            {
                Stopwatch sw = new Stopwatch();

                sw.Restart();

                while (sw.ElapsedMilliseconds <= GUYS_FRAME)
                {
                    Cheaker(tom, sw1, guys, needles, stars, score);

                    if (tom == fire && fire.Color != ConsoleColor.Yellow)
                        GameOver(score, stars);
                }

                guy.Move(guy.GuyDirection);
            }
        }

        static void Cheaker(Tom tom, Stopwatch sw1, List<BadGuy> guys, List<Needl> needles, List<Star> stars, List<Star> score)
        {
            PlayerMove(tom, sw1, guys, score, stars);

            foreach (var needl in needles)
            {
                if (tom == needl)
                    GameOver(score, stars);
            }

            foreach (var guy in guys)
            {
                if (tom == guy)
                    GameOver(score, stars);
            }

            foreach (var star in stars)
            {
                if (tom == star && !score.Contains(star))
                {
                    Task.Run(() => Beep(750, 150));
                    score.Add(star);
                }
            }
        }

        static void PlayerMove(Tom player, Stopwatch sw1, List<BadGuy> guys, List<Star> score, List<Star> stars)
        {
            Stopwatch sw = new Stopwatch();

            sw.Restart();

            while (sw.ElapsedMilliseconds <= PLAYER_FRAME)
            {
                foreach (var guy in guys)
                {
                    if (player == guy)
                        GameOver(score, stars);
                }

                if (sw1.ElapsedMilliseconds >= STOP_PLAYER_FRAME || !sw1.IsRunning)
                {
                    if (KeyAvailable)
                        ReadMove(player);
                    sw1.Restart();
                }

            }

            player.Move(player.playerDirection);
        }

        static void ReadMove(Tom player)
        {
            ConsoleKey key = ReadKey(true).Key;
            Task.Run(() => Beep(200, 170));
            player.playerDirection = key switch
            {
                ConsoleKey.UpArrow => Direction.Up,
                ConsoleKey.DownArrow => Direction.Down,
                ConsoleKey.LeftArrow => Direction.Left,
                ConsoleKey.RightArrow => Direction.Right,
                _ => player.playerDirection
            };
        }

        static void GameOver(List<Star> score, List<Star> stars)
        {
            Thread.Sleep(300);
            Clear();
            Task.Run(() => Beep(800, 200));
            Task.Run(() => Beep(700, 250));
            Task.Run(() => Beep(500, 500));
            Task.Run(() => Beep(300, 800));
            SetCursorPosition(SCREEN_WIDTH / 2 - 6, SCREEN_HEIGHT / 2);
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine("GAME OVER");
            SetCursorPosition(SCREEN_WIDTH / 2 - 7, SCREEN_HEIGHT / 2 + 2);
            WriteLine("YOUR SCORE {0}/{1}", score.Count, stars.Count);
            SetCursorPosition(SCREEN_WIDTH / 2 - 16, SCREEN_HEIGHT / 2 + 4);
            WriteLine("PRESS KEY (R) TO RESTART GAME");
            ConsoleKey key;
            do
            {
                key = ReadKey(true).Key;
            } 
            while (key != ConsoleKey.R);
            Clear();
            StartGame();

        }

        static void Win(List<Star> score)
        {
            Clear();
            Task.Run(() => Beep(300, 500));
            Task.Run(() => Beep(300, 500));
            Task.Run(() => Beep(300, 500));
            SetCursorPosition(SCREEN_WIDTH / 2 - 6, SCREEN_HEIGHT / 2);
            ForegroundColor = ConsoleColor.Green;
            WriteLine("YOU WIN");
            SetCursorPosition(SCREEN_WIDTH / 2 - 13, SCREEN_HEIGHT / 2 + 2);
            WriteLine("YOU HAVE MAX SCORE {0}", score.Count);
        }

        static void Intro()
        {
            ForegroundColor = ConsoleColor.White;
            SetCursorPosition(SCREEN_WIDTH / 2 - 18, SCREEN_HEIGHT / 2 + 2);
            WriteLine("To win the game you need to collect all the stars");
            SetCursorPosition(SCREEN_WIDTH / 2 - 13, SCREEN_HEIGHT / 2 + 5);
            WriteLine("Example of a star: ");
            new Star(20, 13, STARS_COLOR, 3);
            SetCursorPosition(SCREEN_WIDTH / 2 - 16, SCREEN_HEIGHT / 2 + 9);
            ForegroundColor = ConsoleColor.White;
            WriteLine("PRESS KEY (S) TO START GAME");
            ConsoleKey key;
            do
            {
                key = ReadKey(true).Key;
            }
            while (key != ConsoleKey.S);
            Clear();
        }

    }


}