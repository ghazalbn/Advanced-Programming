using System;
using System.IO;

namespace Calculator
{
    public class MultiplyOperator : BinaryOperator
    {
        public MultiplyOperator(TextReader reader)
        :base(reader){}

        public override string OperatorSymbol => "*";

        public override double Evaluate() 
                => LHS.Evaluate()*RHS.Evaluate();
    }
}