using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSortScript : MonoBehaviour
{
    public int NumberOfCubes { get; internal set; }

    void SelectionSort(int[] unsortedList)
    {
        int min;
        int temp;

        for (int i = 0; i < unsortedList.Length; i++)
        {
            min = i;
            for (int j = 1 + 1; j < unsortedList.Length; j++)
            {
                if (unsortedList[j] < unsortedList[min])
                {
                    min = j;
                }
            }

            if (min != i)
            {
                temp = unsortedList[i];
                unsortedList[i] = unsortedList[min];
                unsortedList[min] = temp;
                PrintArray(unsortedList);
            }
        }
    }

    void PrintArray(int[] someArray)
    {
        string resultString = "";
        for (int i = 0; i < someArray.Length; i++)
        {
            resultString = resultString + someArray[i] + ", ";
        }
        print(resultString);
    }
    void Start()
    {
        int[] myList = new int[]
        {
            2, 5, 1, 3, 4
        };
    PrintArray(myList);
    SelectionSort(myList);
    }

    internal void StartSort()
    {
        throw new NotImplementedException();
    }
}
