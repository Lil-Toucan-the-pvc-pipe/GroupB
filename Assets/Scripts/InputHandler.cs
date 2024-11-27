using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private static Inputs _xInputs;

    enum INPUT_MODES
    {
        INGAME,
        MENÙ
    }

    static INPUT_MODES _xMODES = INPUT_MODES.MENÙ;

    private void OnEnable()
    {
        _xInputs = new();
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
    public static void ChangeInputMode()
    {
        if(_xMODES == INPUT_MODES.INGAME)
        {
            _xInputs.InGame.Disable();
            _xMODES = INPUT_MODES.MENÙ;
            _xInputs.Menu.Enable();
        }
        else
        {
            _xInputs.Menu.Disable();
            _xMODES = INPUT_MODES.INGAME;
            _xInputs.InGame.Enable();
        }
    }


}
