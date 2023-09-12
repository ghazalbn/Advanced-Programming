namespace C11
{
    public class Complex
    {
        private int real;
        private int imaginary;

        public Complex(int real = 0, int imaginary = 0)
        {
            this.real = real;
            this.imaginary = imaginary;
        }
        public static Complex operator +(Complex lhs, Complex rhs) 
        => new Complex(lhs.real+rhs.real, lhs.imaginary+rhs.imaginary);

        public override string ToString()
        => $"{this.real}+{this.imaginary}i";
        public static implicit operator Complex(string s)
        {
            string[] nums = s.Split('+');
            if(nums.Length > 1)
            {
                if(s.EndsWith('i'))
                    return new Complex(int.Parse(nums[0]), int.Parse(nums[1].Split('i')[0]));
                else
                    return new Complex(int.Parse(nums[1]), int.Parse(nums[0].Split('i')[0]));
            }
            else
            {
                if(s.Contains('i'))
                    return new Complex(imaginary: int.Parse(nums[0].Split('i')[0]));
                else
                    return new Complex(real: int.Parse(nums[0]));
            }
        }
        public static implicit operator Complex(int i) => new Complex(real: i);
        public static explicit operator int(Complex c) => c.real;
        public static Complex operator *(Complex lhs, Complex rhs)
        => new Complex(lhs.real*rhs.real - lhs.imaginary*rhs.imaginary,
                       lhs.real*rhs.imaginary + lhs.imaginary*rhs.real);
        public static bool operator <(Complex lhs, Complex rhs)
        => lhs.real*lhs.real + lhs.imaginary*lhs.imaginary 
         < rhs.real*rhs.real + rhs.imaginary*rhs.imaginary;
        public static bool operator >(Complex lhs, Complex rhs)
            => lhs.real*lhs.real + lhs.imaginary*lhs.imaginary 
            > rhs.real*rhs.real + rhs.imaginary*rhs.imaginary;

        public override bool Equals(object obj)
        => this.real == (obj as Complex).real && 
           this.imaginary == (obj as Complex).imaginary;
        public static bool operator ==(Complex lhs, Complex rhs) => lhs.Equals(rhs);
        public static bool operator !=(Complex lhs, Complex rhs) => !lhs.Equals(rhs);
    }
}