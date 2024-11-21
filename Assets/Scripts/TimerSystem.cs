using System;
using UnityEngine;

[System.Serializable]
public class TimerSystem : FeatureSystem
{   
    private float _fTimer;
    [SerializeField] private float _fTimerDurationInSeconds;
    
    

    public override void Inanziate()
    {

    }

    public override void ExecuteUpdate()
    {
        if (_fTimer >= _fTimerDurationInSeconds)
        {
            aFinishedExecute?.Invoke();
            return;
        }


        _fTimer += Time.deltaTime;
    }

    public override void Reset()
    {
        _fTimer = 0;
        aFinishedExecute = null;
        
    }
}
