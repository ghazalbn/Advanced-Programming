using System;

namespace Exam2
{
    public class Person
    {
        public IState State;
        protected double Weight;

        public Person(IState state)
        {
            State = state;
        }
        public void Sleep() => State = State.Sleep();
        public void Eat() => State = State.Eat();

        public void Exam() => State = State.Exam();

        public void Married(Person p) => State = State.Married(p);
    }
}