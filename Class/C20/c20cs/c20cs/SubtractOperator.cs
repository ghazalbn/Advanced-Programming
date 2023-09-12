using System;
using System.IO;

namespace OOCalculator
{
    public class SubtractOperator : BinaryOperator
    {
        public SubtractOperator(TextReader reader)
        :base(reader)
        {
        }

        public override string OperatorSymbol => throw new NotImplementedException();

        public override double Evaluate() => throw new NotImplementedException();
    }
}