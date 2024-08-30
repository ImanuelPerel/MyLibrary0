using MyCsLibrary0.Primitives;
using MyCsLibrary0.Games.BoardGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace myCsLibrary0.Games.BoardGames;

public class Board<T>
{
    public T[,] board;
    protected int howManyThere(int x, int y, T target, Direction dir)
    {
        if (!ValidateIndices(x, y)) return 0;
        if (board[x, y] is null || !board[x, y]!.Equals(target)) return 0;
        return 1 + howManyThere(x + dir.X, y + dir.Y, target, dir);
    }
    protected bool ValidateIndices(int x, int y)
    {
        return (x >= 0 && y >= 0 && x < board.GetLength(0) && y < board.GetLength(1));
    }
    /// <summary>
    /// returns the the taget that in that spot if there are n in a row for any direction from this particular spot (x,y)
    /// </summary>
    /// <param name="howManyNeeded">howManyNeeded</param>
    /// <param name="x">the index on the x axis</param>
    /// <param name="y">the index on the y axis</param>
    /// <returns>null if nobody is there</returns>

    public object? AreThereNInARowOneDirection(int x, int y, int howManyNeeded, Func<T, object?>? key = null)
    {
        if (!ValidateIndices(x, y)) return null;
        object? target = (key is null) ? board[x, y] : key!(board[x, y]);
        foreach (Direction dir in Direction.EightDirection)
        {
            if (howManyThereTwoDoubleDirection(x, y, board[x, y], dir, key, target) >= howManyNeeded)
            {
                return target;
            }
        }
        return null;
    }
    public object? AreThereNInARowDoubleDirection(int x, int y, int howManyNeeded,Func<T,object?>? key=null)
    {
        if (!ValidateIndices(x, y)) return null;
        object? target = (key is null) ? board[x, y] : key!(board[x, y]);
        foreach (Direction dir in Direction.FourDirection)
        {
            if (howManyThereTwoDoubleDirection(x, y, board[x,y],dir,key,target)>=howManyNeeded)
                return target;
        }
        return null;
    }
    private int howManyThere(int x, int y, T target, Direction dir, Func<T, object?>? key = null, object? calculatedValue = null)
    {
        if (!ValidateIndices(x, y))
            return 0;
        T current = board[x,y];
        if (calculatedValue is null && key is not null)
            calculatedValue = key(current);
        if (
            (key is null) ? 
            (!MyCsUtil0.EqualOrBothNull(current,target)):
            (!MyCsUtil0.EqualOrBothNull(key(current),calculatedValue))
            )
            return 0;
        return 1 + howManyThere(x + dir.X, y + dir.Y, target, dir, key, calculatedValue);
    }
    private int howManyThereTwoDoubleDirection(int x, int y, T target, Direction dir, Func<T, object?>? key = null, object? calculatedValue = null)
    {
        return -1 + howManyThere(x, y, target, dir, key, calculatedValue) + howManyThere(x, y, target, -dir, key, calculatedValue);
    }
    

}