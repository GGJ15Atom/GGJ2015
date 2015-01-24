using UnityEngine;
using System.Collections;

public class SceneSwapper : MonoBehaviour {

    public bool drug1Check;
    public bool returnerCheck;
    //private GameObject[] brainScene;
    //private GameObject mainScene;
    
    // Use this for initialization
	void Start () 
    {
        drug1Check = false;
        returnerCheck = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        SceneChanger();
	}

    void SceneChanger()
    {
        if (returnerCheck == false && drug1Check == true)
        {
            Time.timeScale = 0; //pauses the current scene
            GameObject.FindGameObjectWithTag("MainScene").SetActive(false);
            Application.LoadLevelAdditive(4);
            drug1Check = false;
        }
        //else
        //{
        //    Time.timeScale = 1; //resumes the current scene
        //    gameObject.SetActive(true);
        //    Application.LoadLevelAdditive(3);
        //}

        if(returnerCheck == true && drug1Check == false)
        {

            Time.timeScale = 1;
            //brainScene = GameObject.FindGameObjectsWithTag("BrainScene");
            Debug.Log(GameObject.FindGameObjectsWithTag("BrainScene"));
            Destroy(GameObject.FindGameObjectWithTag("BrainScene"));
            GameObject.FindGameObjectWithTag("MainScene").SetActive(true);
            returnerCheck = false;
            
        }
    }

}
