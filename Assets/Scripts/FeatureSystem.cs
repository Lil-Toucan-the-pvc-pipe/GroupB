using System;
using UnityEngine;

public class FeatureSystem
{
    public bool isActive;
    [HideInInspector] public Action aFinishedExecute;
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
