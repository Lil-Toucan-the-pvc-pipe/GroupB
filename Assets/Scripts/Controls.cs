using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class Controls
{
    protected InputAction _xPInput;
    Action _aPressAction;

    public Controls(InputAction _xPInput)
    {
        this._xPInput = _xPInput;
        _xPInput.started += Pressed;
    }

    public virtual void AddCommand(Command command)
    {
        _aPressAction += command.Execute;
    }

    protected virtual void Pressed(InputAction.CallbackContext context)
    {
        Debug.Log(_xPInput.enabled);
        _aPressAction?.Invoke();
    }
}