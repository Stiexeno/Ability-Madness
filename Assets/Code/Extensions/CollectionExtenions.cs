using System.Collections.Generic;
using UnityEngine;

namespace AbilityMadness.Code.Extensions
{
    public static class CollectionExtenions
    {
        public static T RandomResult<T>(this T[] array)
        {
            return array[Random.Range(0, array.Length)];
        }

        public static T RandomResult<T>(this List<T> list)
        {
            if (list.Count == 0)
                return default;

            return list[Random.Range(0, list.Count)];
        }
    }
}
