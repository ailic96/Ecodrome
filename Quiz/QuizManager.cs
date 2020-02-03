using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class QuizManager : MonoBehaviour
{
    public QuestionData[] questions;
    private static List<QuestionData> unanwseredQuestions;

    private QuestionData currentQuestion;
    private AnwserData currentAnwsers;
    private Scoreboard scoreboard;

    [SerializeField]
    private Text questionText;
    [SerializeField]
    private Text anwserText1;
    [SerializeField]
    private Text anwserText2;
    [SerializeField]
    private Text anwserText3;
    [SerializeField]
    private Text quizCompleteText;

    public GameObject GameOverPanel;
    public GameObject NamePanel;
    public GameObject CorrectPanel;
    public GameObject replayButton;

    [SerializeField]
    private Text GameOverText;
    [SerializeField]
    private float questionDelay;

    public Button button1;
    public Button button2;
    public Button button3;
    public Color newColor;
    public Color correctColor;

    public bool activeRound = true;
    public bool roundLost = false;
    public bool correctAnwser = false;

    void Start()
    {
        if (unanwseredQuestions == null || unanwseredQuestions.Count == 0)
        {
            unanwseredQuestions = questions.ToList<QuestionData>();
        }
        SetCurrentQuestion();
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unanwseredQuestions.Count);
        currentQuestion = unanwseredQuestions[randomQuestionIndex];

        questionText.text = currentQuestion.question;

        anwserText1.text = currentQuestion.anwser1.anwser;
        anwserText2.text = currentQuestion.anwser2.anwser;
        anwserText3.text = currentQuestion.anwser3.anwser;

        unanwseredQuestions.RemoveAt(randomQuestionIndex);

        if (unanwseredQuestions.Count == 16)
        {
            FreezeButtons();
            activeRound = false;
            roundLost = true;
            GameOverPanel.SetActive(true);

            questionText.text = "Hey there, nice score! You can always come back to try again!";
            anwserText1.text = "";
            anwserText2.text = "";
            anwserText3.text = "";
            quizCompleteText.text = "Round won!";

            NamePanel.SetActive(true);
        }
    }

    IEnumerator TrasitionToNextQuestion()
    {
        unanwseredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(questionDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UserSelectTrue1()
    {
        if (currentQuestion.anwser1.isCorrect)
        {
            button2.GetComponent<Image>().color = newColor;
            button3.GetComponent<Image>().color = newColor;

            RoundWin();
            StartCoroutine(TrasitionToNextQuestion());
        }
        else
        {
            button1.GetComponent<Image>().color = correctColor;

            RoundGameOver();
        }               
    }
    public void UserSelectTrue2()
    {
        if (currentQuestion.anwser2.isCorrect)
        {
            button1.GetComponent<Image>().color = newColor;
            button3.GetComponent<Image>().color = newColor;

            RoundWin();
            StartCoroutine(TrasitionToNextQuestion());
        }
        else
        {
            button2.GetComponent<Image>().color = correctColor;

            RoundGameOver();
        }

    }
    public void UserSelectTrue3()
    {
        if (currentQuestion.anwser3.isCorrect)
        {
            button1.GetComponent<Image>().color = newColor;
            button2.GetComponent<Image>().color = newColor;

            RoundWin();
            StartCoroutine(TrasitionToNextQuestion());
        }
        else
        {
            button3.GetComponent<Image>().color = correctColor;

            RoundGameOver();
        }
    }
    
    public void RoundWin()
    {
        FindObjectOfType<SoundManager>().Play("CorrectAnwser");
        FreezeButtons();

        activeRound = false;
        correctAnwser = true;
        GetComponent<QuizScore>().AddScore();

        CorrectPanel.SetActive(true);
    }

    public void RoundGameOver()
    {
        FindObjectOfType<SoundManager>().Play("FalseAnwser");
        FreezeButtons();

        activeRound = false;
        roundLost = true;

        GameOverPanel.SetActive(true);
        NamePanel.SetActive(true);
    }

    public void FreezeButtons()
    {
        button1.GetComponent<Button>().interactable = false;
        button2.GetComponent<Button>().interactable = false;
        button3.GetComponent<Button>().interactable = false;
    }

    public void ButtonMainMenu()
    {
        unanwseredQuestions = questions.ToList<QuestionData>();
        QuizScore.score = 0;
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonReplay()
    {
        unanwseredQuestions = questions.ToList<QuestionData>();
        QuizScore.score = 0;
        SceneManager.LoadScene("Quiz");
    } 
}
