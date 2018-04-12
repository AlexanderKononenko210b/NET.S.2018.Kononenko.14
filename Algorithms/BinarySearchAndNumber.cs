using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Algorithms
{
    
    /// <summary>
    /// Interface for comparer
    /// </summary>
    /// <typeparam name="T">type</typeparam>
    public interface IComparer<T>
    {
        int Compare(T first, T second);
    }

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
        public static int? BinarySearchInGeneral<T>(T[] inputArray, T element, IComparer<T> comparer)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException($"Argument {nameof(inputArray)} is null");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException($"Argument {nameof(comparer)} is null");
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

        #endregion BinarySearch

        #region Fibonachi

        public static long[] Fibo(long number)
        {
            if (number < 1)
                throw new ArgumentOutOfRangeException($"Argument {nameof(number)} must be more than 0");

            if (number == 1)
                return new long[2] { 1, 1 };

            int firstPrev = 1, secondPrev = 1, summ = 0;

            Collection<long> workCollection = new Collection<long>();

            while (number >= summ)
            {
                checked
                {
                    summ = firstPrev + secondPrev;
                }

                workCollection.Add(summ);

                firstPrev = secondPrev;

                secondPrev = summ;

            }

            return workCollection.ToArray();
        }

        #endregion Fibonachi
    }
}
