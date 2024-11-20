using System;
using UnityEngine;

[System.Serializable]
public class TimerSystem : FeatureSystem
{   
    private float _fTimer;
    [SerializeField] private float _fTimerDuration;
    [HideInInspector] public Action aTimerFinished;
    public bool isActive;

    public override void Inanziate()
    {

    }

    public override void ExecuteUpdate()
    {
        if (_fTimer >= _fTimerDuration)
        {
            aTimerFinished?.Invoke();
            return;
        }


        _fTimer += Time.deltaTime;
    }
}
