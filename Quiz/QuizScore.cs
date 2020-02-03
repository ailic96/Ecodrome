using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuizScore : MonoBehaviour
{
    public Text scoreText;

    public static int score;
    public static string scoreName;

    public Text inputField;
    public GameObject namePanel;
    public GameObject highscoreTable;

    void Update()
    {
        scoreText.text = "Score: " + ((int)score).ToString();
    }

    public void AddScore()
    {         
        score = score + 10;
    }

    public void StoreName()
    {
        scoreName = inputField.text;
        namePanel.SetActive(false);
        highscoreTable.SetActive(true);
    }
}


