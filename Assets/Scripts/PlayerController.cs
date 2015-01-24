using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//movement variables
	//bool
	public bool canJump;
	private bool Jump;
	public bool onGround;
	//dynamic parameters
	public float speed = 5.0f;
	public float jumpForce = 500.0f;
	//components
	public Transform groundCheck;
	public LayerMask groundLayer;
	//pill effects//**********//
	//JumpAndSmack//
	public bool canSmack = false;
	public float smackForce = -300.0f;
	//SuperSpeedAndDissolveEnemy//
	public float superSpeed = 0.0f;
	public bool superSpeedBoost = false;
	//ShootEmUP

	//*****//

	//Components
	public GameObject smackArea;


	void Start () 
	{

		//renderer = GetComponent<MeshRenderer>();
	}
	void Update () 
	{
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
		rigidbody2D.velocity = new Vector2 (speed + superSpeed, rigidbody2D.velocity.y);

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
			//canSmack = false;
		}
		if(canSmack && onGround)
		{
			smackArea.gameObject.SetActive (true);
		}
		if (onGround) 
		{
			canSmack = false;
		}
		Debug.Log (rigidbody2D.velocity.x);
	}

}
