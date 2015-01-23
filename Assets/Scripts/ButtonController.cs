using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

    //public GameObject button1;
    //public GameObject button2;
    //public GameObject button3;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}
    
    public void LoadANewLevel()
    {
        if(gameObject.tag == "PlayGame")
            Application.LoadLevel(1);

        if(gameObject.tag == "Credits")
            Application.LoadLevel(2);

        if (gameObject.tag == "Quit")
            Application.Quit();

        if (Application.loadedLevel == 2)
            Application.LoadLevel(0);
    }
}
