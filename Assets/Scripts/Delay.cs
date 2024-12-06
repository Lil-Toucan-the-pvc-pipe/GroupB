using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Delay : Command
{
    public float delay = 3f;
    public Action <GameObject> OnDelayEnd;
    public Action <float> OnTimerChange;
    public GameObject delayPanel;

    
    public override void Execute()
    {
        if(delay <= 0)
        {
            OnDelayEnd?.Invoke(delayPanel);
            return;
        }
        Debug.Log(delay);
        delay -= Time.deltaTime;
        OnTimerChange?.Invoke(delay);
    }

    public void Reset()
    {
        OnDelayEnd -= OnDelayEnd;
        OnTimerChange -= OnTimerChange;
    }
}
