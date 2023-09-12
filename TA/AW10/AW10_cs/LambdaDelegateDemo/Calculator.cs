using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaDelegateDemo
{
    public class Calculator : ICalculator
    {
        private readonly IToolBox _toolBox;
        
        public Calculator(IToolBox toolBox)
        {
            _toolBox = toolBox;
        }
        
        public List<int> Exp(List<int> numbers)
            => _toolBox.Map<int, int>(numbers, (t) => (int)Math.Exp(t)).ToList();

        public List<int> GetOdds(List<List<int>> matrix)
        {
            var l = _toolBox.FlatMap<int, int>(matrix, (i) => i);
            return _toolBox.Filter<int>(l, (i) => i%2 == 1).ToList();
        }

        public int SumOfExpOdds(List<List<int>> matrix)
        {
            var l = Exp(GetOdds(matrix));
            int sum = 0;
            foreach(int i in l)
                sum += i;
            return sum;
        }
    }
}