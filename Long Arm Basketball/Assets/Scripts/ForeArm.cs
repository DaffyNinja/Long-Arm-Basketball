using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeArm : MonoBehaviour {

    public GameObject armObj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(armObj.transform.position.x + 4, armObj.transform.position.y + 5, armObj.transform.position.z);
    }
}
