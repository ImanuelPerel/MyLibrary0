using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCsLibrary0.Games.BoardGames;

/// <summary>
/// represents all kind of two-dimantional direction of up,left,down,right, and all four diagonals
/// </summary>
public class Direction
{
    static public Direction Up=new Direction(0,1);
    static public Direction Down=new Direction(0,-1);
    static public Direction Right=new Direction(1,0);
    static public Direction Left=new Direction(-1,0);
    static public Direction UpRight=new Direction(1,1);
    static public Direction UpLeft=new Direction(-1,1);
    static public Direction DownRight=new Direction(1,-1);
    static public Direction DownLeft=new Direction(-1,-1);
    static public Direction[] FourDirection = [ Up, UpRight, Right, DownRight];
    static public Direction[] EightDirection = [ Up, UpRight, Right, DownRight,Down,DownLeft,Left,UpLeft];
    
    private int x;
    public int X { get => x; set { x = Math.Sign(value); } }

    private int y;
    public int Y { get => y; set { y = Math.Sign(value); } }
    protected Direction(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Overload for the unary minus operator
    public static Direction operator -(Direction dir)
    {
        return new Direction(-dir.X, -dir.Y);
    }
    public override string ToString()
    {
        return $"{nameof(X)}={X},{nameof(Y)}={Y}";
    }

}