using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaDelegateDemo
{
    public class MyToolBox : IToolBox
    {
        public IEnumerable<T2> Map<T1, T2>(IEnumerable<T1> source, IToolBox.MapperFunc<T1, T2> func)
        {
            foreach (T1 s in source)
                yield return func(s);
        }

        public IEnumerable<T1> Filter<T1>(IEnumerable<T1> source, Predicate<T1> predicate)
        {
            foreach (T1 s in source)
            {
                if(predicate(s))
                    yield return s;
            }
        }

        public IEnumerable<T2> FlatMap<T1, T2>(IEnumerable<IEnumerable<T1>> source, Func<T1, T2> func)
        {
            foreach (var e in source)
            {
                foreach(T1 s in e)
                    yield return func(s);
            }
        }

        public IEnumerable<T> Aggregate<T>(IEnumerable<T> source, T seed, Func<T, T, T> func)
        {
            List<T> l = new List<T>();
            for(int i = 0; i < source.Count(); i++)
            {
                if(i == 0)
                    l.Add( func(seed, source.ElementAt(i)));
                else
                    l.Add(func(l.ElementAt(i-1), source.ElementAt(i)));
            }
            foreach(T val in l)
                yield return val;

        }
    }
}