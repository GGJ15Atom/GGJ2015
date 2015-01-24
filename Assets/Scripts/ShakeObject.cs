using UnityEngine;
using System.Collections;

public class ShakeObject : MonoBehaviour {


	public PlayerController playerVars;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D obj)
	{
		if (obj.gameObject.tag == "SmackArea") 
		{
			Debug.Log("shake that ass");
			this.rigidbody2D.AddForce(new Vector2(250.0f, 700.0f));
			this.rigidbody2D.AddTorque(50.0f);
			//playerVars.smackArea.SetActive(false);

		}
	}
}
