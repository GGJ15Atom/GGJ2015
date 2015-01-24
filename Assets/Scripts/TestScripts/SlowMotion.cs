using UnityEngine;
using System.Collections;

public class SlowMotion : MonoBehaviour {


	public float TimeScaleFactor = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Time.timeScale = TimeScaleFactor;
	
	}
}
