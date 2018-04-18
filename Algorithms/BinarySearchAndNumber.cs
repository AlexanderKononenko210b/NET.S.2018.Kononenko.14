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
        /// Generic method for find element in collection implement IEnumerable using IComparer<typeparamref name="TSource"/>
        /// </summary>
        /// <typeparam name="TSource">type</typeparam>
        /// <param name="inputArray">input array</param>
        /// <param name="element">find element</param>
        /// <param name="comparer">comparer for compare two element in array</param>
        /// <returns>result of search</returns>
        public static int? BinarySearch<TSource>(this TSource[] inputArray, TSource element, IComparer<TSource> comparer)
        {
            if (inputArray == null)
                throw new ArgumentNullException($"Argument {nameof(inputArray)} is null");

            if(element == null)
                throw new ArgumentNullException($"Argument {nameof(element)} is null");

            if (comparer == null)
            {
                if(typeof(TSource).GetInterface("IComparable<TSource>") != null || typeof(TSource).GetInterface("IComparable") != null)
                    comparer = Comparer<TSource>.Default;
                else
                    throw new GetDefaulCompareException($"Type {nameof(TSource)} does not contain default sort order comparer");
            }

            if (inputArray.Length == 0 || comparer.Compare(inputArray[0], element) > 0 ||
                comparer.Compare(inputArray[inputArray.Length - 1], element) < 0)
                return null;

            return BinarySearchHelper(inputArray, element, comparer.Compare);
        }

        /// <summary>
        /// Generic method for find element in collection implement IEnumerable using Comparison<typeparamref name="TSource"/>
        /// </summary>
        /// <typeparam name="TSource">type</typeparam>
        /// <param name="inputArray">input array</param>
        /// <param name="element">find element</param>
        /// <param name="comparison">comparer for compare two element in array</param>
        /// <returns>result of search</returns>
        public static int? BinarySearch<TSource>(this TSource[] inputArray, TSource element, Comparison<TSource> comparison)
        {
            if (inputArray == null)
                throw new ArgumentNullException($"Argument {nameof(inputArray)} is null");

            if (element == null)
                throw new ArgumentNullException($"Argument {nameof(element)} is null");

            if (comparison == null)
            {
                if (typeof(TSource).GetInterface("IComparable<TSource>") != null || typeof(TSource).GetInterface("IComparable") != null)
                    comparison = Comparer<TSource>.Default.Compare;
                else
                    throw new GetDefaulCompareException($"Type {nameof(TSource)} does not contain default sort order comparer");
            }

            if (inputArray.Length == 0 || comparison(inputArray[0], element) > 0 ||
                comparison(inputArray[inputArray.Length - 1], element) < 0)
                return null;

            return BinarySearchHelper(inputArray, element, comparison);
        }

        /// <summary>
        /// Helper generic method for find element in array using Comparison<typeparamref name="TSource"/>
        /// </summary>
        /// <typeparam name="TSource">type</typeparam>
        /// <param name="inputArray">input array</param>
        /// <param name="element">find element</param>
        /// <param name="comparison">comparer for compare two element in array</param>
        /// <returns>result of search</returns>
        private static int? BinarySearchHelper<TSource>(TSource[] inputArray, TSource element, Comparison<TSource> comparison)
        {
            int indexHelper = 0, indexLeft = 0, indexRight = inputArray.Length - 1;

            while (!(indexLeft >= indexRight))
            {
                indexHelper = indexLeft + (indexRight - indexLeft) / 2;

                var resultCompare = comparison(inputArray[indexHelper], element);

                if (resultCompare == 0)
                    return indexHelper;

                if (resultCompare > 0)
                    indexRight = indexHelper;
                else
                    indexLeft = indexHelper + 1;
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
