using System.Collections.Generic;
using System.Linq;
using LambdaDelegateDemo;
using NUnit.Framework;

namespace LambdaDemo.Tests
{
    public class Tests
    {
        private IToolBox _toolBox;
        private ICalculator _calculator;

        private List<int> _vector1;
        private List<int> _vector1Exp;
        
        private List<List<int>> _matrix1;
        private List<int> _matrix1OddsVector;
        private int _matrix1OddsVectorExpSum;

        [SetUp]
        public void Setup()
        {
            _toolBox = new MyToolBox();
            _calculator = new Calculator(_toolBox);

            _vector1 = new[] {5, 1, 0, -1, 4}.ToList();
            _vector1Exp = new[] {148, 2, 1, 0, 54}.ToList();
            
            _matrix1 = new[]
            {
                new[] { 1, 5, 8 }.ToList(),
                new[] { -3, 10, 2 }.ToList(),
                new[] { 9, -6, 0 }.ToList(),
            }.ToList();

            _matrix1OddsVector = new[] {1, 5, 9}.ToList();
            _matrix1OddsVectorExpSum = 8253;
        }
        
        [Test]
        public void GetExpVectorTest()
        {
            var exp = _calculator.Exp(_vector1);
            Assert.That(exp, Is.EquivalentTo(_vector1Exp));
        }
        [Test]
        public void MapTest()
        {
            int[] l = new int[]{1,2,3,4};
            Assert.That(_toolBox.Map<int, int>(l, (i) => i*i), Is.EquivalentTo(new int[]{1,4,9,16}));
        }
        [Test]
        public void FilterTest()
        {
            int[] l = new int[]{1,2,3,4};
            Assert.That(_toolBox.Filter<int>(l, (i) => i % 2 == 0), Is.EquivalentTo(new int[]{2, 4}));
        }
        [Test]
        public void FlatMapTest()
        {
            var l = new []{
            new int[]{1,2},
            new int[]{6,3}};
            Assert.That(_toolBox.FlatMap<int, int>(l, (i) => i *2), Is.EquivalentTo(new int[]{2,4,12,6}));
        }
        [Test]
        public void AggregateTest()
        {
            int[] l = new int[]{1,2,3,4};
            Assert.That(_toolBox.Aggregate<int>(l, 3, (i,j) => i *j), Is.EquivalentTo(new int[]{3, 6, 18, 72}));
        }

        [Test]
        public void GetOddNumbersFromMatrixTest()
        {
            var odds = _calculator.GetOdds(_matrix1);
            Assert.That(odds, Is.EquivalentTo(_matrix1OddsVector));
        }

        [Test]
        public void GetSumOfExpOfOddNumbersOfMatrixTest()
        {
            var sum = _calculator.SumOfExpOdds(_matrix1);
            Assert.AreEqual(_matrix1OddsVectorExpSum, sum);
        }
    }
}