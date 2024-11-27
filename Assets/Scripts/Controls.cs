using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Controls
{
    protected InputAction _xPInput;
    Action _aPressAction;

    public Controls(InputAction _xPInput)
    {
        this._xPInput = _xPInput;
    }

    public virtual void AddCommand(Command command)
    {
        _aPressAction += command.Execute;
        _xPInput.started += Pressed;
    }

    protected virtual void Pressed(InputAction.CallbackContext context)
    {
        _aPressAction?.Invoke();
    }
}