using System;
using System.Collections.Generic;

namespace LambdaDelegateDemo
{
    public interface IToolBox
    {
        delegate T2 MapperFunc<in T1, out T2>(T1 x);
        public IEnumerable<T2> Map<T1, T2>(IEnumerable<T1> source, MapperFunc<T1, T2> func);
        public IEnumerable<T1> Filter<T1>(IEnumerable<T1> source, Predicate<T1> predicate);
        public IEnumerable<T2> FlatMap<T1, T2>(IEnumerable<IEnumerable<T1>> source, Func<T1, T2> func);
        public IEnumerable<T> Aggregate<T>(IEnumerable<T> source, T seed, Func<T, T, T> func);
    }
}