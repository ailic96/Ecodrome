using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float nextSpawnTime;
    [SerializeField]
    private GameObject[] spawnPrefab;
    [SerializeField]
    public float minDelay;
    public float maxDelay;
    public float spawnDelay;
    int randPrefab;

    void Update()
    {
        if (ShouldSpawn())
        {
            StartCoroutine(DelaySpawn());
            Spawn();
        }
    }

    private void Spawn()
    {
        spawnDelay = Random.Range(minDelay, maxDelay);
        randPrefab = Random.Range(0, spawnPrefab.Length);
        nextSpawnTime = Time.time + spawnDelay;
        Instantiate(spawnPrefab[randPrefab], transform.position, transform.rotation);
    }
    private bool ShouldSpawn()
    {
        {
            return Time.time >= nextSpawnTime;
        }
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(spawnDelay);
    }
}
