using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeArm : MonoBehaviour {

    public float rotateSpeed;

    public float minRot;
    public float maxRot;

    bool canRotate;

    //public GameObject armObj;

	// Use this for initialization
	void Start ()
    {
        canRotate = true;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (canRotate)
        {
            if (Input.GetKey(KeyCode.J))
            {
                transform.Rotate(0, 0, rotateSpeed);
            }
            else if (Input.GetKey(KeyCode.L))
            {
                transform.Rotate(0, 0, -rotateSpeed);
            }
        }

        //print(canRotate.ToString());

    }
}
