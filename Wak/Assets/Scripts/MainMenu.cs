using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Button startGameButton;

    [SerializeField]
    Button settingsButton;

    [SerializeField]
    Button controlsButton;
    GameObject loadingScreen;
    LoadingScreenController loadingScreenComponent;

    void HandleStartGameButtonClicked(){
        SceneManager.LoadSceneAsync("SelectCharacter");
    }
    void HandleSettingsButtonClicked(){
        SceneManager.LoadSceneAsync("Settings");
    }
    void HandleControlsButtonClicked(){
        SceneManager.LoadSceneAsync("Controls");
    }
    
    void OnEnable()
    {
        startGameButton.onClick.AddListener(HandleStartGameButtonClicked);
        settingsButton.onClick.AddListener(HandleSettingsButtonClicked);
        controlsButton.onClick.AddListener(HandleControlsButtonClicked);
        loadingScreen = GameObject.Find("LoadingCanvas");

        if(loadingScreen != null){
            loadingScreenComponent = loadingScreen.GetComponent<LoadingScreenController>();
        }
        if(loadingScreenComponent != null){
            loadingScreenComponent.HideSpinner();
        }
    }
    void OnDisable(){
        startGameButton.onClick.RemoveListener(HandleStartGameButtonClicked);
        settingsButton.onClick.RemoveListener(HandleSettingsButtonClicked);
        controlsButton.onClick.RemoveListener(HandleControlsButtonClicked);
    }
}
