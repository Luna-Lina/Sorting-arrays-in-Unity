using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSortCubeScript : MonoBehaviour
{
    public int NumberOfCubes = 15;
    public int CubeHeightMax = 15;
    public GameObject[] CubesBS;

    void Start()
    {
        InitializeRandom();
        StartCoroutine(BubbleSort(CubesBS));
    }

    IEnumerator BubbleSort(GameObject[] unsortedList)
    {
        int n = unsortedList.Length;

        bool swapped;

        do
        {
            swapped = false;

            yield return new WaitForSeconds(1);

            for (int i = 0; i < n - 1; i++)
            {
                if (unsortedList[i].transform.localScale.y > unsortedList[i + 1].transform.localScale.y)
                {
                    GameObject temp = unsortedList[i];
                    unsortedList[i] = unsortedList[i + 1];
                    unsortedList[i + 1] = temp;

                    Vector3 tempPosition = unsortedList[i].transform.localPosition;
                    LeanTween.moveLocalX(unsortedList[i], unsortedList[i + 1].transform.localPosition.x, 0.5f);
                    LeanTween.moveLocalZ(unsortedList[i], -0.5f, 1f).setLoopPingPong(1);

                    LeanTween.moveLocalX(unsortedList[i + 1], tempPosition.x, 0.5f);
                    LeanTween.moveLocalZ(unsortedList[i + 1], 0.5f, 1f).setLoopPingPong(1);

                    LeanTween.color(unsortedList[i], Color.yellow, 1f);
                    LeanTween.color(unsortedList[i + 1], Color.yellow, 1f);

                    swapped = true;

                    yield return new WaitForSeconds(1);
                }
            }
        } while (swapped);

        for (int i = 0; i < n; i++)
        {
            LeanTween.color(unsortedList[i], Color.green, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
    }



    void InitializeRandom()
    {
        CubesBS = new GameObject[NumberOfCubes];
        for (int i = 0; i < NumberOfCubes; i++)
        {
            int randomNumber = Random.Range(1, CubeHeightMax + 1);

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(0.9f, randomNumber, 1);
            cube.transform.position = new Vector3(i, randomNumber / 2.0f, 0);

            cube.transform.parent = this.transform;

            CubesBS[i] = cube;
        }

        transform.position = new Vector3(-NumberOfCubes / 2f, -CubeHeightMax / 2.0f, 0);
    }
}