﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
namespace environmentQuiz.Scoreboards
{*/
    public class ScoreboardEntryUI : MonoBehaviour
    {
        [SerializeField]
        private Text entryNameText = null;
        [SerializeField]
        private Text entryScoreText = null;

        public void Initialise(ScoreboardEntryData scoreboardEntryData)
        {
            entryNameText.text = scoreboardEntryData.entryName;
            entryScoreText.text = scoreboardEntryData.entryScore.ToString();
        }
    }/*
}
*/