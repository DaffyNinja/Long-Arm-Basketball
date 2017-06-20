using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeArm : MonoBehaviour
{

    public float rotateSpeed;

    public float minRot;
    public float maxRot;

    bool canRotate;
    public bool rotateLeft;
    public bool rotateRight;

    //public GameObject armObj;

    // Use this for initialization
    void Start()
    {
        canRotate = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate)
        {

            if (Input.GetKey(KeyCode.J))
            {


                if (transform.localRotation.z > -10)
                {
                    rotateLeft = true;

                    if (rotateLeft)
                    {
                        transform.Rotate(0, 0, rotateSpeed);
                    }
                }
                else
                {
                    rotateLeft = false;
                }



            }
            else if (Input.GetKey(KeyCode.L))
            {

                if (transform.localRotation.z < 180)
                {
                    rotateRight = true;

                    if (rotateRight)
                    {
                        transform.Rotate(0, 0, -rotateSpeed);
                    }
                }
                else
                {
                    rotateRight = false;
                }
            }

        }

        print(Quaternion.identity.eulerAngles.z);
            



        //print(canRotate.ToString());

    }
}
