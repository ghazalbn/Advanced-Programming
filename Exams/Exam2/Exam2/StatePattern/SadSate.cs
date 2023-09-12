using System;
namespace Exam2
{
    public class SadState : IState
    {
        IState IState.Eat() => new HappyState();

        IState IState.Exam() => new AngryState();

        IState IState.Married(Person p) => new HappyState();

        IState IState.Sleep() => new HappyState();
    }
}