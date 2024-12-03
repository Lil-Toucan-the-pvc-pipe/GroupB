using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LeveL", menuName = "Assets/LevelSO")]
public class LevelSO : ScriptableObject
{
	[SerializeField] public Systems[] xSystems;

	public void Reset()
	{
		foreach (var system in xSystems) 
		{
            system.xTimerSystem.Reset();
            system.xPointsSystem.Reset();
            system.xDelaySystem.Reset();
        }
	}
}

[System.Serializable]
public class Systems
{
	[SerializeField] public TimerSystem xTimerSystem;
	[SerializeField] public PointsSystem xPointsSystem;
	[SerializeField] public DelaySystem xDelaySystem;
}
