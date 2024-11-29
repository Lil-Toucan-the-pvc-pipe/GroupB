using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
	[SerializeField] LevelSO _xLevelData;
	UIHandler _xUI;
	private bool _bIsLevelOver = false;
	private int _iDifficultyIndex;

	private DelaySystem _xDelaySystem => _xLevelData._Systems[_iDifficultyIndex].xDelaySystem;
	private TimerSystem _xTimerSystem => _xLevelData._Systems[_iDifficultyIndex].xTimerSystem;
	private PointsSystem _xPointsSystem => _xLevelData._Systems[_iDifficultyIndex].xPointsSystem;


	private void Start()
	{
		_xUI = FindObjectOfType<UIHandler>();
		_xUI.xLevelData = _xLevelData;
		DifficultySelection();

		SystemsInizialization();
		_bIsLevelOver = false;

	}

	private void Update()
	{
		if (_bIsLevelOver)
			return;
		_xPointsSystem?.ExecuteUpdate();
		_xTimerSystem?.ExecuteUpdate();
		_xDelaySystem?.ExecuteUpdate();
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
		InputHandler.ChangeInputMode(InputHandler.INPUT_MODES.MEN�);
		_bIsLevelOver = true;
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

	private void DifficultySelection()
	{
		_iDifficultyIndex = 0;
	}
}


