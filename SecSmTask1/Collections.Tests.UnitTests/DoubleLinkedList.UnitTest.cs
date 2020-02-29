using System;
using System.Collections.Generic;
using Collections.Collections.Generics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Collections.Tests.UnitTests
{
    [TestClass]
    public class DoubleLinkedListUnitTest
    {
        [TestClass]
        public class DoubleLinkedListTest
        {
            //TODO count Assert everywhere!


            [TestMethod]
            public void IndexatorTest()
            {
                DoubleLinkedList<int> list = new DoubleLinkedList<int>();
                var envList = new List<int>();
                for (int i = 0; i < 100; i++)
                {
                    var randItem = (new Random(DateTime.Now.Millisecond)).Next(0, 1000);

                    envList.Add(randItem);
                    list.AddLast(randItem);
                }

                for (int i = 0; i < 100; i++)
                {
                    Assert.AreEqual(list[i], envList[i]);
                }
                for (int i = 0; i < 100; i++)
                {
                    list[i] = envList[i] = (new Random(DateTime.Now.Millisecond)).Next(0, 1000);
                }
                for (int i = 0; i < 100; i++)
                {
                    Assert.AreEqual(list[i], envList[i]);
                }
                Assert.ThrowsException<IndexOutOfRangeException>(() => { list[100] = 100; });
                Assert.ThrowsException<IndexOutOfRangeException>(() => { list[-1] = 100; });
                Assert.ThrowsException<IndexOutOfRangeException>(() => { Console.WriteLine(list[-1]); });
                Assert.ThrowsException<IndexOutOfRangeException>(() => { Console.WriteLine(list[100]); });
                list = new DoubleLinkedList<int>();
                Assert.ThrowsException<InvalidOperationException>(() => { list[2] = 1; });
                Assert.ThrowsException<InvalidOperationException>(() => { Console.WriteLine(list[2]); });
            }

            [TestMethod]
            public void CountTest()
            {
                DoubleLinkedList<int> list = new DoubleLinkedList<int>();
                for (int i = 0; i < 100; i++)
                {
                    list.AddLast((new Random(DateTime.Now.Millisecond)).Next());
                }
                Assert.AreEqual(list.Count, 100);
                list = new DoubleLinkedList<int>();
                Assert.AreEqual(list.Count, 0);
            }

            [TestMethod]
            public void AddFirstTest()
            {
                DoubleLinkedList<int> list = new DoubleLinkedList<int>();
                var envList = new List<int>();
                for (int i = 0; i < 100; i++)
                {
                    var randItem = (new Random(DateTime.Now.Millisecond)).Next(0, 1000);

                    envList.Insert(0, randItem);
                    list.AddFirst(randItem);
                }
                for (int i = 0; i < 100; i++)
                {
                    Assert.AreEqual(list[i], envList[i]);
                }
            }

            [TestMethod]
            public void AddLastTest()
            {
                DoubleLinkedList<int> list = new DoubleLinkedList<int>();
                var envList = new List<int>();
                for (int i = 0; i < 100; i++)
                {
                    var randItem = (new Random(DateTime.Now.Millisecond)).Next(0, 1000);

                    envList.Add(randItem);
                    list.AddLast(randItem);
                }
                for (int i = 0; i < 100; i++)
                {
                    Assert.AreEqual(list[i], envList[i]);
                }
            }

            [TestMethod]
            public void ClearTest()
            {
                DoubleLinkedList<int> list = new DoubleLinkedList<int>();
                for (int i = 0; i < 100; i++)
                {
                    list.AddLast((new Random(DateTime.Now.Millisecond)).Next(0, 1000));
                }
                list.Clear();
                Assert.AreEqual(list.Count, 0);
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
                Assert.IsTrue(list.Contains(4) && list.Contains(1) && list.Contains(55) && list.Contains(13) && list.Contains(4) && list.Contains(45345));
                Assert.IsFalse(list.Contains(5));
                Assert.IsFalse(list.Contains(37));
                list = new DoubleLinkedList<int>();
                Assert.IsFalse(list.Contains(1000));
            }

            [TestMethod]
            public void ElementAtTest()
            {
                DoubleLinkedList<int> list = new DoubleLinkedList<int>();
                var envList = new List<int>();
                for (int i = 0; i < 100; i++)
                {
                    var randItem = (new Random(DateTime.Now.Millisecond)).Next(0, 1000);

                    envList.Add(randItem);
                    list.AddLast(randItem);
                }

                for (int i = 0; i < 100; i++)
                {
                    Assert.AreEqual(list.ElementAt(i), envList[i]);
                }
                for (int i = 0; i < 100; i++)
                {
                    list[i] = envList[i] = (new Random(DateTime.Now.Millisecond)).Next(0, 1000);
                }
                for (int i = 0; i < 100; i++)
                {
                    Assert.AreEqual(list.ElementAt(i), envList[i]);
                }

                Assert.ThrowsException<IndexOutOfRangeException>(() => { Console.WriteLine(list.ElementAt(-1)); });
                Assert.ThrowsException<IndexOutOfRangeException>(() => { Console.WriteLine(list.ElementAt(100)); });
                list = new DoubleLinkedList<int>();
                Assert.ThrowsException<InvalidOperationException>(() => { Console.WriteLine(list.ElementAt(2)); });
            }

            [TestMethod]
            public void EnumeratorTest()
            {
                DoubleLinkedList<int> list = new DoubleLinkedList<int>();
                var envList = new List<int>();
                for (int i = 0; i < 100; i++)
                {
                    var randItem = (new Random(DateTime.Now.Millisecond)).Next(0, 1000);

                    envList.Add(randItem);
                    list.AddLast(randItem);
                }

                for (int i = 0; i < 100; i++)
                {
                    Assert.AreEqual(list.ElementAt(i), envList[i]);
                }

                for (int i = 0; i < 100; i++)
                {
                    envList[i] = list[i] = (new Random(DateTime.Now.Millisecond)).Next(-1000, 1000);
                }

                int index = 0;
                foreach (var item in list)
                {
                    Assert.AreEqual(item, envList[index]);
                    index++;
                }
                list.Clear();
                Assert.ThrowsException<InvalidOperationException>(() => {
                    foreach (var item in list)
                    {

                    }
                });

            }

            [TestMethod]
            public void IndexOfTest()
            {
                DoubleLinkedList<int> list = new DoubleLinkedList<int>();
                for (int i = 0; i < 100; i++)
                {
                    list.AddLast(i * 100);
                }
                for (int i = 0; i < 100; i++)
                {
                    Assert.AreEqual(list.IndexOf(i * 100), i);
                }
                list = new DoubleLinkedList<int>();
                Assert.ThrowsException<InvalidOperationException>(() => {
                    list.IndexOf(100);
                });
            }

            [TestMethod]
            public void InsertAtTest()
            {
                DoubleLinkedList<int> list = new DoubleLinkedList<int>();
                for (int i = 0; i < 100; i++)
                {
                    list.InsertAt(list.Count, i);
                }
                for (int i = 0; i < 100; i++)
                {
                    Assert.AreEqual(i, list[i]);
                }
                list.InsertAt(0, 1337);
                list.InsertAt(55, 123);
                Assert.AreEqual(1337, list[0]);
                Assert.AreEqual(123, list[55]);


                Assert.ThrowsException<IndexOutOfRangeException>(() => { list.InsertAt(103, 1); });
                Assert.ThrowsException<IndexOutOfRangeException>(() => { list.InsertAt(-1, 1); });
                list = new DoubleLinkedList<int>();
                Assert.ThrowsException<IndexOutOfRangeException>(() => { list.InsertAt(2, 1); });
            }

            [TestMethod]
            public void RemoveLastTest()
            {
                DoubleLinkedList<int> list = new DoubleLinkedList<int>();
                for (int i = 0; i < 100; i++)
                {
                    list.AddLast(i * 1000);
                }
                list.RemoveLast();
                list.RemoveLast();
                for (int i = 0; i < 98; i++)
                {
                    Assert.AreEqual(i * 1000, list[i]);
                }
                Assert.AreEqual(list.Count, 98);



                list = new DoubleLinkedList<int>();
                Assert.ThrowsException<InvalidOperationException>(() => { list.RemoveLast(); });
            }

            [TestMethod]
            public void RemoveFirstTest()
            {
                DoubleLinkedList<int> list = new DoubleLinkedList<int>();
                for (int i = 0; i < 100; i++)
                {
                    list.AddLast(i * 1000);
                }
                list.RemoveFirst();
                list.RemoveFirst();
                for (int i = 2; i < 100; i++)
                {
                    Assert.AreEqual(i * 1000, list[i - 2]);
                }

                list = new DoubleLinkedList<int>();
                Assert.ThrowsException<InvalidOperationException>(() => { list.RemoveFirst(); });
            }

            [TestMethod]
            public void RemoveTest()
            {
                DoubleLinkedList<int> list = new DoubleLinkedList<int>();
                for (int i = 0; i < 100; i++)
                {
                    list.AddLast(i * 1000);
                }
                list.Remove(0);
                list.Remove(1000);
                list.Remove(99000);
                list.Remove(98000);
                for (int i = 2; i < 98; i++)
                {
                    Assert.AreEqual(i * 1000, list[i - 2]);
                }

                Assert.AreEqual(list.Remove(1000), 0);

                list = new DoubleLinkedList<int>();
                Assert.ThrowsException<InvalidOperationException>(() => { list.Remove(100); });
            }

            [TestMethod]
            public void RemoveAtTest()
            {
                DoubleLinkedList<int> list = new DoubleLinkedList<int>();
                for (int i = 0; i < 100; i++)
                {
                    list.AddLast(i * 1000);
                }
                list.RemoveAt(0);
                list.RemoveAt(0);
                list.RemoveAt(0);
                list.RemoveAt(0);
                list.RemoveAt(list.Count - 1);
                list.RemoveAt(list.Count - 1);
                for (int i = 4; i < 96; i++)
                {

                    Assert.AreEqual(i * 1000, list[i - 4]);
                }

                list = new DoubleLinkedList<int>();
                Assert.ThrowsException<InvalidOperationException>(() => { list.RemoveAt(100); });
            }

            [TestMethod]
            public void SetElementAtrTest()
            {
                DoubleLinkedList<int> list = new DoubleLinkedList<int>();
                var envList = new List<int>();
                for (int i = 0; i < 100; i++)
                {
                    var randItem = (new Random(DateTime.Now.Millisecond)).Next(0, 1000);

                    envList.Add(randItem);
                    list.AddLast(randItem);
                }


                for (int i = 0; i < 100; i++)
                {
                    var temp = (new Random(DateTime.Now.Millisecond)).Next(0, 1000);

                    list.SetElementAt(temp, i);
                    envList[i] = temp;

                }
                for (int i = 0; i < 100; i++)
                {
                    Assert.AreEqual(list[i], envList[i]);
                }
                Assert.ThrowsException<IndexOutOfRangeException>(() => { list.SetElementAt(100, 100); });
                Assert.ThrowsException<IndexOutOfRangeException>(() => { list.SetElementAt(100, -1); });

                list = new DoubleLinkedList<int>();
                Assert.ThrowsException<InvalidOperationException>(() => { list.SetElementAt(1, 2); });
            }

            [TestMethod]
            public void CopyConstructorTest()
            {
                var list = new DoubleLinkedList<int>();

                for (int i = 0; i < 100; i++)
                {
                    list.AddLast(i);
                }

                var newList = new DoubleLinkedList<int>(list);

                for (int i = 0; i < 100; i++)
                {
                    Assert.AreEqual(newList[i], list[i]);
                }

            }




        }
    }
}
