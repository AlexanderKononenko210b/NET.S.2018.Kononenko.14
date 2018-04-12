using System;
using NUnit.Framework;

namespace Algorithms.Test.cs
{
    #region Fibonachi Test

    /// <summary>
    /// Class for test Febonachi`s line numbers method
    /// </summary>
    public class Fibonachi
    {
        /// <summary>
        /// Method for test Febonachi`s line numbers with valid data
        /// </summary>
        /// <param name="numberBorder">border for array</param>
        /// <param name="result">output array</param>
        [TestCase(80, new int[11] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 })]
        [TestCase(1, new int[2] { 1, 1 })]
        public void Fibonachi_Valid_Data(int numberBorder, int[] result)
        {
            var outputArray = BinarySearchAndNumber.Fibo(numberBorder);

            Assert.IsTrue(FibonachiHelper(outputArray));
        }

        /// <summary>
        /// Method for test Febonachi`s line numbers expected ArgumentException
        /// </summary>
        /// <param name="numberBorder">border for array</param>
        /// <param name="result">output array</param>
        [TestCase(-1, new int[11] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 })]
        [TestCase(0, new int[11] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 })]
        public void Fibonachi_Expected_ArgumentOutOfRangeException(int numberBorder, int[] result)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => BinarySearchAndNumber.Fibo(numberBorder));
        }

        #region Helper

        public bool FibonachiHelper(long[] outputArray)
        {
            for(long i = 2; i < outputArray.Length - 1 ; i++)
            {
                if (outputArray[i] != outputArray[i - 2] + outputArray[i - 1])
                    return false;
            }

            return true;
        }

        #endregion Helper
    }

    #endregion Fibonachi Test
}
