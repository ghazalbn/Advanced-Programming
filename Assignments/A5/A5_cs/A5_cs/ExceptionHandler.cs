using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5
{
    public class ExceptionHandler
    {
        public string ErrorMsg { get; set; }
        public readonly bool DoNotThrow;
        private string _Input;

        public string Input
        {
            get
            {
                try
                { 
                   foreach (char c in this._Input){} 
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in GetMethod";
                }
                return this._Input;
            }
            set
            {
                try
                {
                    this._Input = value;
                    foreach (var item in this._Input){}
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in SetMethod";
                }
            }
        }

        public ExceptionHandler(
            string input,
            bool causeExceptionInConstructor,
            bool doNotThrow=false)
        {
            DoNotThrow = doNotThrow;
            this._Input = input;
            try
            {
                if (causeExceptionInConstructor)
                {
                    int [] temp = null;
                    temp[0] = 1;
                }
            }
            catch
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = "Caught exception in constructor";
            }
        }
        public static void ThrowIfOdd(int n)
        {
            if(n%2 != 0)
                throw new InvalidDataException();
        }
        public void OverflowExceptionMethod()
        {
            try
            {
                checked
                {
                    int temp = int.Parse(this.Input) + 10;
                }
            }
            catch (OverflowException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void FormatExceptionMethod()
        {
            try
            {
                int temp = int.Parse(this.Input);
            }
            catch (FormatException f)
            {
                if(!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {f.GetType()}";
            }
        }

        public void FileNotFoundExceptionMethod()
        {
            try
            {
               string temp = File.ReadAllText("C:\\git\\AP98992\\Assignments\\A5\\A5_cs\\A5_cs\\"+this.Input+".txt"); 
            }
            catch (FileNotFoundException f)
            {
                if(!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {f.GetType()}";
            }
        }

        public void NestedMethods()
        {
            MethodA();
        }

        private void MethodA()
        {
            MethodB();
        }

        private void MethodB()
        {
            MethodC();
        }

        private void MethodC()
        {
            MethodD();
        }

        private void MethodD()
        {
            throw new NotImplementedException("NestedExceptionTest did not throw exception.");
        }

        public void IndexOutOfRangeExceptionMethod()
        {
            try
            {
                int[] temp = new int[1];
                temp[int.Parse(this.Input)] = 0;
            }
            catch (IndexOutOfRangeException i)
            {
                if(!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {i.GetType()}";
            }
        }
		
		public string FinallyBlockStringOut;

        public void FinallyBlockMethod(string s)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter swr = new StringWriter(sb);
            try
            {
				swr.Write("InTryBlock:");
                if(s == "ugly")
                    return;
                foreach(char c in s) swr.Write(c);
                swr.Write($":{s.Length}:DoneWriting");
            }
            catch (NullReferenceException nre)
            {
                swr.Write($":{nre.Message}");
                if(!DoNotThrow)
                    throw;
            }
            finally
            {
                swr.Write(":InFinallyBlock");
                swr.Dispose();
                FinallyBlockStringOut = sb.ToString();
            }
            FinallyBlockStringOut += ":EndOfMethod";
        }

        public void OutOfMemoryExceptionMethod()
        {
            try
            {
                int[] temp = new int[int.Parse(this.Input)];
            }
            catch (OutOfMemoryException o)
            {
                if(!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {o.GetType()}";
            }
        }

        public void MultiExceptionMethod()
        {
            try
            {
                int[] temp = new int[1];
                int[] temp2 = new int[int.Parse(this.Input)];
                temp[int.Parse(this.Input)] = 0;
            }
            catch (IndexOutOfRangeException e)
            {
                if(!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
            catch (OutOfMemoryException e)
            {
                if(!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }
    }
}
