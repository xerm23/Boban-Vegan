using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 80f;

	float horizontalMove = 0f;
    bool jump = false;


	public Joystick joystick;


	// Update is called once per frame
	void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		/*
		if (joystick.Horizontal > 0.1f)
			horizontalMove += runSpeed;
		else if (joystick.Horizontal < -0.1f)
			horizontalMove -= runSpeed;
		*/
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			JumpClick();
		}
	}

	public void JumpClick()
    {
		jump = true;
		animator.SetBool("IsJumping", true);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
		animator.SetBool("IsJumping", false);
	}
}
