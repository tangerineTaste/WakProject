using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class StageController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public event Action<int> HoveredOverStage;
    public event Action HideStageImages;
    [SerializeField]
    int index;
    LoadingScreenController loadingScreen;

    void Awake()
    {
        loadingScreen = GameObject.Find("LoadingCanvas").GetComponent<LoadingScreenController>();
        if(loadingScreen != null){
            loadingScreen.HideSpinner();
        }
    }
    public void OnPointerEnter(PointerEventData eventData){
        HoveredOverStage?.Invoke(index);
    }

    public void OnPointerExit(PointerEventData eventData){
        HideStageImages?.Invoke();
    }
    public void OnPointerClick(PointerEventData eventData){
        if(index == 0){
            SceneManager.LoadSceneAsync("BowserCastle");
        }
        else if(index == 1){
            SceneManager.LoadSceneAsync("Battlefield");
        }
    }
}
