using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	//static variables
	public static int Mana = 50;
	public static int Health = 100;
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
	public bool zoomCheck;
	public Camera camera;
	//*****//

	//Components
	public GameObject smackArea;
    public GameObject brainScene;
    public GameObject mainScene;
	//Animation
	private Animator anim;
	public GameObject brainZoom;

	void Start () 
	{
		//renderer = GetComponent<MeshRenderer>();
        brainScene = GameObject.FindGameObjectWithTag("BrainScene");
        brainScene.SetActive(false);
        mainScene = GameObject.FindGameObjectWithTag("MainScene");
		anim = GetComponent<Animator> ();
		brainZoom = GameObject.FindGameObjectWithTag("BrainZoom");
		brainZoom.SetActive(false);
	}
	void Update () 
	{
		
		if (zoomCheck == true && camera.orthographicSize > 0)
		{
			camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, camera.orthographicSize - 5, Time.deltaTime);
			brainZoom.SetActive(true);
			brainZoom.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, 10);
		}
		
		if (zoomCheck == true && camera.orthographicSize <= 0)
		{
			camera.GetComponent<AudioListener>().enabled = false;
			brainScene.SetActive(true);
			mainScene.SetActive(false);
			brainZoom.SetActive(false);
		}
		
		if (Input.GetKeyDown (KeyCode.W)) 
		{
			canJump = true;

		}
		if (Input.GetKeyDown (KeyCode.Space) )
		{
			canSmack = true;
		
			
		}
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.A)) 
		{
				if(Input.GetKey(KeyCode.RightShift))
			   	{
					superSpeedBoost = true;
					superSpeed = 7.0f;
				} 
				else if (Input.GetKeyUp (KeyCode.RightShift)) 
				{
					superSpeedBoost = false;
					superSpeed = 0.0f;
				}
			}
	}
	void FixedUpdate()
	{
		onGround = Physics2D.OverlapCircle(groundCheck.position, 0.20f, groundLayer);
		//anim ground == onground olcak*************************************************************
		//walkinggg
		float move = Input.GetAxis("Horizontal");
		anim.SetFloat("speed", Mathf.Abs(move));
		rigidbody2D.velocity = new Vector2(move * (moveSpeed + superSpeed), rigidbody2D.velocity.y);
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
				//anim smack gelcek*****************************************************
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
			//Debug.Log("aha deydi");
			zoomCheck = true;
		}
	}

}
