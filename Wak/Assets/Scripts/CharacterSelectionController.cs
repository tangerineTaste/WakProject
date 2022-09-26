using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectionController : MonoBehaviour
{
    [SerializeField]
    Texture2D cursorImage;

    [SerializeField]
    Texture2D cursorGrabImage;

    [SerializeField]
    Texture2D cursorPointImage;

    [SerializeField]
    IndicatorContorller p1IndicatorController;

    [SerializeField]
    IndicatorContorller p2IndicatorController;

    [SerializeField]
    IndicatorContorller p3IndicatorController;

    [SerializeField]
    IndicatorContorller p4IndicatorController;

    [SerializeField]
    List<CharacterImage> characterImagesList;

    bool isGrabbingP1Indicator;
    bool isGrabbingP2Indicator;
    bool isGrabbingP3Indicator;
    bool isGrabbingP4Indicator;

    [SerializeField]
    Image p1Image;

    [SerializeField]
    Image p2Image;

    [SerializeField]
    Image p3Image;

    [SerializeField]
    Image p4Image;

    [SerializeField]
    Sprite marioSprite;

    [SerializeField]
    Sprite bowserSprite;

    [SerializeField]
    Sprite donkeyKongSprite;

    [SerializeField]
    Sprite iceClimbersSprite;

    [SerializeField]
    Sprite samusSprite;

    [SerializeField]
    Sprite linkSprite;

    [SerializeField]
    Sprite pikachuSprite;
    
    [SerializeField]
    Sprite captainFalconSprite;

    [SerializeField]
    Sprite sonicSprite;

    [SerializeField]
    GameObject scrim;

    [SerializeField]
    Button startGameButton;

    GameState.Character tempCharacter;

    LoadingScreenController loadingScreen;

    bool buttonSet = false;

    void Awake()
    {
        loadingScreen = GameObject.Find("LoadingCanvas").GetComponent<LoadingScreenController>();
        if(loadingScreen != null){
            loadingScreen.HideSpinner();
        }
        Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.Auto);

        p1Image.color = new Color(0,0,0,0);
        p2Image.color = new Color(0,0,0,0);
        p3Image.color = new Color(0,0,0,0); 
        p4Image.color = new Color(0,0,0,0); 
    }
    void OnEnable()
    {
        p1IndicatorController.IndicatorWarClicked += HandleUserClickedIndicatorP1;
        p2IndicatorController.IndicatorWarClicked += HandleUserClickedIndicatorP2;
        p3IndicatorController.IndicatorWarClicked += HandleUserClickedIndicatorP3;
        p4IndicatorController.IndicatorWarClicked += HandleUserClickedIndicatorP4;

        foreach(CharacterImage characterImage in characterImagesList){
            //characterImage.IndicatorOverCharacter += HandleIndicatorOverCharacter;
        }
    }

    void OnDisable()
    {
        p1IndicatorController.IndicatorWarClicked -= HandleUserClickedIndicatorP1;
        p2IndicatorController.IndicatorWarClicked -= HandleUserClickedIndicatorP2;
        p3IndicatorController.IndicatorWarClicked -= HandleUserClickedIndicatorP3;
        p4IndicatorController.IndicatorWarClicked -= HandleUserClickedIndicatorP4;
        foreach(CharacterImage characterImage in characterImagesList){
            //characterImage.IndicatorOverCharacter -= HandleIndicatorOverCharacter;
        }
    }


    void Update(){//모든 플레이어가 준비되면 게임시작 버튼 활성화
        if(p1Image.color.a != 0 && p2Image.color.a != 0 && p3Image.color.a != 0 && p4Image.color.a != 0 
            && !isGrabbingP1Indicator && !isGrabbingP2Indicator && !isGrabbingP3Indicator && !isGrabbingP4Indicator){
                scrim.SetActive(true);
                Cursor.SetCursor(cursorPointImage, Vector2.zero, CursorMode.Auto);
                if(!buttonSet){
                    startGameButton.onClick.AddListener(HandleStartButtonClicked);
                    buttonSet = true;
                }
            }
    }

    void HandleUserClickedIndicatorP1(bool isGrabbed){ //P1토큰 클릭했을 때 활성/비활성화 하기
        HandleUserClickedIndicator(isGrabbed);
        if(isGrabbed){
            isGrabbingP1Indicator = true;
            isGrabbingP2Indicator = false;
            isGrabbingP3Indicator = false;
            isGrabbingP4Indicator = false;
        }
        else{
            isGrabbingP1Indicator = false;
            isGrabbingP2Indicator = false;
            isGrabbingP3Indicator = false;
            isGrabbingP4Indicator = false;
        }
    }
    void HandleUserClickedIndicatorP2(bool isGrabbed){//P2토큰 클릭했을 때 활성/비활성화 하기
        HandleUserClickedIndicator(isGrabbed);
        if(isGrabbed){
            isGrabbingP2Indicator = true;
            isGrabbingP1Indicator = false;
            isGrabbingP3Indicator = false;
            isGrabbingP4Indicator = false;
        }
        else{
            isGrabbingP1Indicator = false;
            isGrabbingP2Indicator = false;
            isGrabbingP3Indicator = false;
            isGrabbingP4Indicator = false;
        }
    }
    void HandleUserClickedIndicatorP3(bool isGrabbed){//P3토큰 클릭했을 때 활성/비활성화 하기
        HandleUserClickedIndicator(isGrabbed);
        if(isGrabbed){
            isGrabbingP3Indicator = true;
            isGrabbingP2Indicator = false;
            isGrabbingP1Indicator = false;
            isGrabbingP4Indicator = false;
        }
        else{
            isGrabbingP1Indicator = false;
            isGrabbingP2Indicator = false;
            isGrabbingP3Indicator = false;
            isGrabbingP4Indicator = false;
        }
    }
    void HandleUserClickedIndicatorP4(bool isGrabbed){//P4토큰 클릭했을 때 활성/비활성화 하기
        HandleUserClickedIndicator(isGrabbed);
        if(isGrabbed){
            isGrabbingP4Indicator = true;
            isGrabbingP2Indicator = false;
            isGrabbingP3Indicator = false;
            isGrabbingP1Indicator = false;
        }
        else{
            isGrabbingP1Indicator = false;
            isGrabbingP2Indicator = false;
            isGrabbingP3Indicator = false;
            isGrabbingP4Indicator = false;
        }
    }

    void HandleUserClickedIndicator(bool isGrabbed){//활성화된 토큰 움직이기
        if(isGrabbed){                        
            Cursor.SetCursor(cursorGrabImage, Vector2.zero , CursorMode.Auto);
        }                                    //Vector2.zero = new Vector(0,0)
        else{
            Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.Auto);
        }
    }

    /*void HandleIndicatorOverCharacter(string name){
        switch(name){
            case "Mario":
                tempCharacter = GameState.Character.Mario;
                break;
            case "DonkeyKong":
                tempCharacter = GameState.Character.DonkeyKong;
                break;
        }
        if(isGrabbingP1Indicator){
            GameState.P1_Character = tempCharacter;
        }
        else if(isGrabbingP2Indicator){
            GameState.P2_Character = tempCharacter;
        }
        else if(isGrabbingP3Indicator){
            GameState.P3_Character = tempCharacter;
        }
        else if(isGrabbingP4Indicator){
            GameState.P4_Character = tempCharacter;
        }
        Debug.Log("충돌확인");
    }*/

    void HandleStartButtonClicked(){
        if(loadingScreen != null){
            loadingScreen.ShowSpinner();
        }
        SceneManager.LoadSceneAsync("SelectStage");
    }
}
