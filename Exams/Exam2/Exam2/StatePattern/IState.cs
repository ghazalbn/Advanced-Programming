namespace Exam2
{
    public interface IState
    {
        IState Sleep();
        IState Eat();
        IState Exam();
        IState Married(Person p);
    }
}