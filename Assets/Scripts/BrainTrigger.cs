using UnityEngine;
using System.Collections;

public class BrainTrigger : MonoBehaviour {

	public PlayerController gangControl;
	public Camera mainCamera;

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "BrainCell") 
		{
			mainCamera.orthographicSize = 8.0f;
			other.gameObject.transform.parent.gameObject.SetActive(false);
			gangControl.brainToMain = true;
		}
	}
}
