using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSortCubeScript : MonoBehaviour
{
    public int NumberOfCubes = 15;
    public int CubeHeightMax = 15;
    public GameObject[] CubesSS;

    void Start()
    {
        InitializeRandom();
        StartCoroutine(SelectionSort(CubesSS));
    }

    IEnumerator SelectionSort(GameObject[] unsortedList)
    {
        int min;
        GameObject temp;
        Vector3 tempPosition;

        for (int i = 0; i < unsortedList.Length; i++)
        {
            min = i;
            yield return new WaitForSeconds(1);

            for (int j = i + 1; j < unsortedList.Length; j++)
            {
                if (unsortedList[j].transform.localScale.y < unsortedList[min].transform.localScale.y)
                {
                    min = j;
                }
            }

            if (min != i)
            {
                yield return new WaitForSeconds(1);

                temp = unsortedList[i];
                unsortedList[i] = unsortedList[min];
                unsortedList[min] = temp;

                tempPosition = unsortedList[i].transform.localPosition;

                LeanTween.moveLocalX(unsortedList[i], unsortedList[min].transform.localPosition.x, 0.5f);
                LeanTween.moveLocalZ(unsortedList[i], -0.5f, 1f).setLoopPingPong(1);

                LeanTween.moveLocalX(unsortedList[min], tempPosition.x, 0.5f);
                LeanTween.moveLocalZ(unsortedList[min], 0.5f, 1f).setLoopPingPong(1);

                LeanTween.color(unsortedList[i], Color.yellow, 1f);
            }

            else
            {
                LeanTween.color(unsortedList[i], Color.yellow, 0.5f);
            }
        }

        yield return new WaitForSeconds(1);

        for (int i = 0; i < unsortedList.Length; i++)
        {
            LeanTween.color(unsortedList[i], Color.green, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void InitializeRandom()
    {
        CubesSS = new GameObject[NumberOfCubes];
        for (int i = 0; i < NumberOfCubes; i++)
        {
            int randomNumber = Random.Range(1, CubeHeightMax + 1);

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(0.9f, randomNumber, 1);
            cube.transform.position = new Vector3(i, randomNumber / 2.0f, 0);

            cube.transform.parent = this.transform;

            CubesSS[i] = cube;
        }

        transform.position = new Vector3(-NumberOfCubes / 2f, -CubeHeightMax / 2.0f, 0);
    }
}