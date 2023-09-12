using System;

namespace c9cs
{
    struct TestStruct
    {
        public int x;
        public int y;
        public int z;
        // public TestStruct(int x, int y, int z)
        // {

        // }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TestStruct[] values = GetInput();
            Sort(values, true);
            OutPut(values);
            System.Console.ReadLine();
        }

        private static void OutPut(TestStruct[] values)
        {
            foreach (TestStruct t in values)
            {
                System.Console.WriteLine($"({t.x},{t.y},{t.z})");
            }
        }

        private static void Sort(TestStruct[] values, bool? sortOrder = null)
        {
            if(sortOrder.HasValue)
            {
                if(sortOrder.Value)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        for (int j = i+1; j < values.Length; j++)
                        {
                            if(values[j].x < values[i].x)
                            {
                                TestStruct tmp = values[i];
                                values[i] = values[j];
                                values[j] = tmp;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        for (int j = i+1; j < values.Length; j++)
                        {
                            if(values[j].y < values[i].y)
                            {
                                TestStruct tmp = values[i];
                                values[i] = values[j];
                                values[j] = tmp;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < values.Length; i++)
                {
                    for (int j = i+1; j < values.Length; j++)
                    {
                        if(values[j].z < values[i].z)
                        {
                            TestStruct tmp = values[i];
                            values[i] = values[j];
                            values[j] = tmp;
                        }
                    }
                }
            }
        }

        private static TestStruct[] GetInput()
        {
            System.Console.Write("Structs count? ");
            int count = int.Parse(Console.ReadLine());
            TestStruct[] list = new TestStruct[count];
            for (int i = 0; i < count; i++)
            {
                System.Console.WriteLine($"Struct {i+1}:");
                list[i] = GetXYZ();
            }
            return list;
        }

        private static TestStruct GetXYZ()
        {
            TestStruct t = new TestStruct();
            System.Console.Write("x? ");
            t.x = int .Parse(Console.ReadLine());
            System.Console.Write("y? ");
            t.y = int .Parse(Console.ReadLine());
            System.Console.Write("z? ");
            t.z = int .Parse(Console.ReadLine());
            return t;
        }
    }
}
