﻿using System;
using System.IO;

namespace OOCalculator
{
    public class NegateOperator : UnaryOperator
    {
       public NegateOperator(TextReader reader)
        {
            throw new NotImplementedException();
        }

        public override string OperatorSymbol => throw new NotImplementedException();

        public override double Evaluate() => throw new NotImplementedException(); 
    }
}