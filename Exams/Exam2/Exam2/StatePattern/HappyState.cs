using System;

namespace Exam2
{
    public class HappyState : IState
    {
        IState IState.Eat() => this;

        IState IState.Exam() => new StressedState();
        IState IState.Married(Person p) => this;
        IState IState.Sleep() => this;
    }
}