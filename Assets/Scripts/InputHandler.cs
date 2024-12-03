using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private static Inputs _xInputs;

    public enum INPUT_MODES
    {
        INGAME,
        MENÙ
    }

    private void OnEnable()
    {
        _xInputs = new();
        _xInputs.InGame.Enable();

        ButtonsData.xPumpButton = new(_xInputs.InGame.PUMP);
    }

    private void OnDisable()
    {
        ButtonsData.xPumpButton = null;
        ButtonsData.xReturnButton = null;
        ButtonsData.xComfirmButton = null;
    }

    /// <summary>
    /// changes between the Ingame and Menù inputs
    /// </summary>
    public static void ChangeInputMode(INPUT_MODES inputMode)
    {
        if (inputMode == INPUT_MODES.MENÙ)
        {
            _xInputs.InGame.Disable();
            _xInputs.Menu.Enable();
        }
        else
        {
            _xInputs.Menu.Disable();
            _xInputs.InGame.Enable();
        }
    }


}
