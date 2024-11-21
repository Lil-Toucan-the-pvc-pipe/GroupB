using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PointsSystem : FeatureSystem
{
    [SerializeField] private int _iPointsToGet = 1;
    [SerializeField] private int _iPointsPerPress = 1;
    

    // start => InputData.PumpButton.AddCommand(AddPoints)

    public override void Inanziate()
    {
        ButtonsData.xPumpButton.AddCommand(new AddPointCommand(_iPointsPerPress));
    }

    public override void ExecuteUpdate()
    {
        if (PointsData.iPoints == _iPointsToGet)
        {
            PointsData.ResetPoints();
            aFinishedExecute?.Invoke();
            return;
        }
    }

    public override void Reset()
    {
        PointsData.ResetPoints();
        aFinishedExecute = null;
    }

}
