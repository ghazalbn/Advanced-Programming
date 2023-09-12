using System;
namespace StatePattern
{
    /// <summary>
    ///  این کلاس وضعیت مادر است 
    ///  برای هر وضعیتی اگر یکی از 
    ///  Event ها
    ///  مثلا
    ///  EnterEqual/...
    ///  را 
    ///  override
    ///  نکنیم به طور پیش فرض کاری انجام نمیدهد و در وضعیت فعلی باقی میماند.

    ///  این کلاس 
    // interface IState
    // را پیاده سازی میکند زیرا در هر
    // state
    // باید متد های 
    // IState
    //  به طور متفاوتی پیاده سازی شوند و با انجام هر یک از این اعمال
    // در ماشین حساب بسته به اینکه در کدام وضعیت هستیم باید یک رفتار متفاوت نشان داده شود
    // و سپس وارد وضغیت بعدی شود
    //  در صورت داشتن اپراتور از متد
    // ProcessOperator
    // استفاده میکنیم که نماد اپراتور را در
    // PendingOperator 
    // ماشین حساب و اپرند هارا در
    // Accumulation
    //  ماشین حسابمان ذخیره کرده
    //  و هر وقت = میزنیم نیز این متد را صدا میزنیم تا جواب ان عمل را با استفاده از 
    // evaluate
    //  حساب کند
    /// </summary>
    public abstract class CalculatorState : IState
    {
        public Calculator Calc { get;  }
        public CalculatorState(Calculator calc) => this.Calc = calc;
        public virtual IState EnterEqual() => null;
        public virtual IState EnterZeroDigit() => null;
        public virtual IState EnterNonZeroDigit(char c) => null;        
        public virtual IState EnterOperator(char c) => null;
        public virtual IState EnterPoint() => null;

        protected IState ProcessOperator(IState nextState, char? op = null)
        {
            try
            {
                this.Calc.Evalute();
                this.Calc.UpdateDisplay();
                this.Calc.PendingOperator = op;
                return nextState;
            }
            catch (Exception e)
            {
                this.Calc.DisplayError(e.Message);
                return new ErrorState(this.Calc);
            }
        }
    }
}