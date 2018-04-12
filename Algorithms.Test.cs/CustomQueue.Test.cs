using System;
using NUnit.Framework;
using Algorithms;

namespace Algorithms.Test.cs
{
    /// <summary>
    /// Class for test class CustomQueue
    /// </summary>
    [TestFixture]
    public class CustomQueueTest
    {
        /// <summary>
        /// Test create CustomQueue element type int
        /// </summary>
        [TestCase]
        public void Create_CustomQueue_Type_Int()
        {
            var customQueue = new CustomQueue<int>();
            Assert.AreEqual(4, customQueue.Size);
            Assert.AreEqual(0, customQueue.Count);
        }

        /// <summary>
        /// Test add new elements as last in Queue
        /// </summary>
        [TestCase]
        public void Add_CustomQueue_Type_Int()
        {
            var customQueue = new CustomQueue<int>();
            customQueue.Add(5);
            customQueue.Add(6);
            customQueue.Add(9);
            Assert.AreEqual(3, customQueue.Count);
            Assert.IsTrue(customQueue.Contains(5));
            Assert.IsTrue(customQueue.Contains(6));
            Assert.IsTrue(customQueue.Contains(9));
            Assert.IsFalse(customQueue.Contains(10));
            Assert.AreEqual(5, customQueue.Peek());
        }

        /// <summary>
        /// Test add new elements as last in Queue
        /// </summary>
        [TestCase]
        public void DelPeek_CustomQueue_Type_Int()
        {
            var customQueue = new CustomQueue<int>();
            customQueue.Add(5);
            customQueue.Add(6);
            customQueue.Add(9);
            Assert.AreEqual(5, customQueue.Peek());
            var assert1 = customQueue.DelPeek();
            Assert.AreEqual(5, assert1);
            Assert.AreEqual(6, customQueue.Peek());
        }

        /// <summary>
        /// Test add new elements as last in Queue and resize size queue
        /// </summary>
        [TestCase]
        public void Add_With_Resize_CustomQueue_Type_Int()
        {
            var customQueue = new CustomQueue<int>();
            customQueue.Add(5);
            customQueue.Add(6);
            customQueue.Add(9);
            Assert.AreEqual(4, customQueue.Size);
            customQueue.Add(10);
            Assert.AreEqual(8, customQueue.Size);
            customQueue.Add(8);
            Assert.AreEqual(8, customQueue.Size);
            customQueue.Add(23);
            Assert.AreEqual(8, customQueue.Size);
            customQueue.Add(34);
            Assert.AreEqual(8, customQueue.Size);
            customQueue.Add(23);
            Assert.AreEqual(16, customQueue.Size);
        }

        /// <summary>
        /// Test add new elements as last in Queue and resize size queue
        /// </summary>
        [TestCase]
        public void Clear_CustomQueue_Type_Int()
        {
            var customQueue = new CustomQueue<int>();
            customQueue.Add(5);
            customQueue.Add(6);
            customQueue.Add(9);
            customQueue.Add(10);
            customQueue.Add(8);
            customQueue.Add(23);
            customQueue.Add(34);
            customQueue.Add(23);
            Assert.AreEqual(8, customQueue.Count);
            Assert.AreEqual(16, customQueue.Size);
            customQueue.Clear();
            Assert.AreEqual(0, customQueue.Count);
            Assert.AreEqual(4, customQueue.Size);
        }

        /// <summary>
        /// Test add new elements as last in Queue and resize size queue
        /// </summary>
        [TestCase]
        public void CopyTo_CustomQueue_Type_Int()
        {
            var customQueue = new CustomQueue<int>();
            customQueue.Add(5);
            customQueue.Add(6);
            customQueue.Add(9);
            customQueue.Add(10);
            customQueue.Add(8);
            customQueue.Add(23);
            customQueue.Add(34);
            customQueue.Add(23);
            Assert.AreEqual(8, customQueue.Count);
            Assert.AreEqual(16, customQueue.Size);

            var newArray = new int[customQueue.Size];
            customQueue.CopyTo(newArray, 0);
            Assert.AreEqual(customQueue.Size, newArray.Length);
            Assert.AreEqual(5, newArray[0]);
            Assert.AreEqual(10, newArray[3]);
            Assert.AreEqual(23, newArray[7]);
        }

        /// <summary>
        /// Test Custom Queue if flag ReadOnly in True
        /// </summary>
        [TestCase]
        public void ReadOnly_CustomQueue_Type_Int()
        {
            var customQueue = new CustomQueue<int>();
            customQueue.Add(5);
            customQueue.Add(6);
            customQueue.Add(9);
            customQueue.Add(10);
            customQueue.IsReadOnly = true;

            Assert.Throws<InvalidOperationException>(() => customQueue.Add(4));
            Assert.Throws<InvalidOperationException>(() => customQueue.DelPeek());
            Assert.Throws<InvalidOperationException>(() => customQueue.Clear());
        }
    }
}
