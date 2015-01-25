using UnityEngine;
using System.Collections;

public class PerlinShake : MonoBehaviour {
	
	public float duration = 0.5f;
	public float speed = 1.0f;
	public float magnitude = 0.1f;
	
	public bool test = false;

	//me
	private Vector3 CurrentCamPosition;
	public Vector3 originalCamPos;
	public Transform PlayerPosition;
	private Vector3 tempPosition;
	public PlayerController playerControl;
	
	// -------------------------------------------------------------------------

	public void PlayShake() {


		StopAllCoroutines();
		StartCoroutine("Shake");
	}
	
	// -------------------------------------------------------------------------
	void Update() {
		//CurrentCamPosition = c
		if (test) {
			test = false;
			PlayShake();
		}
		tempPosition = new Vector3 (PlayerPosition.position.x, Camera.main.transform.position.y, -10.0f);
		Camera.main.transform.position = tempPosition;
		//originalCamPos = Camera.main.transform.position;
	}
	
	// -------------------------------------------------------------------------
	IEnumerator Shake() {
		
		float elapsed = 0.0f;
		
		originalCamPos = Camera.main.transform.position; //CurrentCamPosition;//
		CurrentCamPosition = originalCamPos;
		float randomStart = Random.Range(-1000.0f, 1000.0f);
		
		while (elapsed < duration) {
			playerControl.moveSpeed = 0.0f;
			elapsed += Time.deltaTime;			
			
			float percentComplete = elapsed / duration;			
			
			// We want to reduce the shake from full power to 0 starting half way through
			float damper = 1.0f - Mathf.Clamp(2.0f * percentComplete - 1.0f, 0.0f, 1.0f);
			
			// Calculate the noise parameter starting randomly and going as fast as speed allows
			float alpha = randomStart + speed * percentComplete;
			
			// map noise to [-1, 1]
			float x = Util.Noise.GetNoise(alpha, 0.0f, 0.0f) * 2.0f - 1.0f;
			float y = Util.Noise.GetNoise(0.0f, alpha, 0.0f) * 2.0f - 1.0f;

			x *= magnitude * damper;
			y *= magnitude * damper;
			//Debug.Log(x);
			Camera.main.transform.position = new Vector3(originalCamPos.x+ x,originalCamPos.y+y , originalCamPos.z);
				
			yield return null;
		}
		
		//Camera.main.transform.position = originalCamPos;
		Camera.main.transform.position = CurrentCamPosition;
		playerControl.moveSpeed = 5.0f;
	}
}
