using System;

namespace LOSHADY;

public class Helper
{
    public static void Place(char sym, int x, int y, ConsoleColor color)
    {
        if (x <= 1000 && y <= 1000)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                var defaultColor = Console.BackgroundColor;
                Console.ForegroundColor = color;
                Console.Write(sym);
                Console.ForegroundColor = defaultColor;
                Console.SetCursorPosition(0, 0);
            }
            catch (Exception e)
            {
            }
        }
        else if (x >= 1000 || y >= 1000)
        {
            Place(sym,x-Console.WindowWidth-30, y-Console.WindowHeight-30,color);
        }
        else if (x <= 0 || y <= 0)
        {
            Place(sym,x-Console.WindowWidth+30, y-Console.WindowHeight+30,color);
        }
    }
}