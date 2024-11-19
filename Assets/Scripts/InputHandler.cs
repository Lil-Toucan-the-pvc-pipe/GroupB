using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private static Inputs _xInputs = new();

    enum INPUT_MODES
    {
        INGAME,
        MEN�
    }

    static INPUT_MODES _xMODES = INPUT_MODES.MEN�;

    private void OnEnable()
    {
        InputActionReference inputActionReference = new();
        inputActionReference.Set(_xInputs.InGame.PUMP);
        ButtonsData.xPumpButton = new(inputActionReference);
    }

    private void OnDisable()
    {
        ButtonsData.xPumpButton = null;
        ButtonsData.xReturnButton = null;
        ButtonsData.xComfirmButton = null;
    }

    /// <summary>
    /// changes between the Ingame and Men� inputs
    /// </summary>
    public static void ChangeInputMode()
    {
        if(_xMODES == INPUT_MODES.INGAME)
        {
            _xInputs.InGame.Disable();
            _xMODES = INPUT_MODES.MEN�;
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
