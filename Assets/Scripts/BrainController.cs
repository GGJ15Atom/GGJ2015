using UnityEngine;
using System.Collections;

public class BrainController : MonoBehaviour {

	public enum CellLine
    {
        Down,
        Middle,
        Up
    }

    public CellLine state;
    private float speed = 2.0f;
    private float minimum = 5.0F;
    private float maximum = 10.0F;
    
    // Use this for initialization
	void Start () 
    {
        state = CellLine.Down;
        rigidbody2D.velocity = new Vector2(8.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (state == CellLine.Down)
            {
                // do nothing
            }
            else if ((state == CellLine.Middle))
            {
                // go Down State
                state = CellLine.Down;
                transform.position = new Vector2(transform.position.x, 0);
                
                //this.transform.position.x += this.speed * Time.deltaTime;

                //transform.position = Vector2.Lerp(new Vector2(transform.position.x, 2.0f),new Vector2(transform.position.x, 0.0f), (Time.time));
            }
            else if ((state == CellLine.Up))
            {
                // go Middle State
                state = CellLine.Middle;
                transform.position = new Vector2(transform.position.x, 2);
            }
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (state == CellLine.Down)
            {
                // go Middle State
                state = CellLine.Middle;
                transform.position = new Vector2(transform.position.x, 2);
            }
            else if ((state == CellLine.Middle))
            {
                // go Up State
                state = CellLine.Up;
                transform.position = new Vector2(transform.position.x, 4);
            }
            else if ((state == CellLine.Up))
            {
                // do nothing
            }
        }
	}
}
