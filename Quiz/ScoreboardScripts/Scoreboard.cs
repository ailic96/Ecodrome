using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

    public class Scoreboard : MonoBehaviour
    {
        QuizScore quizScore;

        [SerializeField]
        private int maxScoreboardEntries = 5;
        [SerializeField]
        private Transform highscoresHolderTransform = null;
        [SerializeField]
        private GameObject scoreboardEntryObject = null;

    ScoreboardEntryData entryData = new ScoreboardEntryData(QuizScore.scoreName, QuizScore.score);

    private string SavePath => $"{Application.persistentDataPath}/highscores.json";     //%appdata%   Users/name/AppData/LocalLow/DefaultCompany/Temp

        private void Start()
        {
        ScoreboardSaveData savedScores = GetSavedScores();
        UpdateUI(savedScores);
        SaveScores(savedScores);
        }

    
    [ContextMenu("Add text entires")]
    public void AddNewEntry()
        {
        AddEntry(entryData = new ScoreboardEntryData(QuizScore.scoreName, QuizScore.score));
        }

    public void AddEntry(ScoreboardEntryData scoreboardEntryData)
        {
            ScoreboardSaveData savedScores = GetSavedScores();
            bool scoreAdded = false;

            for(int i=0; i < savedScores.highscores.Count; i++)
            {
                if(scoreboardEntryData.entryScore > savedScores.highscores[i].entryScore)
                {
                    savedScores.highscores.Insert(i, scoreboardEntryData);
                    scoreAdded = true;
                    break;
                }
            }

            if(!scoreAdded && savedScores.highscores.Count < maxScoreboardEntries)
            {
                savedScores.highscores.Add(scoreboardEntryData);
            }

            if(savedScores.highscores.Count > maxScoreboardEntries)
            {
                savedScores.highscores.RemoveRange(maxScoreboardEntries, 
                    savedScores.highscores.Count - maxScoreboardEntries);
            }
            UpdateUI(savedScores);
            SaveScores(savedScores);            
        }

        private void UpdateUI(ScoreboardSaveData savedScores)
        {
            foreach (Transform child in highscoresHolderTransform)
            {
                Destroy(child.gameObject);
            }

            foreach (ScoreboardEntryData highscore in savedScores.highscores)
            {
                Instantiate(scoreboardEntryObject, highscoresHolderTransform).
                GetComponent<ScoreboardEntryUI>().Initialise(highscore);
            }
        }

        private ScoreboardSaveData GetSavedScores()
        {
            if (!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new ScoreboardSaveData();
            }

            using (StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();

                return JsonUtility.FromJson<ScoreboardSaveData>(json);
            }
        }

        private void SaveScores(ScoreboardSaveData scoreboardSaveData)
        {
            using(StreamWriter stream = new StreamWriter(SavePath))
            {
                string json = JsonUtility.ToJson(scoreboardSaveData, true);

                stream.Write(json);
            }
        }
    }