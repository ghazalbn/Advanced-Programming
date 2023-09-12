using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exam2.Tests
{
    [TestClass]
    public class StatePattern
    {
        [TestMethod]
        public void AngryTest()
        {
            IState state = new AngryState();
            Person he = new Person(state);
            Assert.IsTrue(he.State is AngryState);

            he = new Person(state);
            he.Eat();
            Assert.IsTrue(he.State is AngryState);

            he = new Person(state);
            he.Sleep();
            Assert.IsTrue(he.State is HappyState);

            he = new Person(state);
            Person she = new Person(state);
            he.Married(she);
            Assert.IsTrue(he.State is StressedState);

            he = new Person(state);
            he.Exam();
            Assert.IsTrue(he.State is SadState);
        }
        [TestMethod]
        public void HappyTest()
        {
            IState state = new HappyState();
            Person he = new Person(state);
            Assert.IsTrue(he.State is HappyState);

            he = new Person(state);
            he.Eat();
            Assert.IsTrue(he.State is HappyState);

            he = new Person(state);
            he.Sleep();
            Assert.IsTrue(he.State is HappyState);

            he = new Person(state);
            Person she = new Person(state);
            he.Married(she);
            Assert.IsTrue(he.State is HappyState);

            he = new Person(state);
            he.Exam();
            Assert.IsTrue(he.State is StressedState);
        }
        [TestMethod]
        public void SadTest()
        {
            IState state = new SadState();
            Person he = new Person(state);
            Assert.IsTrue(he.State is SadState);

            he = new Person(state);
            he.Eat();
            Assert.IsTrue(he.State is HappyState);

            he = new Person(state);
            he.Sleep();
            Assert.IsTrue(he.State is HappyState);

            he = new Person(state);
            Person she = new Person(state);
            he.Married(she);
            Assert.IsTrue(he.State is HappyState);

            he = new Person(state);
            he.Exam();
            Assert.IsTrue(he.State is AngryState);
        }
        [TestMethod]
        public void StressTest()
        {
            IState state = new StressedState();
            Person he = new Person(state);
            Assert.IsTrue(he.State is StressedState);

            he = new Person(state);
            he.Eat();
            Assert.IsTrue(he.State is StressedState);

            he = new Person(state);
            he.Sleep();
            Assert.IsTrue(he.State is HappyState);

            he = new Person(state);
            Person she = new Person(state);
            he.Married(she);
            Assert.IsTrue(he.State is HappyState);

            he = new Person(state);
            he.Exam();
            Assert.IsTrue(he.State is SadState);
        }

        [TestMethod]
        public void MixedTest()
        {
            IState state = new AngryState();
            Person he = new Person(state);
            Assert.IsTrue(he.State is AngryState);

            he.Sleep();
            Assert.IsTrue(he.State is HappyState);

            he.Exam();
            Assert.IsTrue(he.State is StressedState);

            he.Exam();
            Assert.IsTrue(he.State is SadState);

            he.Exam();
            Assert.IsTrue(he.State is AngryState);
        }
    }
}
