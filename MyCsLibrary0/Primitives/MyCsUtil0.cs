using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCsLibrary0.Primitives;
/// <summary>
/// Useful ustilities for various little tasks
/// </summary>
/// <author>Emanuel Perel</author>
public static class MyCsUtil0
{ 
    static public bool EqualOrBothNull(object? value1, object? value2)
    {
        if (value1 == value2)
            return true;
        if (value1 == null || value2 == null)
            //since if they are both null we already returned true
            return false;
        return value1.Equals(value2);
    }
    static public bool AllEqual(IEnumerable<object?> objects)
    {
        if(!objects.Any()) 
            return true;
        object? first = objects.First();
        foreach(object? obj in objects)
        {
            if (!Equals(obj, first)) 
                return false;
        }
        return true;
    }
}
