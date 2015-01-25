using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public int playerHealth;
	public  int playerMana;
	public UnityEngine.UI.Text hudText;
	 
	// Use this for initialization
	void Start () {
		playerHealth = PlayerController.Health;
		playerMana = PlayerController.Mana;

	}
	
	// Update is called once per frame
	void Update () {
		playerHealth = PlayerController.Health;
		playerMana = PlayerController.Mana;
		hudText.text = " Health " + playerHealth + " Mana " + playerMana;
		//hudText.text = " Mana " + playerMana ;
	
	}
}
