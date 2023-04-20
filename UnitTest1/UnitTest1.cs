using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using generator;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Bigramm g1 = new Bigramm();
            g1.Generate(1000);
            g1.ToFile("Bigramma.txt");

            FrequencyWords g2 = new FrequencyWords();
            g2.Generate(1000);
            g2.ToFile("FrequencyWords.txt");

            PairsWords g3 = new PairsWords();
            g3.Generate(1000);
            g3.ToFile("PairsWords.txt");

            Assert.IsTrue(File.Exists("Bigramma.txt"));
            Assert.IsTrue(File.Exists("FrequencyWords.txt"));
            Assert.IsTrue(File.Exists("PairsWords.txt"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Bigramm g1 = new Bigramm();
            string text = g1.Generate(1000).Item1;
            Assert.AreEqual(text.Length, 1000);
        }

        [TestMethod]
        public void TestMethod3()
        {
            FrequencyWords g3 = new FrequencyWords();
            g3.Generate(1000);
            string name = "PairsWords1.txt";
            Assert.IsFalse(File.Exists("PairsWords1.txt"));
        }
        [TestMethod]
        public void TestMethod4()
        {
            FrequencyWords g2 = new FrequencyWords();
            (string, int) res = g2.Generate(1000);
            Assert.AreEqual(res.Item2, 1);
        }
        [TestMethod]
        public void TestMethod5()
        {
            Bigramm g1 = new Bigramm();
            (string, int) res = g1.Generate(1000);
            bool flag = true;
            string text = res.Item1;
            if (text.Contains("àû") || text.Contains("àü"))
            {
                flag = false;
            }
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void TestMethod6()
        {
            PairsWords g3 = new PairsWords();
            Assert.AreEqual(g3.Count(), 5406407);
        }
    }
}
