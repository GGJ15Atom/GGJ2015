using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {
	public int Damage;

	void Start()
	{
		Damage = 5;
	}

	void OnCollisionEnter2D (Collision2D obj)
	{
		if (obj.gameObject.tag == "Player") 
		{
			PlayerController.Health -= Damage;
		}
	}

}
