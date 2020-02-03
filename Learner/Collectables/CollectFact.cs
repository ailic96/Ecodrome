using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectFact : MonoBehaviour
{
    private GameObject[] getCount;

    public int factCount = 0;

    public GameObject objectToDeactivate;
    public GameObject objectToActivate;
    public GameObject objectUI;   
    public string taskText;
    public string taskComplete;
    
    void Start()
    {
        getCount = GameObject.FindGameObjectsWithTag("Fact");
        factCount = getCount.Length;
    }

    void Update()
    {
        objectUI.GetComponent<Text>().text = factCount.ToString() + taskText;
        if(factCount == 1)
        {
            objectUI.GetComponent<Text>().text = factCount.ToString() + " fact to collect!";
        }
        if (factCount <= 0)
        {
            objectUI.GetComponent<Text>().text = taskComplete;
            objectToDeactivate.SetActive(false);
            objectToActivate.SetActive(true);
        }
    }
}
