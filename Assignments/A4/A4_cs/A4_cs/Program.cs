using System;
using System.Collections.Generic;

namespace A4_cs
{
    public enum Config
    {
        Graphic = 1,
        Memory = 2,
        Cpu = 4
    }
    public class MemoryHeap
    {
        // public List<char> alloc;
        public char[] alloc;
        public void Allocate(int bytes)
        {
            // this.alloc = new List<char>(bytes/2);
            alloc = new char[bytes/2];
        }
        public void DeAllocate()
        {
            this.alloc = null;
        }
    }

    public class Memory
    {
        public int? Capacity;
        public int? Pins;
        public string Type;
        public Memory(int? capacity, int? pins, string type)
        {
            this.Capacity = capacity;
            this.Pins = pins;
            this.Type = type;
        }
    }
    public class Graphic
    {
        public int? Size;
        public string Coprocessor;
        public string Type;
        public Graphic(int? size, string coprocessor, string type)
        {
            this.Size = size;
            this.Coprocessor = coprocessor;
            this.Type = type;
        }
    }
    public class Cpu
    {
        public string Model;
        public double? Weight;
        public string Speed;
        public Cpu(string model, double? weight, string speed)
        {
            this.Model = model;
            this.Speed = speed;
            this.Weight = weight;
        }    
    }
    public struct Struct_Size5
    {
        public char Q;
        public char a;
        public char z;
        public char aa;
        public char l;
    }
    public struct Struct_Size10
    {
        Struct_Size5 a;
        Struct_Size5 b;
    }
    public struct Struct_Size12
    {
        int H;
        int e;
        int y;
    }
    public struct Struct_Size105
    {
        Struct_Size10 a;
        Struct_Size10 b;
        Struct_Size10 c;
        Struct_Size10 d;
        Struct_Size10 e;
        Struct_Size10 f;
        Struct_Size10 g;
        Struct_Size10 h;
        Struct_Size10 i;
        Struct_Size10 l;
        Struct_Size5 m;
    }
    public class Program
    {
        static void Main(string[] args) { }
        
        public static string ChooseBest(Config c)
        {
            if((c & Config.Cpu) == Config.Cpu && (c & Config.Memory) == Config.Memory && (c & Config.Graphic) == Config.Graphic)
                return "Excellent";
            if((c & Config.Memory) == Config.Memory && ((c & Config.Graphic) == Config.Graphic || (c & Config.Cpu) == Config.Cpu))
                return "Very Good";
            if((c & Config.Memory) == Config.Memory)
                return "Good";
            if((c & Config.Cpu) == Config.Cpu || (c & Config.Graphic) == Config.Graphic)
                return "Not Bad";
            return null;
        }
        public static void SwapConfigs(object o1, object o2)
        {
            if(o1 is Memory)
            {
                Swap(ref (o1 as Memory).Capacity, ref (o2 as Memory).Capacity);
                Swap(ref (o1 as Memory).Type, ref (o2 as Memory).Type);
                Swap(ref (o1 as Memory).Pins, ref (o2 as Memory).Pins);
            }
            if(o1 is Graphic)
            {
                Swap(ref (o1 as Graphic).Coprocessor, ref (o2 as Graphic).Coprocessor);
                Swap(ref (o1 as Graphic).Type, ref (o2 as Graphic).Type);
                Swap(ref (o1 as Graphic).Size, ref (o2 as Graphic).Size);
            }
            if(o1 is Cpu)
            {
                Swap(ref (o1 as Cpu).Weight, ref (o2 as Cpu).Weight);
                Swap(ref (o1 as Cpu).Model, ref (o2 as Cpu).Model);
                Swap(ref (o1 as Cpu).Speed, ref (o2 as Cpu).Speed);
            }
        }

        private static void Swap<_Type>(ref _Type a, ref _Type b)
        {
            _Type tmp = a;
            a = b;
            b = tmp;
        }
    }
}
