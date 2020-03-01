using Collections.Collections.Generics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.Tests.UnitTests
{
    static class StringHelper
    {
        public static string ReverseString(this string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }


    [TestClass]
    public class PriorityQueueTest
    {
        [TestMethod]
        public void AddTest()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>((value1, value2) => string.Compare(value1, value2));

            foreach (var value in "fgxyumnqrstvabwhijkopcdelz")
            {
                queue.Add(value.ToString());
            }
            Assert.AreEqual("fgxyumnqrstvabwhijkopcdelz".Length, queue.Count);
            foreach (var value in "abcdefghijklmnopqrstuvwxyz".ReverseString())
            {
                Assert.AreEqual(value.ToString(), queue.Remove());
            }

        }

        [TestMethod]
        public void RemoveTest()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>((value1, value2) => string.Compare(value1, value2));

            foreach (var value in "fgxyumnqrstvabwhijkopcdelz")
            {
                queue.Add(value.ToString());
            }
            foreach (var value in "abcdefghijklmnopqrstuvwxyz".ReverseString())
            {
                Assert.AreEqual(value.ToString(), queue.Remove());
            }
            Assert.AreEqual(0, queue.Count);
            Assert.ThrowsException<InvalidOperationException>(() => queue.Remove());
        }

        [TestMethod]
        public void CountTest()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>((value1, value2) => string.Compare(value1, value2));

            for (int i = 0; i < 100; i++)
            {
                queue.Add(i.ToString());
            }
            Assert.AreEqual(100, queue.Count);
            for (int i = 0; i < 100; i++)
            {
                queue.Remove();
            }
            Assert.AreEqual(0, queue.Count);
        }
        [TestMethod]
        public void TopTest()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>((value1, value2) => string.Compare(value1, value2));


            queue.Add("ABC");
            Assert.AreEqual("ABC", queue.TopItem);

            queue.Add("ADA");
            Assert.AreEqual("ADA", queue.TopItem);
            queue.Add("AAA");
            Assert.AreEqual("ADA", queue.TopItem);
        }
    }
}
