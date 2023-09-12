using System;
using System.Collections;
using System.Collections.Generic;

namespace A7.Tests
{
    public class MyStack<T> : IEnumerable, IConvertable<MyQueue<T>>
    {
        public int Size { get{return Values.Count;} set{ Size = Values.Count;} }
        public List<T> Values { get; set; }
        public MyStack()
        => Values = new List<T>();
        public void Push(T obj) => Values.Add(obj);

        public MyQueue<T> Convert()
        {
            List<T> values = new List<T>();
            MyQueue<T> q = new MyQueue<T>();
            int size = Size;
            for (int i = 0; i < size; i++)
            {
                values.Add(Pop());
                q.Enqueue(values[i]);
            }
            values.Reverse();
            foreach (T val in values)
                Push(val);
            return q;
        }

        public T Pop() 
        {
            T obj = Values[Values.Count - 1];
            Values.Remove(obj);
            return obj;
        }
        public string Print()
        {
            string  str = "";
            List<T> values = new List<T>();
            int size = Size;
            for (int i = 0; i < size; i++)
            {
                values.Add(Pop());
                if(i != 0)
                    str += " ";
                str += values[i];
            }
            values.Reverse();
            foreach (T val in values)
                Push(val);
            return str;
        }
        public static MyStack<T> operator +(MyStack<T> lhs, Object rhs)
        {
            if(rhs is MyStack<T> s)
            {
                foreach(T value in s)
                    lhs.Push(value);
            }
            if(rhs is MyQueue<T> q)
            {
                foreach(T value in q)
                    lhs.Push(value);
            }
            return lhs;
        }
        public IEnumerator GetEnumerator()
        {
            List<T> values = new List<T>();
            int size = Size;
            for (int i = 0; i < size; i++)
                values.Add(Pop());
            foreach (T val in values)
            {
                Push(val);
                yield return val;
            }
        }
    }
}