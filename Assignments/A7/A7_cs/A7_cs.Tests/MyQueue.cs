using System;
using System.Collections;
using System.Collections.Generic;

namespace A7.Tests
{
    public class MyQueue<T> : IEnumerable, IConvertable<MyStack<T>>
    {
        public int Size { get{return Values.Count;} set{ Size = Values.Count;} }
        public List<T> Values { get; set; }
        public MyQueue()
        => Values = new List<T>();

        public void Enqueue(T obj) => Values.Add(obj);

        public T Dequeue()
        {
            T obj = Values[0];
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
                values.Add(Dequeue());
                if(i != 0)
                    str += " ";
                str += values[i];
            }
            foreach (T val in values)
                Enqueue(val);
            return str;
        }

        public IEnumerator GetEnumerator()
        {
            List<T> values = new List<T>();
            int size = Size;
            for (int i = 0; i < size; i++)
                values.Add(Dequeue());
            foreach (T val in values)
            {
                Enqueue(val);
                yield return val;
            }
        }

        public MyStack<T> Convert()
        {
            List<T> values = new List<T>();
            MyStack<T> s = new MyStack<T>();
            int size = Size;
            for (int i = 0; i < size; i++)
            {
                values.Add(Dequeue());
                s.Push(values[i]);
            }
            foreach (T val in values)
                Enqueue(val);
            return s;
        }
        public static MyQueue<T> operator +(MyQueue<T> lhs, Object rhs)
        {
            if(rhs is MyStack<T> s)
            {
                foreach(T value in s)
                    lhs.Enqueue(value);
            }
            if(rhs is MyQueue<T> q)
            {
                foreach(T value in q)
                    lhs.Enqueue(value);
            }
            return lhs;
        }
    }
}