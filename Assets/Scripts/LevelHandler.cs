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

        // ask tutor for help to find a better way 
        if (_xLevelData.xPointsHandler.isActive)
        {
            if (_xLevelData.xtimerSystem.isActive)
            {
                _xLevelData.xtimerSystem.aFinishedExecute += LevelLost;
            }
            _xLevelData.xPointsHandler.aFinishedExecute += LevelWon;
        }
        else if(_xLevelData.xtimerSystem.isActive)
        {
            _xLevelData.xtimerSystem.aFinishedExecute += LevelWon;
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
        _xUI.LevelDone(true);
    }
    public void LevelLost()
    {
        _xUI.LevelDone(false);
    }
}


