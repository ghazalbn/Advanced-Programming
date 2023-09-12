namespace StatePattern
{
    /// <summary>
    /// ماشین حساب وقتی به این حالت وارد میشود که خطایی رخ داده باشد
    /// از این حالت هر کلیدی که فشار داده شود به وضعیت اولیه باید برگردیم
    
    /// وقتی خطایی رخ داد وارد این وضعیت شده و با فشردن هر کلید باید#
    // display
    // پاک شده و به حالت اولیه ماشین حساب که 
    // startstate 
    // است و 0 نمایش داده میشود برگردیم.
    /// </summary>
    public class ErrorState : CalculatorState
    {
        public ErrorState(Calculator calc) : base(calc) { }
        public override IState EnterEqual() => StartAgain();
        public override IState EnterNonZeroDigit(char c) => StartAgain();
        public override IState EnterZeroDigit() => StartAgain();
        public override IState EnterOperator(char c) => StartAgain();
        public override IState EnterPoint() => StartAgain();
        private IState StartAgain()
        {
            Calc.Clear();
            return Calc.State;
        }
    }
}