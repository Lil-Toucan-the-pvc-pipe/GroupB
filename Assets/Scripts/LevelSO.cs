using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LeveL",menuName = "Assets/LevelSO")]
public class LevelSO : ScriptableObject
{
    [SerializeField] public TimerSystem xTimerSystem;
    [SerializeField] public PointsSystem xPointsHandler;
    [SerializeField] public DelaySystem xDelaySystem;

    public void Reset()
    {
        xTimerSystem.Reset();
        xPointsHandler.Reset();
        xDelaySystem.Reset();
    }
}
