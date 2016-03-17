using System;
using System.Collections.Generic;

namespace MilitaryPuzzle.App.Logic
{
    public class ListHelpers<T> 
        where T:IComparable<T>
    {

        public static T[] NextPermutation(T[] a)
        {
            int? largestK = null;
            int? largestI = null;
            for (var k = 0; k < (a.Length - 1); k++)
            {
                if (a[k].CompareTo(a[k+1]) < 0)
                {
                    largestK = k;
                    for (var i = (k + 1); i < a.Length; i++)
                    {
                        if (a[k].CompareTo(a[i]) < 0)
                        {
                            largestI = i;
                        }
                    }
                }
            }
            if (!largestK.HasValue)
            {
                // This is the last permutation
                return null;
            }
            if (!largestI.HasValue)
            {
                throw new Exception("I think we should have had a value here");
            }

            Swap(a, largestI.Value, largestK.Value);
            Array.Reverse(a, largestK.Value + 1, a.Length - (largestK.Value + 1));
            return a;
        }
        
        private static void Swap(IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
