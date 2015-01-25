using UnityEngine;
using System.Collections;

public class LightEnemyAI : MonoBehaviour {
	//enemy variables
	private Vector3 enemyPosition;
	public float enemyVelocity = 3.0f;
	public float attackRange = 1.0f;
	public float distanceBtwnPlayerAndEnemyOnX;
	public float distanceBtwnPlayerAndEnemyOnY;
	public float giveUpHeight = 4.0f; // y distance to chanege enemy state to wait state 
	public float giveUpDistance = 4.0f; // x distance to chanege enemy state to wait state
	public bool onGround;
	public bool canAttack;

	//accessing  variables
	private GameObject player;

	//other objs' variables
	private float playerDir = 1.0f;

	// physics and rays
	private Ray2D ray;
	private RaycastHit2D hit;

	//debug variables
	public bool AiOn = false;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	
	}

	void Update () 
	{
		distanceBtwnPlayerAndEnemyOnX = Mathf.Abs(transform.position.x - player.transform.position.x);
		distanceBtwnPlayerAndEnemyOnY = Mathf.Abs(transform.position.y - player.transform.position.y);

		//Debug.Log (distanceBtwnPlayerAndEnemyOnY);
		enemyPosition = transform.position;

		// get player direction
		if( player.transform.position.x > rigidbody2D.transform.position.x)
		{
			playerDir = 1;
		}
		else
		{
			playerDir = -1;
		}

		//detection of simple obstacles and player with ray
		ray = new Ray2D (transform.position, Vector3.right * playerDir);
		Debug.DrawRay (ray.origin, ray.direction);
		if (Physics2D.Raycast (ray.origin, ray.direction,1.50f)) 
		{
			hit = Physics2D.Raycast (ray.origin, ray.direction,1.50f);
			if(hit.collider.gameObject.tag == ("Block"))
			{
				return;
			}
		}


	}
	void FixedUpdate()
	{
		if (AiOn) 
		{
			if( giveUpHeight > distanceBtwnPlayerAndEnemyOnY && giveUpDistance > distanceBtwnPlayerAndEnemyOnX)
			{
				rigidbody2D.velocity = new Vector2 (enemyVelocity * playerDir, rigidbody2D.velocity.y );// enemy move
			}
		}
	}

	
	// check if enemy collides with ground
	void OnCollisionStay2D (Collision2D collider)
	{
		if (collider.gameObject.tag == "Ground") 
		{
			onGround = true;
			canAttack = true;
		}
	}
	void OnCollisionExit2D (Collision2D collider)
	{
		if (collider.gameObject.tag == "Ground") 
		{
			onGround = false;
			canAttack =false;
		}
	}
}
