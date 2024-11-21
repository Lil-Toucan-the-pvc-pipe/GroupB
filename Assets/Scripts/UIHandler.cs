using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject _gWinScreen;
    [SerializeField] private GameObject _gLoseScreen;

    public void ObjectOnOff(GameObject objectToChange)
    {
        if(objectToChange.activeInHierarchy)
            objectToChange.SetActive(false);
        else 
            objectToChange.SetActive(true);
    }

    public void LevelDone(bool isWin)
    {
        _gWinScreen.SetActive(isWin);
        _gLoseScreen.SetActive(!isWin);
    }
}
