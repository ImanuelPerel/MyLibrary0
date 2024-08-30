using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCsLibrary0.Primitives;

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
}
