namespace StatePattern
{
    /// <summary>
    /// ماشین حساب وقتی که جواب یک محاسبه
    /// را نشان میدهد وارد این وضعیت میشود
    /// </summary>
    public class ComputeState : CalculatorState
    {
        public ComputeState(Calculator calc) : base(calc) { }

        public override IState EnterEqual()
        {
            Calc.DisplayError("Syntax Error");
            return new ErrorState(this.Calc);
        }

        public override IState EnterNonZeroDigit(char c)
        {
            Calc.Display = c.ToString();
            return new AccumulateState(Calc);
        }

        public override IState EnterZeroDigit()
        {
            Calc.Display = "0";
            return new StartState(Calc);
        }

        // #5 لطفا
        public override IState EnterOperator(char c) 
            => ProcessOperator(this, c);

        public override IState EnterPoint()
        {
            Calc.Display = "0.";
            return new PointState(this.Calc);
        }

    }
}