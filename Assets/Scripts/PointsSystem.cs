using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[System.Serializable]
public class PointsSystem : FeatureSystem
{
    [SerializeField] private int _iPointsToGet = 1;
    [SerializeField,DefaultValue(1)] private int _iPointsPerPress = 1;


    // start => InputData.PumpButton.AddCommand(AddPoints)

    public override void Inanziate()
    {
        ButtonsData.xPumpButton.AddCommand(new AddPointCommand(_iPointsPerPress));
    }

    public override void ExecuteUpdate()
    {
        if (PointsData.iPoints == _iPointsToGet)
        {
            SaveToLeaderboard("PlayerName", PointsData.iPoints);
            aOnFinishedExecute?.Invoke();
            return;
        }
    }

    public override void Reset()
    {
        PointsData.ResetPoints();
        aOnFinishedExecute = null;
    }
    private void SaveToLeaderboard(string playerName, int points)
    {
        
        int totalEntries = PlayerPrefs.GetInt("Leaderboard_TotalEntries", 0);

        
        //PlayerPrefs.SetString($"Leaderboard_Player_{totalEntries}", playerName);
        PlayerPrefs.SetInt($"Leaderboard_Score_{totalEntries}", points);

        
        PlayerPrefs.SetInt("Leaderboard_TotalEntries", totalEntries + 1);

        
        PlayerPrefs.Save();
    }

    //public void DisplayLeaderboard()
    //{
    //    int totalEntries = PlayerPrefs.GetInt("Leaderboard_TotalEntries", 0);

    //    for (int i = 0; i < totalEntries; i++)
    //    {
    //        string playerName = PlayerPrefs.GetString($"Leaderboard_Player_{i}", "Unknown");
    //        int score = PlayerPrefs.GetInt($"Leaderboard_Score_{i}", 0);

    //        Debug.Log($"Rank {i + 1}: {playerName} - {score} points");
    //    }
    //}
}
