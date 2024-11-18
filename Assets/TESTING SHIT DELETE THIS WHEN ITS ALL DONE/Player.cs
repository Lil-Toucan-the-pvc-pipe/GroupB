using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Animator aAnimator;
    Controls _xPumpInput;
    Inputs _xInputs;

    private void Start()
    {
        _xInputs = new();
        _xInputs.InGame.Enable();
        InputActionReference inputActionReference = new();
        inputActionReference.Set(_xInputs.InGame.PUMP);
        _xPumpInput = new(inputActionReference);
        _xPumpInput.AddCommand(new PumpCommand(this));
        //_xPumpInput.AddCommand(new AddPointCommand());
    }
}
