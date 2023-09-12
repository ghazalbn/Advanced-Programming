using System;

namespace StatePattern
{
    /// <summary>
    /// این کلاس بطور کامل پیاده سازی شده است و نیاز به تغییر ندارد.
    /// تنها تغییرات لازم کامنت های شماست 
    /// </summary>
    public class StartState : CalculatorState
    {
        public StartState(Calculator calc) : base(calc) { }

        // با وارد کردن هر اپراتور از 
        // ProcessOperator
        // استفاده میکنیم که مدیریت اعمال جمع و ضرب و حاصل ... را انجام میدهد 
        // و پس از ان نیز وارد  
        // ComputeState
        // میشود
        public override IState EnterEqual() => 
            ProcessOperator(new ComputeState(this.Calc));

        // در ماشین حساب در ابتدا وقتی هنوز عدد غیر صفری وارد نشده و 0 را وارد میکنیم تغییری نمیکند
        // و در همان وضعیت هم باقی میماند
        public override IState EnterZeroDigit()
        {
            this.Calc.Display = "0";
            return this;
        }

        // با وارد کردن عدد غیر صفر باید به جای 0 اولیه، این عدد نمایش داده شود و وارد 
        // AccumulateState
        // شویم
        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Display = c.ToString();
            return new AccumulateState(this.Calc);
        }

        public override IState EnterOperator(char c) => 
            ProcessOperator(new ComputeState(this.Calc), c);

        // وارد کردن نقطه در وضعیت 
        // start 
        // یعنی کاربر میخواهد عدد اعشاری (کوچک تر از 1 )وارد کند پس باید 0. نمایش داده شود و پس از ان وارد
        // PointState
        // شود
        public override IState EnterPoint()
        {
            this.Calc.Display = "0.";
            return new PointState(this.Calc);
        }
    }
}