using System;
using System.Collections.Generic;

namespace A6
{
    public interface IDoctor: IComparable<IDoctor>
    {
        string Field{get;}
        long Salary{get;}
        string  University{get;}
        List<Patient> patients{get;}
        string Work();
    }
}
