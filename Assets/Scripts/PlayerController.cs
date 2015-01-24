﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//movement variables
	public float moveSpeed = 5;
	private bool onRight = true;
	//bool
	public bool canJump;
	private bool Jump;
	public bool onGround;
	//dynamic parameters
	//public float speed = 5.0f;
	public float jumpForce = 500.0f;
	//components
	public Transform groundCheck;
	public LayerMask groundLayer;
	//pill effects//**********//
	//JumpAndSmack//
	public bool canSmack = false;
	public float smackForce = -300.0f;
	public float smackTime = 0.1f;
	public bool smackOn = false;

	//SuperSpeedAndDissolveEnemy//
	public float superSpeed = 0.0f;
	public bool superSpeedBoost = false;
	//ShootEmUP
	//pill and Zoom
	public bool zoomCheck = false;
	public Camera camera;
	//*****//

	//Components
	public GameObject smackArea;


	void Start () 
	{

		//renderer = GetComponent<MeshRenderer>();
	}
	void Update () 
	{
		if (zoomCheck == true && camera.orthographicSize > 2)
			//onYourFunction();
			camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, camera.orthographicSize - 3, Time.deltaTime);
		if (Input.GetKeyDown (KeyCode.W)) 
		{
			canJump = true;

		}
		if (Input.GetKeyDown (KeyCode.Space) )
		{
			canSmack = true;
		
			
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			superSpeedBoost = true;
			superSpeed = 3.0f;
		} else if (Input.GetKeyUp (KeyCode.D)) 
		{
			superSpeedBoost = false;
			superSpeed = 0.0f;
		}
	}
	void FixedUpdate()
	{
		onGround = Physics2D.OverlapCircle(groundCheck.position, 0.20f, groundLayer);
		//walkinggg
		float move = Input.GetAxis("Horizontal");
		rigidbody2D.velocity = new Vector2(move * moveSpeed, rigidbody2D.velocity.y);
		if (move > 0 && (!onRight ))
			Flip();
		else if (move < 0 && onRight)
			Flip();

		//---------------------//
		//rigidbody2D.velocity = new Vector2 (speed + superSpeed, rigidbody2D.velocity.y);

		Jump = (canJump && onGround);
		if(Jump)
		{
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
			canJump = false;
		}

		//JumpAndSmack//
		if (canSmack && !onGround)
		{
			rigidbody2D.AddForce(new Vector2(0,smackForce));
			smackOn = true;
				//canSmack = false;
		}
		if(canSmack && onGround)
		{
			if (smackOn)
			{

				Camera.main.GetComponent<PerlinShake>().PlayShake();
				smackArea.gameObject.SetActive (true);
			}
		}
		if (onGround) 
		{
			canSmack = false;
			smackOn = false;
			StartCoroutine(SmackOff());

		}
		//Debug.Log (rigidbody2D.velocity.x);
	}
	void Flip()
	{
		onRight = !onRight;
		Vector3 characterScale  = transform.localScale;
		characterScale.x *= -1;
		transform.localScale = characterScale;
	}
	public IEnumerator SmackOff()
	{
		yield return new WaitForSeconds(1.0f);
		smackArea.gameObject.SetActive (false);
		//smackOn = false;
	}
	void OnCollisionEnter2D(Collision2D obj)
	{
		if (obj.gameObject.tag == "Pill") 
		{
			Debug.Log("aha deydi");
			zoomCheck = true;
		}
	}

}
