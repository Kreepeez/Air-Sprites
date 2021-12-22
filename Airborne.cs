using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airborne : MonoBehaviour
{
    public Animator animator;
    public CharacterController2D controller;
    public AnimatorClipInfo[] animatorClipInfo;
    
    public List<Sprite> spriteList;
    public SpriteRenderer spriteRenderer;
    public float airIndex;
    
    public PlayerCombat combat;

    PlayerMovement playerMovement;


    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }


    public void GetAirSprite()
    {

        airIndex = Mathf.Clamp(Helper.Map(controller.velY, controller.jumpForce, -controller.jumpForce, 0f,
           0.99f), 0, 0.99f);

        if(playerMovement.longJump && playerMovement.horizontalMove != 0)
        {
            
            if (airIndex > 1f)
            {
                airIndex = 1;
                animator.Play("Player_jump", 0, 0.99f);
            }
            else
                animator.Play("Player_jump", 0, airIndex);
        }else
        {
            if (airIndex > 1f)
            {
                airIndex = 1;
                animator.Play("Player_idlejump", 0, 0.99f);
            }
            else
                animator.Play("Player_idlejump", 0, airIndex);
        }
    }


    private void Update()
    {

        if (!controller.isGrounded)
        {
            animator.speed = 0f;
            GetAirSprite();
        }
        else {
            animator.speed = 1f;
        }        
    }
}
