using System;

namespace Exam2
{
    public class StressedState : IState
    {
        IState IState.Eat() => this;

        IState IState.Exam() => new SadState();

        IState IState.Married(Person p) => new HappyState();

        IState IState.Sleep() => new HappyState();
    }
}