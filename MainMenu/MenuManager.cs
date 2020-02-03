using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text highScoreText;
    public Text glassScoreText;
    public Text plasticScoreText;
    public Text paperScoreText;

    void Start()
    {
        highScoreText.text = "Time:      "     +     (int)PlayerPrefs.GetFloat("HighScore");
        glassScoreText.text = "Glass:		" +     (int)PlayerPrefs.GetFloat("GlassScore");
        plasticScoreText.text = "Plastic:	" +     (int)PlayerPrefs.GetFloat("PlasticScore");
        paperScoreText.text = "Paper:		" +     (int)PlayerPrefs.GetFloat("PaperScore");
    }

    public void PlayRunner()
    {
        SceneManager.LoadScene("Runner");
    }

    public void PlayLearner()
    {
        SceneManager.LoadScene("Learner");
    }

    public void PlayQuiz()
    {
        SceneManager.LoadScene("Quiz");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
