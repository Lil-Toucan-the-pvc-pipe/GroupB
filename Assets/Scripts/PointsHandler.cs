using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PointsHandler : Command
{
    [SerializeField] private int _iPointsToGet = 1;
    [SerializeField] private int _iPointsPerPress = 1;
    [HideInInspector] public Action aGoalReached;
    public bool isActive;

    // start => InputData.PumpButton.AddCommand(AddPoints)

    public void Inizialize()
    {
        ButtonsData.xPumpButton.AddCommand(new AddPointCommand(_iPointsPerPress));
    }

    public override void Execute()
    {
        if (PointsData.iPoints == _iPointsToGet)
        {
            PointsData.ResetPoints();
            aGoalReached?.Invoke();
            return;
        }
    }

}
