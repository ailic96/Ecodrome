using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePickup : MonoBehaviour
{
    public PuzzleCounter puzzleCounter;
    public Transform onHand;
    public GameObject puzzleSlot;
    private bool pieceFixed = false;
    
    private void OnMouseDown()
    {
        if (pieceFixed == false)
        {
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = onHand.transform.position;
            this.transform.parent = GameObject.Find("Player").transform;
        }
    }

    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == gameObject.name)
        {
            gameObject.transform.position = other.transform.position;
            gameObject.transform.rotation = other.transform.rotation;

            gameObject.SetActive(false);
            puzzleSlot.GetComponent<SpriteRenderer>().enabled = true;
            puzzleCounter.GetComponent<PuzzleCounter>().puzzleCount--;
            pieceFixed = true;

            FindObjectOfType<SoundManager>().Play("LearnSound");
        }
    }
}
