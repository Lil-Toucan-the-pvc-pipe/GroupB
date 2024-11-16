using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler
{
    private Inputs _xPInputs;
    Action _aPressAction;
    public InputHandler(Inputs pInputs)
    {
        this._xPInputs = pInputs;
        pInputs.Enable();
        pInputs.InGame.PUMP.started += Pressed;
    }

    public void AddCommand(Command command)
    {
        _aPressAction += command.Execute;
    }

    private void Pressed(InputAction.CallbackContext context)
    {
        _aPressAction.Invoke();
    }
}
