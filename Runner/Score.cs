using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0.0f;
    private int scoreGlass = 0;
    private int scorePlastic = 0;
    private int scorePaper = 0;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 8;
    private int scoreToNextLevel = 10;

    private bool isDead = false;

    public Text scoreText;
    public Text scoreGlassText;
    public Text scorePlasticText;
    public Text scorePaperText;

    public GameOver gameOver;
    public CameraFollow cameraFollow;

    void Update()
    {
        if (isDead)
            return;

        if (score >= scoreToNextLevel)
            LevelUp();

        score += Time.deltaTime;
        scoreText.text = "Time: " + ((int)score).ToString();
        scoreGlassText.text =   ((int)scoreGlass).ToString();
        scorePlasticText.text = ((int)scorePlastic).ToString();
        scorePaperText.text =   ((int)scorePaper).ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Glass")
        {
            scoreGlass++;            
            Destroy(other.gameObject);
            FindObjectOfType<SoundManager>().Play("CollectSound");
        }

        if (other.gameObject.tag == "Paper")
        {
            scorePaper++;            
            Destroy(other.gameObject);
            FindObjectOfType<SoundManager>().Play("CollectSound");
        }

        if (other.gameObject.tag == "Plastic")
        {
            scorePlastic++;
            Destroy(other.gameObject);
            FindObjectOfType<SoundManager>().Play("CollectSound");
        }
    }

    void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return;

        scoreToNextLevel *= 2;
        difficultyLevel++;

        GetComponent<PlayerMotion>().SetSpeed(difficultyLevel);
        cameraFollow.camSpeed();
    }
    
    public void OnDeath()
    {
        isDead = true;

        if((PlayerPrefs.GetFloat("HighScore") < score) &&
            (PlayerPrefs.GetFloat("GlassScore") < scoreGlass) &&
             (PlayerPrefs.GetFloat("PlasticScore") < scorePlastic) &&
                (PlayerPrefs.GetFloat("PaperScore") < scorePaper))
        {
            PlayerPrefs.SetFloat("HighScore", score);
            PlayerPrefs.SetFloat("GlassScore", scoreGlass);
            PlayerPrefs.SetFloat("PlasticScore", scorePlastic);
            PlayerPrefs.SetFloat("PaperScore", scorePaper);
        }
        gameOver.ToggleEndMenu(score, scoreGlass, scorePlastic, scorePaper);
    }
}
