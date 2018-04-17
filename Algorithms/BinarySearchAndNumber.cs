using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace Algorithms
{
    /// <summary>
    /// Class for Binary search
    /// </summary>
    public static class BinarySearchAndNumber
    {
        #region BinarySearch

        /// <summary>
        /// Generic method for find element in array
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="inputArray">input array</param>
        /// <param name="element">find element</param>
        /// <param name="comparer">comparer for compare two element in array</param>
        /// <returns></returns>
        public static int? BinarySearch<T>(T[] inputArray, T element, IComparer<T> comparer)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException($"Argument {nameof(inputArray)} is null");
            }

            if(element == null)
                throw new ArgumentNullException($"Argument {nameof(element)} is null");

            if (comparer == null)
            {
                comparer = Comparer<T>.Default;

                if (comparer == null)
                    throw new InvalidOperationException($"Type {nameof(T)} does not contain default sort order comparer");
            }

            if (inputArray.Length == 0 || comparer.Compare(inputArray[0], element) > 0 ||
                comparer.Compare(inputArray[inputArray.Length - 1], element) < 0)
                return null;

            int indexHelper = 0, indexLeft = 0, indexRight = inputArray.Length - 1;

            while (!(indexLeft >= indexRight))
            {
                indexHelper = indexLeft + (indexRight - indexLeft) / 2;

                var resultCompare = comparer.Compare(inputArray[indexHelper], element);

                if (resultCompare == 0)
                    return indexHelper;

                if (resultCompare > 0)
                {
                    indexRight = indexHelper;
                }
                else
                {
                    indexLeft = indexHelper + 1;
                }
            }

            return null;
        }

        /// <summary>
        /// Generic method for find element in array
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="inputArray">input array</param>
        /// <param name="element">find element</param>
        /// <param name="comparer">comparer for compare two element in array</param>
        /// <returns></returns>
        public static int? BinarySearch<T>(T[] inputArray, T element, Comparison<T> comparison)
        {
            if (inputArray == null)
                throw new ArgumentNullException($"Argument {nameof(inputArray)} is null");

            if (element == null)
                throw new ArgumentNullException($"Argument {nameof(element)} is null");

            if (comparison == null)
            {
                comparison = Comparer<T>.Default.Compare;

                if(comparison == null)
                    throw new InvalidOperationException($"Type {nameof(T)} does not contain default sort order comparer");
            }

            if (inputArray.Length == 0 || comparison(inputArray[0], element) > 0 ||
                comparison(inputArray[inputArray.Length - 1], element) < 0)
                return null;

            int indexHelper = 0, indexLeft = 0, indexRight = inputArray.Length - 1;

            while (!(indexLeft >= indexRight))
            {
                indexHelper = indexLeft + (indexRight - indexLeft) / 2;

                var resultCompare = comparison(inputArray[indexHelper], element);

                if (resultCompare == 0)
                    return indexHelper;

                if (resultCompare > 0)
                {
                    indexRight = indexHelper;
                }
                else
                {
                    indexLeft = indexHelper + 1;
                }
            }

            return null;
        }

        #endregion BinarySearch

        #region Fibonachi

        /// <summary>
        /// Public method Generator Fibonachi numbers for greedy check
        /// </summary>
        /// <param name="number">number - limit</param>
        /// <returns>enumerator fibonachi`s numbers</returns>
        public static IEnumerable<BigInteger> GeneratorFibonachiNumber(long number)
        {
            if (number < 1)
                throw new ArgumentOutOfRangeException($"Argument {nameof(number)} must be more than 0");

            if (number == 1)
                return new BigInteger[2] { new BigInteger(1), new BigInteger(1) };

            return FibonachiGenerator(number);

        }

        /// <summary>
        /// Private Fibonachi Generator numbers 
        /// </summary>
        /// <param name="number">number - limit</param>
        /// <returns>instance iterator</returns>
        private static IEnumerable<BigInteger> FibonachiGenerator(long number)
        {
            var first = new BigInteger(1);

            var second = first;

            var summ = first + second;

            while (summ < number)
            {
                summ = first + second;

                if (summ < number)
                {
                    first = second;

                    second = summ;

                    yield return summ;
                }
                else
                    yield break;
            }
        }

        #endregion Fibonachi
    }
}
