namespace C11
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex c = new Complex(real: 5, imaginary: 2);
            Complex c0 = c*"2i+3";
            bool compare = c0 > c;
            bool compare2 = c == "5+2i";
            Complex c1 = new Complex(5,7);
            Complex c2 = c + c1;
            Complex c3 = (int)c + (int) c2;
            Complex c4 = 6;
            int a = (int) c4;
            Complex c5 = "2+3i";
            Complex c6 = (Complex)2+"5+6i";
            Complex c7 = (Complex)"2i+3";
            Complex c8 = "2i";
            string b = c.ToString();
        }
        
    }
}
