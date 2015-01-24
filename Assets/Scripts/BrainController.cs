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
    //private float speed = 2.0f;
    

    void Awake()
    {
        //newPosition = transform.position;
        state = CellLine.Down;
        rigidbody2D.velocity = new Vector2(8.0f, 0.0f);
    }
    
    // Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Vector3 positionDown = new Vector2(transform.position.x, 0);
        //Vector3 positionMiddle = new Vector2(transform.position.x, 2);
        //Vector3 positionUp = new Vector2(transform.position.x, 4);
        
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
                rigidbody2D.velocity = new Vector2(4.0f, -8.0f);
                //transform.position = positionDown;   
               
            }
            else if ((state == CellLine.Up))
            {
                // go Middle State
                state = CellLine.Middle;
                //transform.position = positionMiddle;
                rigidbody2D.velocity = new Vector2(4.0f, -8.0f);
            }
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (state == CellLine.Down)
            {
                // go Middle State
                state = CellLine.Middle;
                //transform.position = positionMiddle;
                rigidbody2D.velocity = new Vector2(4.0f, 8.0f);
            }
            else if ((state == CellLine.Middle))
            {
                // go Up State
                state = CellLine.Up;
                //transform.position = positionUp;
                rigidbody2D.velocity = new Vector2(4.0f, 8.0f);
            }
            else if ((state == CellLine.Up))
            {
                // do nothing
            }
        }

        if (state == CellLine.Down && transform.position.y < 0.0f)
            rigidbody2D.velocity = new Vector2(8.0f, 0.0f);

        else if (state == CellLine.Middle && transform.position.y > 1.8f && transform.position.y < 2.3f)
            rigidbody2D.velocity = new Vector2(8.0f, 0.0f);

        else if (state == CellLine.Up && transform.position.y > 4.0f)
            rigidbody2D.velocity = new Vector2(8.0f, 0.0f);
	}

    /*private IEnumerator ChangePathRoutine(Vector2 targetPosition)
    {
        //while (Vector2.Distance(transform.position, targetPosition) > 0.05f)
        //{
            //transform.position = Vector2.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * speed);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.fixedDeltaTime * speed);

            yield return null;
        //}
    }*/
}



//while(transform.position.y != 0)
//    rigidbody2D.velocity = new Vector2(2.0f, -2.0f);

//rigidbody2D.velocity = new Vector2(8.0f, 0.0f);


//newPosition = positionDown;
//transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);


//StartCoroutine(ChangePathRoutine(new Vector2(transform.position.x, 0)));

//transform.position = Vector2.MoveTowards(transform.position, positionDown, Time.fixedDeltaTime * speed);

//rigidbody2D.velocity = new Vector2(8.0f, 0.0f);

//rigidbody.velocity = Vector3.Lerp(rigidbody2D.velocity, newVelocity, Time.deltaTime * speed);
