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
                for (int i = 0; i < 100; i++)
                {
                    list.AddLast(i);
                }

                for (int i = 0; i < 100; i++)
                {
                    Assert.AreEqual(list[i], i);
                }
                for (int i = 0; i < 100; i++)
                {
                    list[i] = 1001 * i;
                }
                for (int i = 0; i < 100; i++)
                {
                    Assert.AreEqual(list[i], 1001*i);
                }
                Assert.ThrowsException<IndexOutOfRangeException>(() => { list[100] = 100; });
                Assert.ThrowsException<IndexOutOfRangeException>(() => { list[-1] = 100; });
                Assert.ThrowsException<IndexOutOfRangeException>(() => { Console.WriteLine(list[-1]); });
                Assert.ThrowsException<IndexOutOfRangeException>(() => { Console.WriteLine(list[100]); });
                list = new DoubleLinkedList<int>();
                Assert.ThrowsException<InvalidOperationException>(() => { list[2] = 1; });
                Assert.ThrowsException<InvalidOperationException>(() => { Console.WriteLine(list[2]); });

                DoubleLinkedList<string> strList = new DoubleLinkedList<string>();

                foreach (char item in "zxcvbnm,./asdfghjkl;'qwertyuiop[]1234567890-=")
                {
                    strList.AddLast(item.ToString());
                }

                for(int i = 0; i < "zxcvbnm,./asdfghjkl;'qwertyuiop[]1234567890-=".Length; i++)
                {
                    Assert.AreEqual(strList[i], "zxcvbnm,./asdfghjkl;'qwertyuiop[]1234567890-="[i].ToString());
                }


            }

            [TestMethod]
            public void CountTest()
            {
                DoubleLinkedList<int> list = new DoubleLinkedList<int>();
                for (int i = 0; i < 100; i++)
                {
                    list.AddLast(i);
                }
                Assert.AreEqual(list.Count, 100);
                list = new DoubleLinkedList<int>();
                Assert.AreEqual(list.Count, 0);
            }

            [TestMethod]
            public void AddFirstTest()
            {
                DoubleLinkedList<int> list = new DoubleLinkedList<int>();
                for (int i = 0; i < 100; i++)
                {
                    list.AddFirst(i);
                }
                for (int i = 100; i < 0; i--)
                {
                    Assert.AreEqual(list[100 - i], i);
                }

                DoubleLinkedList<string> listStr = new DoubleLinkedList<string>();
                foreach (var item in "asdfghjkl;'qwertyuiop[]zxcvbnm,./")
                {

                    listStr.AddFirst(item.ToString());
                }
                for (int i = 0; i < "asdfghjkl;'qwertyuiop[]zxcvbnm,./".Length; i++)
                {
                    Assert.AreEqual(listStr[i], "asdfghjkl;'qwertyuiop[]zxcvbnm,./".ReverseString()[i].ToString());
                }



            }

            [TestMethod]
            public void AddLastTest()
            {
                DoubleLinkedList<int> list = new DoubleLinkedList<int>();
                for (int i = 0; i < 100; i++)
                {
                    var randItem = i;

                    list.AddLast(randItem);
                }
                for (int i = 0; i < 100; i++)
                {
                    Assert.AreEqual(list[i], i);
                }

                DoubleLinkedList<string> listStr = new DoubleLinkedList<string>();
                foreach (var item in "asdfghjkl;'qwertyuiop[]zxcvbnm,./")
                {

                    listStr.AddLast(item.ToString());
                }
                for (int i = 0; i < "asdfghjkl;'qwertyuiop[]zxcvbnm,./".Length; i++)
                {
                    Assert.AreEqual(listStr[i], "asdfghjkl;'qwertyuiop[]zxcvbnm,./"[i].ToString());
                }

            }

            [TestMethod]
            public void ClearTest()
            {
                DoubleLinkedList<int> list = new DoubleLinkedList<int>();
                for (int i = 0; i < 100; i++)
                {
                    list.AddLast(i);
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

                DoubleLinkedList<string> listStr = new DoubleLinkedList<string>();
                foreach (var item in "asdfghjkl;'qwertyuiop[]zxcvbnm,./")
                {

                    listStr.AddLast(item.ToString());
                }
                foreach (var item in "asdfghjkl;'qwertyuiop[]zxcvbnm,./")
                {

                    Assert.IsTrue(listStr.Contains(item.ToString()));
                }
                
            }

            [TestMethod]
            public void ElementAtTest()
            {
                DoubleLinkedList<int> list = new DoubleLinkedList<int>();
                for (int i = 0; i < 100; i++)
                {
                    list.AddLast(i);
                }

                for (int i = 0; i < 100; i++)
                {
                    Assert.AreEqual(list.ElementAt(i), i);
                }
                for (int i = 0; i < 100; i++)
                {
                    list[i]  = 1001 * i;
                }
                for (int i = 0; i < 100; i++)
                {
                    Assert.AreEqual(list.ElementAt(i), 1001*i);
                }

                Assert.ThrowsException<IndexOutOfRangeException>(() => { Console.WriteLine(list.ElementAt(-1)); });
                Assert.ThrowsException<IndexOutOfRangeException>(() => { Console.WriteLine(list.ElementAt(100)); });
                list = new DoubleLinkedList<int>();
                Assert.ThrowsException<InvalidOperationException>(() => { Console.WriteLine(list.ElementAt(2)); });


                DoubleLinkedList<string> listStr = new DoubleLinkedList<string>();
                foreach (var item in "asdfghjkl;'qwertyuiop[]zxcvbnm,./")
                {
                    listStr.AddLast(item.ToString());
                }
                Assert.AreEqual(listStr.ElementAt(12), "w".ToString());

            }

            [TestMethod]
            public void EnumeratorTest()
            {
                DoubleLinkedList<int> list = new DoubleLinkedList<int>();
                for (int i = 0; i < 100; i++)
                {
                    list.AddLast(i);
                }

                for (int i = 0; i < 100; i++)
                {
                    Assert.AreEqual(list.ElementAt(i), i);
                }

                for (int i = 0; i < 100; i++)
                {
                    list[i] = i;
                }

                int index = 0;
                for (int i = 0; i < 100; i++)
                {
                    Assert.AreEqual(list[i], i);
                    index++;
                }
                list.Clear();
                Assert.ThrowsException<InvalidOperationException>(() => {
                    foreach (var item in list)
                    {

                    }
                });
                DoubleLinkedList<string> listStr = new DoubleLinkedList<string>();
                foreach (var item in "asdfghjkl;'qwertyuiop[]zxcvbnm,./")
                {
                    listStr.AddLast(item.ToString());
                }
                int indx = 0;
                foreach (var item in listStr)
                {
                    Assert.AreEqual(item, "asdfghjkl;'qwertyuiop[]zxcvbnm,./"[indx].ToString());
                    indx++;
                }
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

                DoubleLinkedList<string> listStr = new DoubleLinkedList<string>();
                foreach (var item in "asdfghjkl;'qwertyuiop[]zxcvbnm,./")
                {
                    listStr.AddLast(item.ToString());
                }
                Assert.AreEqual(listStr.IndexOf("d".ToString()), 2);

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

                
                Assert.ThrowsException<IndexOutOfRangeException>(() => { list.InsertAt(-1, 1); });
                list = new DoubleLinkedList<int>();

                list.InsertAt(100, 131232131);
                for (int i = 0; i < 100; i++)
                {
                    Assert.AreEqual(list[i], default(int));
                }
                Assert.AreEqual(list[100], 131232131);


                DoubleLinkedList<string> listOfString = new DoubleLinkedList<string>();
                foreach (var item in "asdfghjkl;'qwertyuiop[]zxcvbnm,./")
                {
                    listOfString.AddLast(item.ToString());
                }
                listOfString.InsertAt(2, "Z");
                listOfString.InsertAt(6, "T");
                int indx = 0;
                foreach (var item in listOfString)
                {
                    Assert.AreEqual(item, "asZdfgThjkl;'qwertyuiop[]zxcvbnm,./"[indx].ToString());
                    indx++;
                }


                DoubleLinkedList<string> strList = new DoubleLinkedList<string>();
                strList.InsertAt(100, "abc");
                for(int i = 0;i < 100; i++)
                {
                    Assert.IsNull(strList[i]);
                }
                Assert.AreEqual(strList[100], "abc");
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
                for (int i = 0; i < 100; i++)
                {
                    list.AddLast(i);
                }


                for (int i = 0; i < 100; i++)
                {
                    list.SetElementAt(list[i], i);
                }
                for (int i = 0; i < 100; i++)
                {
                    Assert.AreEqual(list[i], i);
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

            [TestMethod]
            public void InsertionSortTest()
            {
                var list = new DoubleLinkedList<int>();

                list.AddLast(4);
                list.AddLast(2);
                list.AddLast(3); 
                list.AddLast(9);
                list.AddLast(0);
                list.AddLast(5);
                list.AddLast(7);
                list.AddLast(6);
                list.AddLast(1);
                list.AddLast(8);

                list.InsertionSortWithDelegate((value1, value2) =>
                {
                    if (value1 > value2)
                    {
                        return 1;
                    }
                    else if (value1 == value2)
                    {
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                });

                for (int i = 0; i < 10; i++)
                {
                    Assert.AreEqual(i, list[i]);
                }

                DoubleLinkedList<string> listStr = new DoubleLinkedList<string>();

                foreach (var value in "fgxyumnqrstvabwhijkopcdelz")
                {
                    listStr.AddLast(value.ToString());
                }
                listStr.InsertionSortWithDelegate((value1, value2) => string.Compare(value1, value2));
                foreach (var value in "abcdefghijklmnopqrstuvwxyz")
                {
                    Assert.AreEqual(value.ToString(), listStr.RemoveFirst());
                }
            }
        }
    }
}
