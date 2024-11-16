using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator aAnimator;
    InputHandler _xPumpInput;
    Inputs _xInputs;

    private void Start()
    {
        _xInputs = new();
        _xPumpInput = new(_xInputs);
        _xPumpInput.AddCommand(new PumpCommand(this));
        //_xPumpInput.AddCommand(new AddPointCommand());
    }
}
