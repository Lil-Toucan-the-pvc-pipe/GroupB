using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Animator _aAnimator;
    [SerializeField] SFXAudioClip[] _xPumpAudioClip;

    private void Start()
    {
        _aAnimator = GetComponentInChildren<Animator>();
        ButtonsData.xPumpButton.AddCommand(new PumpCommand(_aAnimator));
        ButtonsData.xPumpButton.AddCommand(new PlayAudioCommand(_xPumpAudioClip));
    }
}


