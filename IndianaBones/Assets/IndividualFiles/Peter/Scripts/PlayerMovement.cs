﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody rb;
    public Animator anim;
    public float speed;
    public float stamina;
    public float staminaUseRate;

    public int sprintCooldown;
    public float sprintSpeed;

    [HideInInspector]
    public float startSpeed;
    public bool canSprint;
    

    public float jumpForce;
    public float jumpCooldown;
    public bool canJump;
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        startSpeed = speed;
        canSprint = true;
        canJump = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
        Sprint();
        Jump();
	}

    void Move()
    {
        float x = Input.GetAxis("Horizontal");

        transform.Translate(transform.right * -x * speed * Time.deltaTime);

      
        if(x != 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }

    void Sprint()
    {
        if (Input.GetButton("Shift"))
        {
            if (stamina > 0 && canSprint)
            {
                stamina -= staminaUseRate;
                speed += sprintSpeed;
            }
            else if (stamina <= 0 && canSprint)
            {

                if (speed != startSpeed)
                {
                    speed = startSpeed;
                }
                canSprint = false;
                StartCoroutine(SprintCooldown());
            }
        }
        else
        {
            if(speed != startSpeed)
            {
                speed = startSpeed;
            }
            if(stamina < 100)
            {
                stamina += staminaUseRate * Time.deltaTime;
            }
        }
    }

    public IEnumerator SprintCooldown()
    {
        yield return new WaitForSeconds(sprintCooldown);
        canSprint = true;

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && canJump)
        {
            if(rb != null)
            {
                rb.AddRelativeForce(transform.up * jumpForce * Time.deltaTime);
                StartCoroutine(JumpCooldown());
            }
            else
            {
                Debug.LogError("Variable rb (RigidBody) is null, Script: PlayerMovement");
            }
         
        }
    }

    IEnumerator JumpCooldown()
    {
        canJump = false;
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }
}
