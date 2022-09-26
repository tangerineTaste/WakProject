using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterImage : MonoBehaviour
{
    public Action<string> IndicatorOverCharacter;
    string name;

    public void OnTriggerStay2D(Collider2D col2D){
        name = gameObject.name.ToString();
        IndicatorOverCharacter?.Invoke(name);
        //Debug.Log("충돌감지 이름:" + name +", 충돌자 이름:" + col2D);
    }
    public void OnTriggerExit2D(Collider2D col2D){
        IndicatorOverCharacter?.Invoke("Reset");
    }
    

}
