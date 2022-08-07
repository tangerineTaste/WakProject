using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    protected Animator animator;

    [SerializeField]
    private int speed;

    [SerializeField]
    private int jumpHeight;

    [SerializeField]
    protected Rigidbody rigidbody;

    [SerializeField]
    private AttackController attackController;

    protected bool isFacingLeft = true;

    private bool isJumping = false;

    public Action Move;
    public Action Attack1;
    public Action Attack2;
    public Action Attack3;
    public Action JumpUp;

    private bool isPlayer;

    public bool canIMove = true;

    public virtual void Update()
    {
        isPlayer = gameObject.tag == "Player";
        if(isPlayer && canIMove){
            if(Input.GetKey(KeyCode.LeftArrow)){
                MoveLeft();
            }
            else if(Input.GetKey(KeyCode.RightArrow)){
                MoveRight();
            }
            if(Input.GetKey(KeyCode.UpArrow)){
                Jump();
            }
            if(Input.GetKey(KeyCode.Z)){
                AttackWith1();
            }
            else if(Input.GetKey(KeyCode.X)){
                AttackWith2();
            }
            else if(Input.GetKey(KeyCode.C)){
                AttackWith3();
            }
        
        }
    }
    void MoveLeft(){
        if(!isFacingLeft){
            transform.rotation = Quaternion.Euler(0,0,0);
            isFacingLeft = true;
        }
        transform.position += new Vector3(speed * -1 * Time.deltaTime, 0, 0);
        Move?.Invoke();
    }
    void MoveRight(){
        if(isFacingLeft){
            transform.rotation = Quaternion.Euler(0,180,0);
            isFacingLeft = false;
        }
        transform.position += new Vector3(speed  * Time.deltaTime, 0, 0);
        Move?.Invoke();
    }
    public void Jump(){
        if(!isJumping){
            isJumping = true;
            JumpUp?.Invoke();
            rigidbody.AddForce(new Vector3(0,jumpHeight,0), ForceMode.Impulse);
            StartCoroutine(Jumping());
        }
    }
    IEnumerator Jumping(){
        yield return new WaitForSeconds(1f);
        isJumping = false;
    }

    public void AttackWith1(){
        attackController.isAttacking = true;
        attackController.attackLevel =1;
        Attack1?.Invoke();
    }
    public void AttackWith2(){
        attackController.isAttacking = true;
        attackController.attackLevel =2;
        Attack2?.Invoke();
    }
    public void AttackWith3(){
        attackController.isAttacking = true;
        attackController.attackLevel =3;
        Attack3?.Invoke();
    }
}