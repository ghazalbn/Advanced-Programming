using Microsoft.VisualStudio.TestTools.UnitTesting;
using AW6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW6.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AthleteTest()
        {
            Athlete a = Athlete.Height | Athlete.LongHands;
            Assert.AreEqual(Program.WhichSport(a), "Basketball");

            a = Athlete.Height | Athlete.LongHands | Athlete.Pace;
            Assert.AreEqual(Program.WhichSport(a), "Volleyball");

            a = Athlete.LongLegs | Athlete.Pace;
            Assert.AreEqual(Program.WhichSport(a), "Karate");

            a = Athlete.LongLegs | Athlete.Brain;
            Assert.AreEqual(Program.WhichSport(a), "Karate");

            a = Athlete.Pace | Athlete.Brain;
            Assert.AreEqual(Program.WhichSport(a), "Boxing");

            a = Athlete.Brain;
            Assert.AreEqual(Program.WhichSport(a), "Chess");

            a = Athlete.None;
            Assert.AreEqual(Program.WhichSport(a), "Mench!!!");

        }
    }
}