using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] LevelSO _xLevelData;
    UIHandler _xUI;

    private void Start()
    {
        _xUI = FindObjectOfType<UIHandler>();

        if (_xLevelData.xPointsHandler.isActive)
        {
            if (_xLevelData.xtimerSystem.isActive)
            {
                _xLevelData.xtimerSystem.aOnFinishedExecute += LevelLost;
                _xLevelData.xtimerSystem.aOnTimerChange += _xUI.UpdateTimer;
            }
            _xLevelData.xPointsHandler.aOnFinishedExecute += LevelWon;
        }
        else if (_xLevelData.xtimerSystem.isActive)
        {
            _xLevelData.xtimerSystem.aOnFinishedExecute += LevelWon;
            _xLevelData.xtimerSystem.aOnTimerChange += _xUI.UpdateTimer;

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
        _xUI.LevelEnd(true);
    }
    public void LevelLost()
    {
        _xUI.LevelEnd(false);
    }
}


