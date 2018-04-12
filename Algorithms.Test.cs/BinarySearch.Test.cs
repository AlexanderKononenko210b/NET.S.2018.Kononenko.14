﻿using NUnit.Framework;

namespace Algorithms.Test.cs
{
    /// <summary>
    /// Class test generic binary search
    /// </summary>
    [TestFixture]
    public class BinarySearchTest
    {
        /// <summary>
        /// Test Binary search with int type
        /// </summary>
        /// <param name="inputArray">input array</param>
        /// <param name="number">find element</param>
        /// <param name="result">index find element or null</param>
        [TestCase(new int[5] { 5, 12, 33, 45, 96 }, 45, 45)]
        [TestCase(new int[5] { 5, 12, 33, 45, 96 }, 22, null)]
        public void Int_Type_Parameters_Valid_Data(int[] inputArray, int number, int? result)
        {
            var indexFindNumber = BinarySearchAndNumber.BinarySearchInGeneral(inputArray, number, new IntComparator());
            if(indexFindNumber != null)
                Assert.AreEqual(result, inputArray[(int)indexFindNumber]);
            else
                Assert.AreEqual(result, indexFindNumber);
        }
        /// <summary>
        /// Test Binary search with double type
        /// </summary>
        /// <param name="inputArray">input array</param>
        /// <param name="number">find element</param>
        /// <param name="result">index find element or null</param>
        [TestCase(new double[5] { 5.2, 12.3, 33.8, 45.6, 96.1 }, 45.6, 45.6)]
        [TestCase(new double[5] { 5.2, 12.3, 33.8, 45.6, 96.1 }, 22.4, null)]
        public void Double_Type_Parameters_Valid_Data(double[] inputArray, double number, double? result)
        {
            var indexFindNumber = BinarySearchAndNumber.BinarySearchInGeneral(inputArray, number, new DoubleComparator());

            if (indexFindNumber != null)
                Assert.AreEqual(result, inputArray[(int)indexFindNumber]);
            else
                Assert.AreEqual(result, indexFindNumber);
        }
    }
}