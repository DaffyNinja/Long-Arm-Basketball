using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

    public Vector2 ballForce;

    public float upForce;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        // Ball

        if (Input.GetKey(KeyCode.W))
        {
            upForce += 1 * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(ballForce.x,upForce), ForceMode2D.Impulse);

            upForce = 0;
          
        }
		
	}
}
