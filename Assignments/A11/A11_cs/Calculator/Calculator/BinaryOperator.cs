using System;
using System.IO;

namespace Calculator
{
    public abstract class BinaryOperator: Expression, IOperator
    {
        protected Expression LHS;
        protected Expression RHS;

        public BinaryOperator(TextReader reader)
        {
            LHS = GetNextExpression(reader);
            RHS = GetNextExpression(reader);
        }

        public BinaryOperator()
        {}

        public abstract string OperatorSymbol { get; }

        public sealed override string ToString() 
            => $"({this.LHS}{this.OperatorSymbol}{this.RHS})";

    }
}