using System;

namespace LOSHADY
{
    public class Dog : Monster
    {
        private static Random _random = new Random();
        public ConsoleColor Color;
        public const char Face = '@';

        public Dog()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            Color = (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
        }

        public override void BeBorn(int x, int y, int weight)
        {
            (X, Y, Kg) = (x, y, weight);
            if (weight > 40)
                Color = ConsoleColor.Gray;

            Helper.Place(Face, x, y, Color);
        }

        public override void Move(int dx = 0, int dy = 1)
        {
            (X, Y) = (X + dx, Y + dy);
            if (X > Console.WindowWidth - 1)
                X = 0 + dx;
            if (Y > Console.WindowHeight)
                Y = 0 + dy;
            if (X < 0)
                X = Console.BufferWidth + dx;
            if (Y < 0)
                Y = Console.WindowHeight + dy;
            Helper.Place(Face, X, Y, Color);
        }
    }
}