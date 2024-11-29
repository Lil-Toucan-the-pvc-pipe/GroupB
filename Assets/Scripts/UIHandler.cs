using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject _gWinScreen;
    [SerializeField] private GameObject _gLoseScreen;
    [SerializeField] private TMP_Text _tPointsText;
    [SerializeField] private TMP_Text _tTimerText;
    [SerializeField] private Image _sDelaySlider;
    [SerializeField] public LevelSO xLevelData;

    private void Start()
    {
        ButtonsData.xPumpButton.AddCommand(new UpdatePoints(_tPointsText));
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

    /// <summary>
    /// updates the UI's timer
    /// </summary>
    /// <param name="timer"></param>
    public void UpdateTimer(float timer) 
    {
        _tTimerText.text = timer.ToString("F1");
    }

    public void UpdateDelay( float rangeFrom0To1) 
    {
        _sDelaySlider.fillAmount = rangeFrom0To1;
    }
}
