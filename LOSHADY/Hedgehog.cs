using System;
using System.Threading.Tasks;

namespace LOSHADY;

public class Hedgehog : Monster
{
    public ConsoleColor Color = ConsoleColor.DarkGray;
    public char Face = '*';

    public override void BeBorn(int x, int y, int weight)
    {
        (X, Y, Kg) = (x, y, weight);
        Helper.Place(Face, x, y, Color);
    }

    public override void Move(int dx = 1, int dy = 0)
    {
        (X, Y) = (X + dx, Y + dy);
        if (X > Console.WindowWidth - 1)
            X = 0 + dx;
        if (Y > Console.WindowHeight)
            Y = 0 + dy;
        if (X < 0)
            X = Console.BufferWidth + dx;
        if (Y < 0)
            Y = Console.BufferHeight + dy;
        Helper.Place(Face, X, Y, Color);
    }
}