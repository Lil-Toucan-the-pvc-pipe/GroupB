using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuHandler : MonoBehaviour
{
    [System.Serializable]
    public struct SceneToLoad
    {
        [SerializeField] public string _xSceneToLoad;
        [SerializeField] public LoadSceneMode _xLoadMode;

    }

    [SerializeField] private Image _iLoadingBar;
    [SerializeField] private GameObject[] _gMenuComponents;
    [SerializeField] private SceneToLoad[] _xScenesToLoad;


    private List<AsyncOperation> _xLoadedScenes;

    private void Awake()
    {
        _iLoadingBar.gameObject.SetActive(false);
        _xLoadedScenes = new();
    }

    // ExitButton
    public void ExitGame()
    {
        Application.Quit();
    }

    // ExitButton

    // StartButton
    public void StartGame(string sceneToLoad)
    {
        HideMenuItems();
        _iLoadingBar.gameObject.SetActive(true);
        AddScenesToLoad();
       
    }
    private IEnumerator LoadingBar()
    {
        float loadingProgress = 0f;

        for (int i = 0; i < _xLoadedScenes.Count; i++) 
        {
            while (_xLoadedScenes[i].isDone != true)
            {
                loadingProgress += _xLoadedScenes[i].progress;
                _iLoadingBar.fillAmount = loadingProgress/ _xLoadedScenes.Count;
                yield return null;
            }
        }

        
    }
    private void AddScenesToLoad()
    {
        foreach(var scene in _xScenesToLoad)
        {
            _xLoadedScenes.Add(SceneManager.LoadSceneAsync(scene._xSceneToLoad, scene._xLoadMode));
        }
        StartCoroutine(LoadingBar());
    }
    private void HideMenuItems()
    {
        foreach (var item in _gMenuComponents)
        {
            item.SetActive(false);
        }

    }
    // StartButton
}


