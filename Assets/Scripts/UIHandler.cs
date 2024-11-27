using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject _gWinScreen;
    [SerializeField] private GameObject _gLoseScreen;
    [SerializeField] private TMP_Text _tPoints;
    [SerializeField] private TMP_Text _tTimer;

    [SerializeField] private LevelSO _xLevelData;

    private void Start()
    {

        ButtonsData.xPumpButton.AddCommand(new UpdatePoints(_tPoints));
    }

    public void ObjectOnOff(GameObject objectToChange)
    {
        if(objectToChange.activeInHierarchy)
            objectToChange.SetActive(false);
        else 
            objectToChange.SetActive(true);
    }

    /// <summary>
    /// activates the right end screen
    /// </summary>
    /// <param name="isWin">true if you won</param>
    public void LevelEnd(bool isWin)
    {
        _gWinScreen.SetActive(isWin);
        _gLoseScreen.SetActive(!isWin);
    }

    public void UpdateTimer(float timer) 
    {
        _tTimer.text = timer.ToString("F1");
    }
}
