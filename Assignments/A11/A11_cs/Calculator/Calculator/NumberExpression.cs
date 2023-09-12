using System;
using System.IO;

namespace Calculator
{
    public class NumberExpression : Expression
    {
        protected double Number;

        public NumberExpression(string line)
            => Number = line == null? 0: double.Parse(line);

        public override double Evaluate() => Number;

        public override string ToString() => Number.ToString();
    }
}