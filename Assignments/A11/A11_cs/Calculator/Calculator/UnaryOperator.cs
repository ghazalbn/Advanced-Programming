using System;
using System.IO;

namespace Calculator
{
    public abstract class UnaryOperator: Expression, IOperator
    {
        protected Expression Operand;

        public UnaryOperator(){}

        public UnaryOperator(TextReader reader)
            => Operand = GetNextExpression(reader);

        public sealed override string ToString() 
            => $"{this.OperatorSymbol}({this.Operand})";

        public abstract string OperatorSymbol { get; }
    }
}