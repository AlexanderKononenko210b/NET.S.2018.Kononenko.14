using System;
using NUnit.Framework;
using Algorithms;

namespace Algorithms.Test
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
        /// Test Enqueue new elements as last in Queue
        /// </summary>
        [TestCase]
        public void Enqueue_CustomQueue_Type_Int()
        {
            var customQueue = new CustomQueue<int>();
            customQueue.Enqueue(5);
            customQueue.Enqueue(6);
            customQueue.Enqueue(9);
            Assert.AreEqual(3, customQueue.Count);
            Assert.IsTrue(customQueue.Contains(5));
            Assert.IsTrue(customQueue.Contains(6));
            Assert.IsTrue(customQueue.Contains(9));
            Assert.IsFalse(customQueue.Contains(10));
            Assert.AreEqual(5, customQueue.Peek());
        }

        /// <summary>
        /// Test Dequeue element in CustomQueue
        /// </summary>
        [TestCase]
        public void Dequeue_CustomQueue_Type_Int()
        {
            var customQueue = new CustomQueue<int>();
            customQueue.Enqueue(5);
            customQueue.Enqueue(6);
            customQueue.Enqueue(9);
            Assert.AreEqual(5, customQueue.Peek());
            var assert1 = customQueue.Dequeue();
            Assert.AreEqual(5, assert1);
            Assert.AreEqual(6, customQueue.Peek());
        }

        /// <summary>
        /// Test Enqueue new elements as last in Queue and resize size queue
        /// </summary>
        [TestCase]
        public void Enqueue_With_Resize_CustomQueue_Type_Int()
        {
            var customQueue = new CustomQueue<int>();
            customQueue.Enqueue(5);
            customQueue.Enqueue(6);
            customQueue.Enqueue(9);
            Assert.AreEqual(4, customQueue.Size);
            customQueue.Enqueue(10);
            Assert.AreEqual(8, customQueue.Size);
            customQueue.Enqueue(8);
            Assert.AreEqual(8, customQueue.Size);
            customQueue.Enqueue(23);
            Assert.AreEqual(8, customQueue.Size);
            customQueue.Enqueue(34);
            Assert.AreEqual(8, customQueue.Size);
            customQueue.Enqueue(23);
            Assert.AreEqual(16, customQueue.Size);
        }

        /// <summary>
        /// Test Clear all elements in CustomQueue
        /// </summary>
        [TestCase]
        public void Clear_CustomQueue_Type_Int()
        {
            var customQueue = new CustomQueue<int>();
            customQueue.Enqueue(5);
            customQueue.Enqueue(6);
            customQueue.Enqueue(9);
            customQueue.Enqueue(10);
            customQueue.Enqueue(8);
            customQueue.Enqueue(23);
            customQueue.Enqueue(34);
            customQueue.Enqueue(23);
            Assert.AreEqual(8, customQueue.Count);
            Assert.AreEqual(16, customQueue.Size);
            customQueue.Clear();
            Assert.AreEqual(0, customQueue.Count);
            Assert.AreEqual(4, customQueue.Size);
        }

        /// <summary>
        /// Test Enqueue new elements as last in Queue and resize size queue
        /// </summary>
        [TestCase]
        public void Foreach_CustomQueue_Type_Int()
        {
            var customQueue = new CustomQueue<int>();
            customQueue.Enqueue(5);
            customQueue.Enqueue(6);
            customQueue.Enqueue(9);
            customQueue.Enqueue(10);
            customQueue.Enqueue(8);
            customQueue.Enqueue(23);
            customQueue.Enqueue(34);
            customQueue.Enqueue(23);
            var index = 0;
            foreach(int number in customQueue)
            {
                Assert.AreEqual(customQueue[index], number);
                index++;
            }
        }
    }
}
