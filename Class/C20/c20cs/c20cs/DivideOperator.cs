using System;
using System.IO;

namespace OOCalculator
{
    public class DivideOperator : BinaryOperator
    {
        public DivideOperator(TextReader reader)
        :base(reader)
        {
        }

        public override string OperatorSymbol => throw new NotImplementedException();

        public override double Evaluate() => throw new NotImplementedException();
    }
}