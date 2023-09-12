using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.InteropServices;

namespace A4_cs.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ChooseBest_Tests()
        {
            Config c = Config.Cpu;
            Assert.AreEqual("Not Bad", Program.ChooseBest(c));

            c = Config.Memory;
            Assert.AreEqual("Good", Program.ChooseBest(c));

            c = Config.Graphic;
            Assert.AreEqual("Not Bad", Program.ChooseBest(c));

            c = Config.Memory | Config.Graphic | Config.Cpu;
            Assert.AreEqual("Excellent", Program.ChooseBest(c));

            c = Config.Memory | Config.Graphic;
            Assert.AreEqual("Very Good", Program.ChooseBest(c));

            c = Config.Memory | Config.Cpu;
            Assert.AreEqual("Very Good", Program.ChooseBest(c));
        }

        [TestMethod]
        public void GraphicConstructor_Tests()
        {
            Graphic graphic = new Graphic(null, "NVIDIA GeForce RTX 2060", "GDDR4");
            Assert.AreEqual(graphic.Size, null);
            Assert.AreEqual(graphic.Coprocessor, "NVIDIA GeForce RTX 2060");
            Assert.AreEqual(graphic.Type, "GDDR4");
        }

        [TestMethod]
        public void MemoryConstructor_Tests()
        {
            Memory memory = new Memory(null, 288, null);
            Assert.AreEqual(memory.Capacity, null);
            Assert.AreEqual(memory.Pins, 288);
            Assert.AreEqual(memory.Type, null);
        }

        [TestMethod]
        public void CpuConstructor_Tests()
        {
            Cpu cpu = new Cpu(null, null, "3.2 GHz");
            Assert.AreEqual(cpu.Model, null);
            Assert.AreEqual(cpu.Weight, null);
            Assert.AreEqual(cpu.Speed, "3.2 GHz");
        }

        [TestMethod]
        public void SwapConfigs_Tests()
        {
            Memory m1 = new Memory(32, 288, "DDR4 SDRAM");
            Memory m2 = new Memory(16, 154, "DDR3 SDRAM");
            Program.SwapConfigs(m1, m2);
            Assert.AreEqual(m1.Capacity, 16);
            Assert.AreEqual(m1.Pins, 154);
            Assert.AreEqual(m1.Type, "DDR3 SDRAM");
            Assert.AreEqual(m2.Capacity, 32);
            Assert.AreEqual(m2.Pins, 288);
            Assert.AreEqual(m2.Type, "DDR4 SDRAM");

            Graphic g1 = new Graphic(6, "NVIDIA GeForce RTX 2060", "GDDR6");
            Graphic g2 = new Graphic(8, "NVIDIA GeForce GTX 1660", "GDDR5");
            Program.SwapConfigs(g1, g2);
            Assert.AreEqual(g1.Size, 8);
            Assert.AreEqual(g1.Coprocessor, "NVIDIA GeForce GTX 1660");
            Assert.AreEqual(g1.Type, "GDDR5");
            Assert.AreEqual(g2.Size, 6);
            Assert.AreEqual(g2.Coprocessor, "NVIDIA GeForce RTX 2060");
            Assert.AreEqual(g2.Type, "GDDR6");

            Cpu c1 = new Cpu("Core i7", 0.55, "3 GHz");
            Cpu c2 = new Cpu("Core i9", 0.74, "4.9 GHz");
            Program.SwapConfigs(c1, c2);
            Assert.AreEqual(c1.Model, "Core i9");
            Assert.AreEqual(c1.Weight, 0.74);
            Assert.AreEqual(c1.Speed, "4.9 GHz");
            Assert.AreEqual(c2.Model, "Core i7");
            Assert.AreEqual(c2.Weight, 0.55);
            Assert.AreEqual(c2.Speed, "3 GHz");

        }

        [TestMethod]
        public void StructSize_Tests()
        {
            CheckSize(typeof(Struct_Size5), 5);
            CheckSize(typeof(Struct_Size10), 10);
            CheckSize(typeof(Struct_Size12), 12);
            CheckSize(typeof(Struct_Size105), 105);
        }

        [TestMethod]
        public void HeapSize_Tests()
        {
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
            MemoryHeap memoryHeap = new MemoryHeap();
            long memoryAllocatedInStart = GC.GetTotalMemory(true);            
            memoryHeap.Allocate(4_000_000);
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
            long MemoryAllocatedNow = GC.GetTotalMemory(true);
            AssertApproximated(MemoryAllocatedNow - memoryAllocatedInStart, 4_000_000);
 
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
            memoryHeap.DeAllocate();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
            MemoryAllocatedNow = GC.GetTotalMemory(true); 
            AssertApproximated(MemoryAllocatedNow - memoryAllocatedInStart, 0);
 
        }

        

        #region HelperMethods
        private void AssertApproximated(long v1, int v2)
        {
            long approximating =100_0000;
            Assert.IsTrue(v2 + approximating >= v1);
            Assert.IsTrue(v2 - approximating <= v1);
 
        }
        private void CheckSize(Type type, int v)
        {
            Assert.AreEqual(Marshal.SizeOf(type), v);
        }
        #endregion
    }
}
