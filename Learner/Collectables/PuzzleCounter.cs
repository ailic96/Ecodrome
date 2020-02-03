using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleCounter : MonoBehaviour
{
    private GameObject[] getPuzzleCount;
    public GameObject objectUI;
    public int puzzleCount;

    void Start()
    {
        getPuzzleCount = GameObject.FindGameObjectsWithTag("Puzzle");
        puzzleCount = getPuzzleCount.Length;
    }

    void Update()
    {
        objectUI.GetComponent<Text>().text = puzzleCount.ToString() + " puzzles to arrange!";
        if(puzzleCount == 1)
        {
            objectUI.GetComponent<Text>().text = puzzleCount.ToString() + " puzzle to arrange!";
        }
        else if (puzzleCount == 0)
        {
            objectUI.GetComponent<Text>().text = "All puzzles arranged! Proceed to the forrest " +
                "cleaning mission if you want to learn more!";
        }
    }
}
