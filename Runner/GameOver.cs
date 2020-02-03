using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public GameObject deactivateUI;
    public Text scoreText;
    public Text scoreGlassText;
    public Text scorePlasticText;
    public Text scorePaperText;

    void Start()
    {
        gameObject.SetActive(false);
    }
      
    public void ToggleEndMenu(float score, int scoreGlass, int scorePlastic, int scorePaper)
    {
        gameObject.SetActive(true);
        deactivateUI.SetActive(false);
        Time.timeScale = 0f;
        scoreText.text = "Time: " + ((int)score).ToString();
        scoreGlassText.text = ((int)scoreGlass).ToString();
        scorePlasticText.text = ((int)scorePlastic).ToString();
        scorePaperText.text = ((int)scorePaper).ToString();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Runner");

    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
