using System;
using UnityEngine;

[System.Serializable]
public class TimerSystem : FeatureSystem
{   
    private float _fTimer;
    [SerializeField] private float _fTimerDurationInSeconds;
    public Action<float> aOnTimerChange;
    

    public override void Inanziate()
    {

    }

    public override void ExecuteUpdate()
    {
        if (_fTimer >= _fTimerDurationInSeconds)
        {
            aOnFinishedExecute?.Invoke();
            return;
        }


        _fTimer += Time.deltaTime;
        aOnTimerChange?.Invoke(_fTimer);
    }

    public override void Reset()
    {
        _fTimer = 0;
        aOnFinishedExecute = null;
    }
}
