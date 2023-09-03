using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public static class ListExtensions
    {
        public static void Shuffle<T>(this List<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var m = Random.Range(0, n+1);
                var temp = list[n];
                list[n] = list[m];
                list[m] = temp;
            }
        }
    }
}