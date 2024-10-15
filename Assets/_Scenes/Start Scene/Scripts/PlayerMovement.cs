
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

    public Animator animator; 

	public AudioSource jumpSound;
	public AudioSource jumpSound2;
	
	// Update is called once per frame
	void Update () {

        
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator. SetFloat ("Speed", Mathf.Abs(horizontalMove));


		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
            animator.SetBool("Jump", true);
			jumpSound.Play();

		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;


		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}
    public void OnLanding ()
    {
        animator.SetBool("Jump", false);
		jumpSound2.Play();
    }

    public void OnCrouching (bool isCrouching)
    {
        animator.SetBool("Croush", isCrouching);
    }

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}


}
