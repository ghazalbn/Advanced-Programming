using System;
using System.Collections.Generic;
using System.Drawing;

namespace Exam1_cs
{
    public interface IDriver : IComparable
    {
        Color Color{get; set;}
        List<Traffic> History{get; set;}
        void GoToTarget(Customer c, ILocatable i);
    }
}