using System.Threading.Tasks;

namespace LOSHADY;

public abstract class Monster
{
    protected int Kg;
    public int X, Y;

    public abstract void BeBorn(int x, int y, int weight);
    public abstract void Move(int dx, int dy);
}