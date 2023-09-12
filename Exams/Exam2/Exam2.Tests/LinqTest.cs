using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Exam2.Tests
{
    [TestClass]
    public class LinqTest
    {
        GameAnalysis mv = new GameAnalysis(@"..\..\..\Video_Games_Sales.csv");

        [TestMethod]
        public void CountTest()
        {
            VerifyResult(mv.AllDataCount(), "0422E8355E7A19BCD12E88813692F0E0");
        }
        [TestMethod]
        public void FrequentTest()
        {
            var t = mv.MostFrequent();

            VerifyResult(t[0].Item1, "004BF6C9A40003140292E97330236C53");
            VerifyResult(t[1].Item1, "918E180E06B96C76B7193C9FCB1CB312");
            VerifyResult(t[2].Item1, "74248C725E00BF9FE04DF4E35B249A19");
            VerifyResult(t[3].Item1, "BD1587F74483EA149F8C38B8A82028A5");
            VerifyResult(t[4].Item1, "07312FB380DC0E653B77DDC9DFA05013");

            VerifyResult(t[0].Item2, "1A04F965818A8533F5613003C7DB243D");
            VerifyResult(t[1].Item2, "2321994D85D661D792223F647000C65F");
            VerifyResult(t[2].Item2, "7137DEBD45AE4D0AB9AA953017286B20");
            VerifyResult(t[3].Item2, "E655C7716A4B3EA67F48C6322FC42ED6");
            VerifyResult(t[4].Item2, "4476B929E30DD0C4E8BDBCC82C6BA23A");
        }
        [TestMethod]
        public void PublisherTest()
        {
            var t = mv.BestPublisher();

            VerifyResult(t[0], "E064214C4C26E67587644971D78A21F8");
            VerifyResult(t[1], "E07CEFAE866008F46547409B6D3655DE");
            VerifyResult(t[2], "4E30D3476E9D06F7F8672E8151047CF1");
            VerifyResult(t[3], "EF66931E7C83FE3BDE78A7818A2A2EA3");
            VerifyResult(t[4], "CF3567CEB9CC35AAA3A550227C77A026");
        }
        [TestMethod]
        public void GamerTest()
        {
            var t = mv.WestGamers(4, 7);

            VerifyResult(t[0], "8098259BE2D45BBE45E6B03014F427DB");
            VerifyResult(t[1], "5311090AB608BFFF6A9E6426D9646B40");
            VerifyResult(t[2], "C34082D2700182FD2467552F47995D29");
            VerifyResult(t[3], "DF097B8401E00BA5CFFAD9E79A4480C8");
        }
        [TestMethod]
        public void FaultyTest()
        {
            var t = mv.FaultyDatas();
            VerifyResult(t, "758B5769A8BC2B25413632595FEF5D3C");
        }


        #region Helper Methods
        private void VerifyResult<T>(T v1, string v2)
        {
            string res = CalcMD5(v1.ToString());
            Assert.AreEqual(res, v2);
        }
        private string CalcMD5(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        #endregion
    }
}
