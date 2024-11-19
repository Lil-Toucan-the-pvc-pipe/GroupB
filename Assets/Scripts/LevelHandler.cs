using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] TimerSystem _xtimerSystem;
    [SerializeField] PointsHandler _xPointsHandler;
    private void Start()
    {
        // ask tutor for help to find a better way 
        if (_xPointsHandler.isActive)
        {
            if (_xtimerSystem.isActive)
            {
                _xtimerSystem.aTimerFinished += LevelLost;
            }
            _xPointsHandler.aGoalReached += LevelWon;
        }
        else if(_xtimerSystem.isActive)
        {
            _xtimerSystem.aTimerFinished += LevelWon;
        }

        _xPointsHandler.Inizialize();
    }

    private void Update()
    {
        _xPointsHandler?.Execute();
        _xtimerSystem?.Execute();
    }

    public void LevelWon()
    {

    }
    public void LevelLost()
    {

    }
}


