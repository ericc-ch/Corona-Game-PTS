using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Helper
{
    public static class ShufflerClass
    { 
        public static void Shuffle<T> (this T[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                int randomIndex = Random.Range(i, list.Length);

                T temp = list[i];
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }
        }
    }
}