using System;
using System.Collections;

namespace Algorithms
{
    /// <summary>
    /// Custom class queue
    /// </summary>
    /// <typeparam name="T">type object for save in queue</typeparam>
    public class CustomQueue<T> : ICollection, IEnumerable
    {
        private const int INITIAL_SIZE = 4;

        private const int GROWTH_FACTOR = 2;

        private int head;

        private int tail;

        private int size;

        private int count;

        private bool isreadonly;

        private T[] array;

        public CustomQueue()
        {
            this.size = INITIAL_SIZE;

            this.array = new T[INITIAL_SIZE];

            this.head = 0;

            this.tail = 0;
        }

        /// <summary>
        /// Method for resize array with copy element
        /// </summary>
        /// <returns>new array</returns>
        private T[] ResizeArray()
        {
            T[] newArray;

            checked
            {
                size = array.Length * GROWTH_FACTOR;
            }

            newArray = new T[size];

            array.CopyTo(newArray, 0);

            return newArray;
        }

        /// <summary>
        /// Method for copy all element array in new array without first element
        /// </summary>
        /// <param name="newArray">arraay for copy with the same Length</param>
        /// <param name="arrayIndex">index for start copy</param>
        private void DelCopyTo(T[] newArray, int arrayIndex)
        {
            for (int i = arrayIndex; i <= tail; i++)
            {
                newArray[i - 1] = this.array[i];
            }
        }

        /// <summary>
        /// Property for return count element in array
        /// </summary>
        public int Count => count;

        /// <summary>
        /// Property for return size of array
        /// </summary>
        public int Size => array.Length;

        /// <summary>
        /// Property flag for the determining that instance is read only
        /// </summary>
        public bool IsReadOnly
        {
            get => isreadonly;

            set
            {
                isreadonly = value;
            }
        }

        /// <summary>
        /// Property for object synchronized
        /// </summary>
        public object SyncRoot => throw new NotImplementedException();

        /// <summary>
        /// Property flag for synchronized
        /// </summary>
        public bool IsSynchronized => throw new NotImplementedException();

        /// <summary>
        /// Method for add new element in queue
        /// </summary>
        /// <param name="obj">object for add in queue</param>
        public void Add(T obj)
        {
            if (IsReadOnly)
                throw new InvalidOperationException($"Queue only for read");

            if (obj == null)
                throw new ArgumentNullException($"Argument {nameof(obj)} is null");
            if (tail == 0)
            {
                array[tail] = obj;
            }

            array[tail++] = obj;

            count++;

            if (tail == array.Length)
            {
                array = ResizeArray();
            }
        }

        /// <summary>
        /// Method for return first element in array without delete this element
        /// </summary>
        /// <returns>last element in queue</returns>
        public T Peek()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException($"Queue is empty");
            }

            return array[head];
        }

        /// <summary>
        /// Method for return first element in array with delete this element
        /// </summary>
        /// <returns>first element in queue</returns>
        public T DelPeek()
        {
            if (IsReadOnly)
                throw new InvalidOperationException($"Queue only for read");

            if (Count == 0)
            {
                throw new InvalidOperationException($"Queue is empty");
            }

            var firstElement = array[0];

            var newArray = new T[size];

            this.DelCopyTo(newArray, 1);

            array = newArray;

            return firstElement;
        }

        /// <summary>
        /// Method for clear queue
        /// </summary>
        public void Clear()
        {
            if (IsReadOnly)
                throw new InvalidOperationException($"Queue only for read");

            if (Count == 0)
                throw new InvalidOperationException($"Queue is already clear");

            array = new T[INITIAL_SIZE];

            this.count = 0;

            this.size = 4;
        }

        /// <summary>
        /// Method for determain that queue contain item
        /// </summary>
        /// <param name="item">element for find in queue</param>
        /// <returns>true if queue contain element</returns>
        public bool Contains(T item)
        {
            if(item == null)
                throw new ArgumentNullException($"Argument {nameof(item)} is null");

            if (Count == 0)
                throw new InvalidOperationException($"Queue is Empty");

            //for (int i = 0; i <= tail; i++)
            //    if (array[i].Equals(item))
            //        return true;

            var enumerator = GetEnumerator();

            while (enumerator.MoveNext())
                if (enumerator.Current.Equals(item))
                    return true;
            return false;
        }

        /// <summary>
        /// Method for copy all element queue in array
        /// </summary>
        /// <param name="newArray">new array</param>
        /// <param name="index">index for copy</param>
        public void CopyTo(Array newArray, int index)
        {
            if(newArray == null)
                throw new ArgumentNullException($"Argument {nameof(array)} is null");

            if(index < 0)
                throw new ArgumentOutOfRangeException($"Argument {nameof(index)} is out of range");

            var castResult = newArray as T[];

            if (castResult == null)
                throw new InvalidCastException($"Input argument {nameof(newArray)} is not cast to {nameof(T)}[]");

            if (castResult.Length < Count)
                throw new InvalidOperationException($"Lenth argument {nameof(newArray)} must be more or equals count of elements in queue");

            if(castResult.Length - 1 < index)
                throw new ArgumentOutOfRangeException($"Argument {nameof(index)} must be less or equals index last elements in argument {nameof(newArray)}");

            if (index > tail)
                for (int i = index; i < array.Length; i++)
                    castResult[i] = default(T);
            else
                for (int i = index; i <= tail; i++)
                    castResult[i] = this.array[i];

            newArray = castResult;
        }

        /// <summary>
        /// Method return object type IEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            if (Count == 0)
                throw new InvalidOperationException($"Queue does not contain element");
            return array.GetEnumerator();
        }
    }
}
