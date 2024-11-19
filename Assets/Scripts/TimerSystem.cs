using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TimerSystem : Command
{   
    private float _fTimer;
    [SerializeField] private float _fTimerDuration;
    [HideInInspector] public Action aTimerFinished;
    public bool isActive;

    public override void Execute()
    {
        if (_fTimer >= _fTimerDuration)
        {
            aTimerFinished?.Invoke();
            return;
        }
       
        _fTimer += Time.deltaTime;
    }
}
