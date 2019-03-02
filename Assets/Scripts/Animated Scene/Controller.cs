using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
	    float speed = 2;
		float rotSpeed = 80;
		float rot = 0f;
		float gravity = 8;
		
		Vector3 moveDir = Vector3.zero;
		CharacterController controller;
		Animator anim;
		
    // Start is called before the first frame update
    void Start()
    {
		controller = GetComponent<CharacterController> ();
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		Walking();
		GetInput();
    }
	
	void GetInput()
	{
		if(controller.isGrounded)
		{
			if(Input.GetKey (KeyCode.Space))
			{
				if(anim.GetBool("walking") == true)
				{
					anim.SetBool("walking", false);
					anim.SetInteger("condition",0);
				}
				if (anim.GetBool ("walking") == false)
				{
					Jump();
				}
			}
            if(Input.GetKey(KeyCode.A))
            {
                turnLeft();
            }
            if (Input.GetKeyUp(KeyCode.A) && anim.GetBool("turnLeft"))
            {
                stopTurningLeft();
            }
            if (Input.GetKey(KeyCode.D))
            {
                turnRight();
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                stopTurningRight();
            }
            if (Input.GetKey(KeyCode.S))
            {
                walkBackwards();
            }
			
		}
	}

    private void turnRight()
    {
        anim.SetBool("turnRight", true);
        anim.SetInteger("condition", 4);
    }

    private void stopTurningRight()
    {
        anim.SetBool("turnRight", false);
        anim.SetInteger("condition", 0);
    }

    private void turnLeft()
    {
        anim.SetBool("turnLeft", true);
        anim.SetInteger("condition", 3);
    }

    private void stopTurningLeft()
    {
        anim.SetBool("turnLeft", false);
        anim.SetInteger("condition", 0);
    }

    void Jump()
	{
		StartCoroutine(JumpRoutine());
	}
	
	IEnumerator JumpRoutine()
	{
		anim.SetBool("jumping", true);
		anim.SetInteger("condition", 2);
		yield return new WaitForSeconds (0.20f);
		anim.SetInteger("condition", 0);
		anim.SetBool("jumping",false);
	}
	
	void Walking()
	{
		if(controller.isGrounded)
		{
			if(Input.GetKey (KeyCode.W))
			{
				if(anim.GetBool("jumping") == true)
				{
					return;
				}
				
				else if (anim.GetBool("jumping") == false)
				{
					anim.SetBool("walking", true);
					anim.SetInteger("condition", 1); //invokes walk animation
					moveDir = new Vector3(0,0,1);
					moveDir *= speed;
					moveDir = transform.TransformDirection(moveDir);
				}
			}
			
			if(Input.GetKeyUp (KeyCode.W))
			{
				anim.SetBool("walking", false);
				anim.SetInteger("condition", 0); // stops walk animation
				moveDir = new Vector3(0,0,0);
			}
		}
		rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
		transform.eulerAngles = new Vector3(0,rot,0);
		moveDir.y -= gravity * Time.deltaTime;
        Debug.Log("MovDir " + moveDir);
		controller.Move(moveDir * Time.deltaTime);
	}

    private void walkBackwards()
    {
        if (anim.GetBool("jumping"))
        {
            return;
        }
        else
        {
            anim.SetBool("walking", true);
            anim.SetInteger("condition", 4);
            moveDir = new Vector3(0, 0, -1);
            moveDir *= speed;
            moveDir = transform.TransformDirection(moveDir);
        }
    }
}
