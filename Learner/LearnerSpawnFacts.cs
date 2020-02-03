using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnerSpawnFacts : MonoBehaviour
{
    public GameObject fact;
    public GameObject[] spawner;
    public int minNum;
    public int maxNum;
    private int xPos;
    private int zPos;
    public int xPosMin;
    public int xPosMax;
    public int zPosMin;
    public int zPosMax;
    public float overlapRadius;     

    void Awake()
    {
        int factCount = Random.Range(minNum, maxNum);

        spawner = new GameObject[factCount];

        for (int i = 0; i < spawner.Length; i++)
        {
            Vector3 position = new Vector3(xPos, 1, zPos);
            xPos = Random.Range(xPosMin, xPosMax);
            zPos = Random.Range(zPosMin, zPosMax);

            if (Physics.CheckSphere(position, overlapRadius))
            {
                Debug.Log("Overlap detected!");
            }
            else
            {
                GameObject clone = Instantiate(fact, position, Quaternion.identity);

                spawner[i] = clone;
            }
        } 
    }
}

