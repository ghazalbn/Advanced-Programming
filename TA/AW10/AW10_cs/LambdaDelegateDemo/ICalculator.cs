using System.Collections.Generic;

namespace LambdaDelegateDemo
{
    public interface ICalculator
    {
        List<int> Exp(List<int> numbers);
        List<int> GetOdds(List<List<int>> matrix);
        int SumOfExpOdds(List<List<int>> matrix);
    }
}