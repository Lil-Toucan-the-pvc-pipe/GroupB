using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LeveL",menuName = "Assets/LevelSO")]
public class LevelSO : ScriptableObject
{
    [SerializeField] public TimerSystem xtimerSystem;
    [SerializeField] public PointsSystem xPointsHandler;

    public void Reset()
    {
        xtimerSystem.Reset();
        xPointsHandler.Reset();
    }
}
