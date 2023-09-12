using System;
using System.IO;

namespace Calculator
{
    public class NegateOperator : UnaryOperator
    {
        public NegateOperator(TextReader reader)
        :base(reader){}

        public override string OperatorSymbol => "-";

        public override double Evaluate() 
            => -Operand.Evaluate();
    }
}