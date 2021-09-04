using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomElementSelector : MonoBehaviour
{
        public static IList<T> CollectAllowedElements<T>(IList<T> allElements, IList<T> excludedElements)
        {
            List<T> allowedElements = new List<T>();
            foreach (T element in allElements)
                if (!excludedElements.Contains(element))
                    allowedElements.Add(element);
            return allowedElements;
        }

        public static T SelectRandomElement<T>(IList<T> allowedElements)
        {
            System.Random random = new System.Random();
            int randomIndex = random.Next(allowedElements.Count);
            return allowedElements[randomIndex];
        }

        public static T SelectRandomElement<T>(IList<T> allElements, IList<T> excludedElements)
        {
            IList<T> allowedElements = CollectAllowedElements(allElements, excludedElements);
            return SelectRandomElement(allowedElements);
        }
    /*const int N = 100;

         Example #1
        int[] allNumbers = new int[N];
        for (int i = 0; i < allNumbers.Length; ++i)
            allNumbers[i] = i + 1;
        int[] excludedNumbers = { 5, 7, 17, 23 };
        Console.WriteLine(RandomElementSelector.SelectRandomElement(allNumbers, excludedNumbers));
        */
}
