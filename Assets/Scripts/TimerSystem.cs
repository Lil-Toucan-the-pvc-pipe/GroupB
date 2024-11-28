using System;
using UnityEngine;

[System.Serializable]
public class TimerSystem : FeatureSystem
{   
    private float _fTimer = 0;
    [SerializeField,Tooltip("check if the timer is used to end the game")] bool _bIsItTimer;
    [SerializeField] private float _fTimerDurationInSeconds;
    public Action<float> aOnTimerChange;
    private int _iDeltaTimeMultiplyer;

    public override void Inanziate()
    {
        if (_bIsItTimer)
        {
            _fTimer = _fTimerDurationInSeconds;
            _iDeltaTimeMultiplyer = -1;
            return;
        }
        _fTimer = 0.01f;
        _iDeltaTimeMultiplyer = 1;
    }

    public override void ExecuteUpdate()
    {
        if (_fTimer <= 0)
        {
            aOnFinishedExecute?.Invoke();
            return;
        }
        _fTimer += Time.deltaTime* _iDeltaTimeMultiplyer;
        aOnTimerChange?.Invoke(_fTimer);
    }

    public override void Reset()
    {
        _fTimer = 0;
        aOnFinishedExecute = null;
        aOnTimerChange = null;
    }
}
