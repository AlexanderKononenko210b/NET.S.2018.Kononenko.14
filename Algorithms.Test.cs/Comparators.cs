using System;
using System.Collections.Generic;

namespace Algorithms.Test
{
    #region IComparer

    /// <summary>
    /// Comparator for type int
    /// </summary>
    public sealed class IntComparator : IComparer<int>
    {
        public int Compare(int first, int second)
        {
            if (first == second)
                return 0;
            else if (first > second)
                return 1;
            else return -1;
        }
    }

    /// <summary>
    /// Comparator for type double
    /// </summary>
    public sealed class DoubleComparator : IComparer<double>
    {
        public int Compare(double first, double second)
        {
            double accuracy = 0;

            try
            {
                var appSettingsReader = new System.Configuration.AppSettingsReader();

                accuracy = (double)appSettingsReader.GetValue("accuracy", typeof(double));
            }
            catch (Exception)
            {
                accuracy = 0.000001;
            }

            if (Math.Abs(first - second) < accuracy)
            {
                return 0;
            }
            else if (first > second)
                return 1;
            else return -1;
        }
    }

    #endregion IComparer

    #region Comparison<T>

    /// <summary>
    /// Comparator for type int
    /// </summary>
    public sealed class IntComparison
    {
        public int Compare(int first, int second)
        {
            if (first == second)
                return 0;
            else if (first > second)
                return 1;
            else return -1;
        }
    }

    /// <summary>
    /// Comparator for type double
    /// </summary>
    public sealed class DoubleComparison
    {
        public int Compare(double first, double second)
        {
            double accuracy = 0;

            try
            {
                var appSettingsReader = new System.Configuration.AppSettingsReader();

                accuracy = (double)appSettingsReader.GetValue("accuracy", typeof(double));
            }
            catch (Exception)
            {
                accuracy = 0.000001;
            }

            if (Math.Abs(first - second) < accuracy)
            {
                return 0;
            }
            else if (first > second)
                return 1;
            else return -1;
        }
    }

    #endregion Comparison<T>
}
