using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[System.Serializable]
public class ScoreboardEntryData
{
   public string entryName;
   public int entryScore;

   public ScoreboardEntryData(string nameConst, int scoreConst )
   {
       entryName = nameConst;
       entryScore = scoreConst;
   }
}
