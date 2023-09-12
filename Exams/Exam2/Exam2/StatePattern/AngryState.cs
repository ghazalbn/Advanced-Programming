using System;
namespace Exam2
{
    public class AngryState : IState
    {
        IState IState.Eat() => this;

        IState IState.Exam() => new SadState();

        IState IState.Married(Person p) => new StressedState();

        IState IState.Sleep() => new HappyState();
    }
}