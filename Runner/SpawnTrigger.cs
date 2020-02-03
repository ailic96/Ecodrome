
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public Transform Spawnpoint;
    public GameObject[] spawnPrefab;

    public float spawnDelay;
    int randPrefab;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            randPrefab = Random.Range(0, spawnPrefab.Length);
            StartCoroutine(DelaySpawn());
            Instantiate(spawnPrefab[randPrefab], Spawnpoint.position, Spawnpoint.rotation);
        }
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(spawnDelay);
    }
}
