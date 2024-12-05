using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject _gWinScreen;
    [SerializeField] private GameObject _gLoseScreen;
    [SerializeField] private TMP_Text _tPointsText;
    [SerializeField] private TMP_Text _tTimerText;
    [SerializeField] private Image _sDelaySlider;

    [SerializeField] SceneToLoad[] _xNextLevel;
    [SerializeField] SceneToLoad[] _xCurrentExtraScenese;
    [SerializeField] SceneToLoad[] _xMainMenu;
    private List<AsyncOperation> _xLoadedScenes;
    string currentSceneName;


    private void Start()
    {

        ButtonsData.xPumpButton.AddCommand(new UpdatePoints(_tPointsText));
        currentSceneName = SceneManager.GetActiveScene().name;
        _xLoadedScenes = new();
    }

    public void ObjectOnOff(GameObject objectToChange)
    {
        if (objectToChange.activeInHierarchy)
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

    public void UpdateDelay(float rangeFrom0To1)
    {
        _sDelaySlider.fillAmount = rangeFrom0To1;
    }

    public void RetryLevel()
    {

        _xLoadedScenes.Add(SceneManager.LoadSceneAsync(currentSceneName));

        foreach (var scene in _xCurrentExtraScenese)
        {
            _xLoadedScenes.Add(SceneManager.LoadSceneAsync(scene._xSceneToLoad, scene._xLoadMode));
        }
        StartCoroutine(SceneLoading());
    }

    public void LoadNextLevel()
    {
        foreach (var scene in _xNextLevel)
        {
            _xLoadedScenes.Add(SceneManager.LoadSceneAsync(scene._xSceneToLoad, scene._xLoadMode));
        }
        StartCoroutine(SceneLoading());
    }

    public void LoadMainMenu()
    {
        foreach (var scene in _xMainMenu)
        {
            _xLoadedScenes.Add(SceneManager.LoadSceneAsync(scene._xSceneToLoad, scene._xLoadMode));
        }
        StartCoroutine(SceneLoading());
    }

    private IEnumerator SceneLoading()
    {
        float loadingProgress = 0f;

        for (int i = 0; i < _xLoadedScenes.Count; i++)
        {
            while (_xLoadedScenes[i].isDone != true)
            {
                loadingProgress += _xLoadedScenes[i].progress;

                yield return null;
            }
        }


    }
}
