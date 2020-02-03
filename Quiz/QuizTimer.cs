using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizTimer : MonoBehaviour
{
    public float timeRemaining;
    public Text timeRemainingText;

    void Update()
    {
        Countdown();
    }

    private void Countdown()
    {
        if (GetComponent<QuizManager>().activeRound)
        {
            timeRemaining -= Time.deltaTime;
            timeRemainingText.text = "Time: " + Mathf.Round(timeRemaining).ToString();

            if (timeRemaining <= 0f)
            {
                GetComponent<QuizManager>().RoundGameOver();
            }
        }
    }
}
