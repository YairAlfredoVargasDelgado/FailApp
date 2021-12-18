using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[AttributeUsage(AttributeTargets.All)
]
public class Ignore : Attribute
{
    public double version;

    public Ignore()
    {
        version = 1.0;
    }
}
