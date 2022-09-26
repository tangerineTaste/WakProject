using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IndicatorOverCharacter : MonoBehaviour
{
    [SerializeField]
    Sprite marioSprite;
    [SerializeField]
    Sprite donkeyKongSprite;
    [SerializeField]
    Image PlayerImage;

    GameState.Character tempCharacter;

    public void OnTriggerStay2D(Collider2D col2D){
        name = gameObject.name.ToString();
        Debug.Log(" 충돌자 이름:" + col2D);
        switch(col2D.gameObject.name){
            case "Mario":
                InputCharacter(GameState.Character.Mario);
                PlayerImage.sprite = marioSprite;
                break;
            case "DonkeyKong":
                InputCharacter(GameState.Character.DonkeyKong);
                PlayerImage.sprite = donkeyKongSprite;
                break;
        }
    }
    void InputCharacter(GameState.Character tempCharacter){
        if(this.gameObject.name == "P1_Indicator"){
            GameState.P1_Character = tempCharacter;
        }
        else if(this.gameObject.name == "P2_Indicator"){
            GameState.P2_Character = tempCharacter;
        }
        else if(this.gameObject.name == "P3_Indicator"){
            GameState.P3_Character = tempCharacter;
        }
        else if(this.gameObject.name == "P4_Indicator"){
            GameState.P4_Character = tempCharacter;
        }
    }
}
