using System;
using UnityEngine;

public class FeatureSystem
{
    public bool isActive;
    [HideInInspector] public Action aOnFinishedExecute;

    public virtual void Inanziate()
    {

    }

    public virtual void ExecuteUpdate()
    {

    }

    public virtual void Reset()
    {

    }
}
