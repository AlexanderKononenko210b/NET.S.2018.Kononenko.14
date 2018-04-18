using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Algorithms.Test
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
        public void IComparer_Int_Type_Parameters_Valid_Data(int[] inputArray, int number, int? result)
        {
            var comparer = new IntComparator();

            var indexFindNumber = inputArray.BinarySearch(number, comparer);

            if (indexFindNumber != null)
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
        public void IComparer_Double_Type_Parameters_Valid_Data(double[] inputArray, double number, double? result)
        {
            var comparer = new DoubleComparator();

            var indexFindNumber = inputArray.BinarySearch(number, comparer);

            if (indexFindNumber != null)
                Assert.AreEqual(result, inputArray[(int)indexFindNumber]);
            else
                Assert.AreEqual(result, indexFindNumber);
        }

        /// <summary>
        /// Test Binary search with int type
        /// </summary>
        /// <param name="inputArray">input array</param>
        /// <param name="number">find element</param>
        /// <param name="result">index find element or null</param>
        [TestCase(new int[5] { 5, 12, 33, 45, 96 }, 45, 45)]
        [TestCase(new int[5] { 5, 12, 33, 45, 96 }, 22, null)]
        public void IComparer_Int_Type_Parameters_If_Comparer_Null(int[] inputArray, int number, int? result)
        {
            var comparer = new IntComparator();

            comparer = null;

            var indexFindNumber = inputArray.BinarySearch(number, comparer);

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
        public void IComparer_Double_Type_Parameters_If_Comparer_Null(double[] inputArray, double number, double? result)
        {
            var comparer = new DoubleComparator();

            comparer = null;

            var indexFindNumber = inputArray.BinarySearch(number, comparer);

            if (indexFindNumber != null)
                Assert.AreEqual(result, inputArray[(int)indexFindNumber]);
            else
                Assert.AreEqual(result, indexFindNumber);
        }

        /// <summary>
        /// Test Binary search with int type
        /// </summary>
        /// <param name="inputArray">input array</param>
        /// <param name="number">find element</param>
        /// <param name="result">index find element or null</param>
        [TestCase(new int[5] { 5, 12, 33, 45, 96 }, 45, 45)]
        [TestCase(new int[5] { 5, 12, 33, 45, 96 }, 22, null)]
        public void Comparison_Int_Type_Parameters_Valid_Data(int[] inputArray, int number, int? result)
        {
            var obj = new IntComparison();

            Comparison<int> comparison = obj.Compare;

            var indexFindNumber = inputArray.BinarySearch(number, comparison);

            if (indexFindNumber != null)
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
        public void Comparison_Double_Type_Parameters_Valid_Data(double[] inputArray, double number, double? result)
        {
            var obj = new DoubleComparison();

            Comparison<double> comparison = obj.Compare;

            var indexFindNumber = inputArray.BinarySearch(number, comparison);

            if (indexFindNumber != null)
                Assert.AreEqual(result, inputArray[(int)indexFindNumber]);
            else
                Assert.AreEqual(result, indexFindNumber);
        }

        /// <summary>
        /// Test Binary search with int type
        /// </summary>
        /// <param name="inputArray">input array</param>
        /// <param name="number">find element</param>
        /// <param name="result">index find element or null</param>
        [TestCase(new int[5] { 5, 12, 33, 45, 96 }, 45, 45)]
        [TestCase(new int[5] { 5, 12, 33, 45, 96 }, 22, null)]
        public void Comparison_Int_Type_Parameters_If_Comparison_Null(int[] inputArray, int number, int? result)
        {
            Comparison<int> comparison = null;

            var indexFindNumber = inputArray.BinarySearch(number, comparison);

            if (indexFindNumber != null)
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
        public void Comparison_Double_Type_Parameters_If_Comparison_Null(double[] inputArray, double number, double? result)
        {
            Comparison<double> comparison = null;

            var indexFindNumber = inputArray.BinarySearch(number, comparison);

            if (indexFindNumber != null)
                Assert.AreEqual(result, inputArray[(int)indexFindNumber]);
            else
                Assert.AreEqual(result, indexFindNumber);
        }

        /// <summary>
        /// Test BinarySearch if type does not implement IComparable
        /// </summary>
        [Test]
        public void Point_BinarySearch_If_Type_Does_Not_Implement_IComparable()
        {
            Comparison<Point> comparison = null;

            Point[] inputArray = new Point[3];

            var point1 = new Point(14.0, 5.0);

            inputArray[0] = point1;

            var point2 = new Point(22.0, 5.0);

            inputArray[0] = point2;

            var point3 = new Point(2.0, 5.0);

            inputArray[0] = point3;

            Assert.Throws<GetDefaulCompareException>(() => inputArray.BinarySearch(point2, comparison));
        }
    }
}
