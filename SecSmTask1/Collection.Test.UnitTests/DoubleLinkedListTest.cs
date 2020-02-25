using System;
using Collections.Collections.Generics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Collection.Test.UnitTests
{
    [TestClass]
    public class DoubleLinkedListTest
    {
        [TestMethod]
        public void AddFirstTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);
            list.AddFirst(4);
            list.AddFirst(5);
        }
        [TestMethod]
        public void AddLastTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.AddLast(1);
            list.AddLast(55);
            list.AddFirst(13);
            list.AddLast(4);
            list.AddFirst(45345);
        }

        [TestMethod]
        public void ContainsTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.AddLast(1);
            list.AddLast(55);
            list.AddFirst(13);
            list.AddLast(4);
            list.AddFirst(45345);
            Assert.IsTrue(list.Contains(4) && list.Contains(1) && list.Contains(55) && list.Contains(13) && list.Contains(4) && list.Contains(45345) && !list.Contains(5) && !list.Contains(37));
        }

        [TestMethod]
        public void GetEnumeratorTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.AddLast(1);
            list.AddLast(55);
            list.AddFirst(13);
            list.AddLast(4);
            list.AddFirst(45345);
            Assert.IsTrue(list.Contains(4) && list.Contains(1) && list.Contains(55) && list.Contains(13) && list.Contains(4) && list.Contains(45345) && !list.Contains(5) && !list.Contains(37));
        }


    }
}
