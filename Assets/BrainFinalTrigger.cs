using UnityEngine;
using System.Collections;

public class BrainFinalTrigger : MonoBehaviour {

    public PlayerController playerController;

    public Camera mainCamera;

    //public GameObject mainScene;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BrainCell")
        {
            mainCamera.orthographicSize = 8.0f;
            other.gameObject.transform.parent.gameObject.SetActive(false);
            playerController.brainToMain = true;
        }
    }
}
