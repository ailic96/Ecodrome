using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrash : MonoBehaviour
{
    public GameObject[] trash;
    public float trashTime;
    public float sphereRadius;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(spawnTrash());
    }

    IEnumerator spawnTrash()
    {
        yield return new WaitForSeconds(trashTime);
        Spawn();
    }

    void Spawn()
    {
        float[] xPos = new float[3];
        xPos[0] = 0f;
        xPos[1] = 1f;
        xPos[2] = 2.2f;

        int randomTrash = Random.Range(0, trash.Length);
        int RandomXposition = Random.Range(0, xPos.Length);

        Vector3 hposition = new Vector3(xPos[RandomXposition], 0.2f, player.position.z + 60);
        if (Physics.CheckSphere(hposition, sphereRadius))
        {
            Debug.Log("Overlap detected!");
        }
        else
        {
            Instantiate(trash[randomTrash], hposition, trash[randomTrash].transform.rotation);
        }
        StartCoroutine(spawnTrash());
    }
}