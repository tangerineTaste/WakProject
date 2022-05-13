using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonkeyKongController : CharacterController
{
    void OnEnable()
    {
        gameObject.name = "DonkeyKong";

        Attack1 += Punch;
    }
    void OnDisable()
    {
        Attack1 -= Punch;
    }
    void Punch(){
        animator.Play("DonkeyKong_Punch");
    }
}
