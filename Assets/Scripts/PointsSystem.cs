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
            aOnFinishedExecute?.Invoke();
            return;
        }
    }

    public override void Reset()
    {
        PointsData.ResetPoints();
        aOnFinishedExecute = null;
    }

}
