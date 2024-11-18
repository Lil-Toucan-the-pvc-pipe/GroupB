using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputActionRebindingExtensions;

public class InputRebind : MonoBehaviour
{
    [SerializeField] InputActionReference _xInput;
    RebindingOperation _iRebindingOperation = null;

    /// <summary>
    /// changes a given input
    /// </summary>
    public void ChangeKeybind()
    {
        Debug.Log("Changing keybind");
        _xInput.action.Disable();
        _iRebindingOperation = _xInput.action.PerformInteractiveRebinding()
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => KeybindChanged())
            .Start();
        _xInput.action.Enable();

    }

    private void KeybindChanged()
    {
        Debug.Log("Changed keybind!!!!");
        foreach(var bind in _xInput.action.bindings)
        {
            Debug.Log(InputControlPath.ToHumanReadableString(bind.effectivePath));
        }

        _iRebindingOperation.Dispose();
        _iRebindingOperation = null;
        
    }
}
