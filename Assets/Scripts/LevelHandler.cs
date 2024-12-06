using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
	[SerializeField] LevelSO _xLevelData;
	[SerializeField] float delayTime;
	UIHandler _xUI;
	private bool _bIsSystemsBlocked = false;
	private int _iDifficultyIndex;
	private Delay delay;
	private DelaySystem _xDelaySystem => _xLevelData.xSystems[_iDifficultyIndex].xDelaySystem;
	private TimerSystem _xTimerSystem => _xLevelData.xSystems[_iDifficultyIndex].xTimerSystem;
	private PointsSystem _xPointsSystem => _xLevelData.xSystems[_iDifficultyIndex].xPointsSystem;



    private void Start()
    {
		delay = new Delay();
        InputHandler.ChangeInputMode(InputHandler.INPUT_MODES.MENÙ);
        _bIsSystemsBlocked = true;
        _xUI = FindObjectOfType<UIHandler>();
		delay.delay = delayTime;
		delay.OnDelayEnd += ResumeGame;
		delay.OnDelayEnd += _xUI.DeactivateDelayPanel;
		delay.OnTimerChange += _xUI.DelayTimer;
		delay.delayPanel = _xUI._gDelayPanel;
        _iDifficultyIndex = DifficultyManager.CalculateDifficulty(_xLevelData.xSystems.Length);
		_xUI.PointsGoalText.text = _xPointsSystem._iPointsToGet.ToString();
		_xUI.TimerGoalText.text = _xTimerSystem._fTimerDurationInSeconds.ToString();
        SystemsInizialization();
    }

    private void ResumeGame(GameObject @object)
    {
		InputHandler.ChangeInputMode(InputHandler.INPUT_MODES.INGAME);
		_bIsSystemsBlocked = false;
        delay.Reset();
        delay = null;
    }

    private void OnDisable()
    {
		_xDelaySystem.Reset();
		_xTimerSystem.Reset();
		_xPointsSystem.Reset();
		
    }
    private void Update()
	{
		delay?.Execute();
		if (_bIsSystemsBlocked)
			return;
		_xPointsSystem?.ExecuteUpdate();
		_xTimerSystem?.ExecuteUpdate();
		_xDelaySystem?.ExecuteUpdate();
	}

	public void LevelWon()
	{
		DifficultyManager.ChangeDifficulty(0.2f);
		_xUI.LevelEnd(true);
		ResetLevel();
	}
	public void LevelLost()
	{
        DifficultyManager.ChangeDifficulty(-0.2f);
        _xUI.LevelEnd(false);
		ResetLevel();
	}

	void ResetLevel()
	{
		InputHandler.ChangeInputMode(InputHandler.INPUT_MODES.MENÙ);
		_bIsSystemsBlocked = true;
		_xPointsSystem?.Reset();
		_xTimerSystem?.Reset();
	}

	private void SystemsInizialization()
	{
		_xDelaySystem.aOnFinishedExecute += LevelLost;
		_xDelaySystem.xOnDelayTimerChanged += _xUI.UpdateDelay;
		if (_xPointsSystem.isActive)
		{
			if (_xTimerSystem.isActive)
			{
				_xTimerSystem.aOnFinishedExecute += LevelLost;
				_xTimerSystem.aOnTimerChange += _xUI.UpdateTimer;
			}
			_xPointsSystem.aOnFinishedExecute += LevelWon;
		}
		else if (_xTimerSystem.isActive)
		{
			_xTimerSystem.aOnFinishedExecute += LevelWon;
			_xTimerSystem.aOnTimerChange += _xUI.UpdateTimer;
		}
		_xPointsSystem.Inanziate();
		_xTimerSystem.Inanziate();
		_xDelaySystem.Inanziate();
	}

	
}


