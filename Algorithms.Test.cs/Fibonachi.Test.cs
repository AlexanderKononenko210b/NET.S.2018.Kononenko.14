using System;
using System.Numerics;
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
        [Test]
        public void Fibonachi_Valid_Data()
        {
            var bigIntegerArray = new BigInteger[11] { new BigInteger(1), new BigInteger(1), new BigInteger(2), new BigInteger(3), new BigInteger(5),
            new BigInteger(8), new BigInteger(13), new BigInteger(21), new BigInteger(34), new BigInteger(55), new BigInteger(89) };

            var numberBorder = 80;

            var index = 2;

            foreach(BigInteger element in BinarySearchAndNumber.GeneratorFibonachiNumber(numberBorder))
            {
                Assert.AreEqual(bigIntegerArray[index], element);

                index++;
            }
        }

        /// <summary>
        /// Method for test Febonachi`s line numbers with valid data
        /// </summary>
        [Test]
        public void Fibonachi_Valid_Data_If_NumberBorder_1()
        {
            var bigIntegerArray = new BigInteger[2] { new BigInteger(1), new BigInteger(1) };

            var numberBorder = 1;

            var index = 0;

            foreach (BigInteger element in BinarySearchAndNumber.GeneratorFibonachiNumber(numberBorder))
            {
                Assert.AreEqual(bigIntegerArray[index], element);

                index++;
            }
        }

        /// <summary>
        /// Method for test Febonachi`s line numbers expected ArgumentException
        /// </summary>
        /// <param name="numberBorder">border for array</param>
        /// <param name="result">output array</param>
        [TestCase]
        public void Fibonachi_Expected_ArgumentOutOfRangeException_If_BorderNumber_Negative()
        {
            var bigIntegerArray = new BigInteger[11] { new BigInteger(1), new BigInteger(1), new BigInteger(2), new BigInteger(3), new BigInteger(5),
            new BigInteger(8), new BigInteger(13), new BigInteger(21), new BigInteger(34), new BigInteger(55), new BigInteger(89) };

            var numberBorder = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => BinarySearchAndNumber.GeneratorFibonachiNumber(numberBorder));
        }

        /// <summary>
        /// Method for test Febonachi`s line numbers expected ArgumentException
        /// </summary>
        /// <param name="numberBorder">border for array</param>
        /// <param name="result">output array</param>
        [TestCase]
        public void Fibonachi_Expected_ArgumentOutOfRangeException_If_BorderNumber_0()
        {
            var bigIntegerArray = new BigInteger[11] { new BigInteger(1), new BigInteger(1), new BigInteger(2), new BigInteger(3), new BigInteger(5),
            new BigInteger(8), new BigInteger(13), new BigInteger(21), new BigInteger(34), new BigInteger(55), new BigInteger(89) };

            var numberBorder = 0;

            Assert.Throws<ArgumentOutOfRangeException>(() => BinarySearchAndNumber.GeneratorFibonachiNumber(numberBorder));
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
