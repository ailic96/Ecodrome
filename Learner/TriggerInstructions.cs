using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerInstructions : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject uiText;
    public GameObject factText;
    public GameObject runnerNotice;

    void Start()
    {
        uiObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player")
        {        
            uiObject.SetActive(true);       //UI background
            uiText.SetActive(true);         //Instruction text
            factText.SetActive(false);      //Information text
            FindObjectOfType<SoundManager>().Play("LearnSound");
        }
    }
    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            uiObject.SetActive(false);
            uiText.SetActive(false);
            factText.SetActive(true);
        }
    }
}
