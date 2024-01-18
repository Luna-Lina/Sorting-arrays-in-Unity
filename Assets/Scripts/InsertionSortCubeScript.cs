using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertionSortCubeScript : MonoBehaviour
{
    public int NumberOfCubes = 15;
    public int CubeHeightMax = 15;
    public GameObject[] CubesIS;

    void Start()
    {
        InitializeRandom();
        StartCoroutine(InsertionSort(CubesIS));
    }

    IEnumerator InsertionSort(GameObject[] unsortedList)
    {
        for (int i = 1; i < unsortedList.Length; i++)
        {
            GameObject temp = unsortedList[i];
            int j = i - 1;

            LeanTween.color(temp, Color.yellow, 0.5f);

            while (j >= 0 && temp.transform.localScale.y < unsortedList[j].transform.localScale.y)
            {
                LeanTween.moveLocalX(unsortedList[j], unsortedList[j + 1].transform.localPosition.x, 0.5f);
                LeanTween.moveLocalZ(unsortedList[j], temp.transform.localPosition.z, 1f).setLoopPingPong(1);

                unsortedList[j + 1] = unsortedList[j];
                j--;
                yield return null;
            }

            LeanTween.moveLocalX(temp, unsortedList[j + 1].transform.localPosition.x, 0.5f);
            LeanTween.moveLocalZ(temp, unsortedList[j + 1].transform.localPosition.z, 1f).setLoopPingPong(1);
            temp.transform.localPosition = new Vector3(unsortedList[j + 1].transform.localPosition.x, temp.transform.localPosition.y, unsortedList[j + 1].transform.localPosition.z);

            unsortedList[j + 1] = temp;
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < unsortedList.Length; i++)
        {
            LeanTween.color(unsortedList[i], Color.green, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void InitializeRandom()
    {
        CubesIS = new GameObject[NumberOfCubes];
        for (int i = 0; i < NumberOfCubes; i++)
        {
            int randomNumber = Random.Range(1, CubeHeightMax + 1);

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(0.9f, randomNumber, 1);
            cube.transform.position = new Vector3(i, randomNumber / 2.0f, 0);

            cube.transform.parent = this.transform;

            CubesIS[i] = cube;
        }

        transform.position = new Vector3(-NumberOfCubes / 2f, -CubeHeightMax / 2.0f, 0);
    }
}