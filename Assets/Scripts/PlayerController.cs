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
	//*****//

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
	}
	void FixedUpdate()
	{
		onGround = Physics2D.OverlapCircle(groundCheck.position, 0.20f, groundLayer);
		rigidbody2D.velocity = new Vector2 (speed, rigidbody2D.velocity.y);

		Jump = (canJump && onGround);
		if(Jump)
		{
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
			canJump = false;
		}

	}

}
