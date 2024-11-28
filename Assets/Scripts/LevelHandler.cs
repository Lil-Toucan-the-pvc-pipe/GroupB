using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] LevelSO _xLevelData;
    UIHandler _xUI;
    private bool _bIsLevelOver = false;

    private void Start()
    {
        _xUI = FindObjectOfType<UIHandler>();

        _xLevelData.xDelaySystem.aOnFinishedExecute += LevelLost;
        _xLevelData.xDelaySystem.xOnDelayTimerChanged += _xUI.UpdateDelay;
        if (_xLevelData.xPointsHandler.isActive)
        {
            if (_xLevelData.xTimerSystem.isActive)
            {
                _xLevelData.xTimerSystem.aOnFinishedExecute += LevelLost;
                _xLevelData.xTimerSystem.aOnTimerChange += _xUI.UpdateTimer;
            }
            _xLevelData.xPointsHandler.aOnFinishedExecute += LevelWon;
        }
        else if (_xLevelData.xTimerSystem.isActive)
        {
            _xLevelData.xTimerSystem.aOnFinishedExecute += LevelWon;
            _xLevelData.xTimerSystem.aOnTimerChange += _xUI.UpdateTimer;

        }
        _xLevelData.xPointsHandler.Inanziate();
        _xLevelData.xTimerSystem.Inanziate();
        _xLevelData.xDelaySystem.Inanziate();
        _bIsLevelOver = false;

    }

    private void Update()
    {
        if (_bIsLevelOver)
            return;
        _xLevelData.xPointsHandler?.ExecuteUpdate();
        _xLevelData.xTimerSystem?.ExecuteUpdate();
        _xLevelData.xDelaySystem?.ExecuteUpdate();
    }

    public void LevelWon()
    {
        _xUI.LevelEnd(true);
        ResetLevel();
    }
    public void LevelLost()
    {
        _xUI.LevelEnd(false);
        ResetLevel();
    }

    void ResetLevel()
    {
        InputHandler.ChangeInputMode(InputHandler.INPUT_MODES.MENÙ);
        _bIsLevelOver = true;
        _xLevelData.xPointsHandler?.Reset();
        _xLevelData.xTimerSystem?.Reset();
    }
}


