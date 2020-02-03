using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectConstantMove : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 moveVector;
    public float deletePrefabAfter;

    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("Obstracle");
    }

    void Update()
    {
        transform.Translate(moveVector * moveSpeed * UnityEngine.Time.deltaTime);
        StartCoroutine(DestroyPrefab());
    }

    IEnumerator DestroyPrefab()
    {
        yield return new WaitForSeconds(deletePrefabAfter);
        Destroy(gameObject);
    }
}
