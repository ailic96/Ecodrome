using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public GameObject[] floorPrefabs;
    private Transform playerTransform; 

    private float spawnZ = -11.5f;
    private float floorLenght = 24f;
    private float safeZone = 40f;   
    private int numFloors = 8;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeFloors;

    void Start()
    {        
        activeFloors = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        for (int i=0; i < numFloors; i++)
        {
            if (i < 2)
                SpawnFloor(0);
            else
                SpawnFloor();
        }
    }

    void Update()
    {
        if(playerTransform.position.z - safeZone > (spawnZ - numFloors * floorLenght))
        {
            SpawnFloor();
            DeleteFloor();
        }
    }

    private void SpawnFloor(int prefabIndex = -1)
    {
        GameObject go;

        if (prefabIndex == -1)
            go = Instantiate(floorPrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(floorPrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += floorLenght;
        activeFloors.Add(go);
    }

    private void DeleteFloor()
    {
        Destroy(activeFloors[0]);
        activeFloors.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (floorPrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, floorPrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
