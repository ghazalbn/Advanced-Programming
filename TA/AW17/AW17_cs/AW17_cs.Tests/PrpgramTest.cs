using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AW17_cs.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BagageHandler provider = new BagageHandler();
            Monitor observer1 = new Monitor("BaggageClaimMonitor1");
            Monitor observer2 = new Monitor("SecurityExit");
 
            provider.BagageStatus(712, "Detroit", 3);
            observer1.Subscribe(provider);
            provider.BagageStatus(712, "Kalamazoo", 3);
            provider.BagageStatus(400, "New York-Kennedy", 1);
            provider.BagageStatus(712, "Detroit", 3);
            observer2.Subscribe(provider);
            provider.BagageStatus(511, "San Francisco", 2);
            provider.BagageStatus(712);
            observer2.UnSubscribe();
            provider.BagageStatus(400);
            provider.LastBagageClaimed();
        }
    }
}
