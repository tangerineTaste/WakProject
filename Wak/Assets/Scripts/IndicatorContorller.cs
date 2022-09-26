using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class IndicatorContorller : MonoBehaviour
{
    [SerializeField]
    Button indicator;

    [SerializeField]
    Canvas canvas;

    public Action<bool> IndicatorWarClicked;
    bool isGrabbed;

    void HandleIndicatorClicked(){
        isGrabbed =! isGrabbed;
        IndicatorWarClicked?.Invoke(isGrabbed);
    }
    void OnEnable()
    {
        indicator.onClick.AddListener(HandleIndicatorClicked);
    }
    void OnDisable()
    {
        indicator.onClick.RemoveListener(HandleIndicatorClicked);
    }
    void Update()
    {
        if(isGrabbed){
            Vector2 pos;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out pos);
            transform.position = canvas.transform.TransformPoint(pos);
        }
    }
}
