using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{

    [SerializeField] LevelSO _xLevelData;

    private void Start()
    {
        // ask tutor for help to find a better way 
        if (_xLevelData.xPointsHandler.isActive)
        {
            if (_xLevelData.xtimerSystem.isActive)
            {
                _xLevelData.xtimerSystem.aTimerFinished += LevelLost;
            }
            _xLevelData.xPointsHandler.aGoalReached += LevelWon;
        }
        else if(_xLevelData.xtimerSystem.isActive)
        {
            _xLevelData.xtimerSystem.aTimerFinished += LevelWon;
        }
        _xLevelData.xPointsHandler.Inanziate();
    }

    private void Update()
    {
        _xLevelData.xPointsHandler?.ExecuteUpdate();
        _xLevelData.xtimerSystem?.ExecuteUpdate();
    }

    public void LevelWon()
    {
        _xLevelData.gWinScreen.SetActive(true);
    }
    public void LevelLost()
    {
        _xLevelData.gLoseScreen.SetActive(true);
    }
}


