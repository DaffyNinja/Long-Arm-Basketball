using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeArm : MonoBehaviour
{

    public float rotateSpeed;

    public float angleRot;
    public float minRot;
    public float maxRot;

    bool canRotate;
    public bool canMoveLeft;
    public bool canMoveRight;

    public float angle;

    //public GameObject armObj;

    // Use this for initialization
    void Start()
    {
        canRotate = true;


    }

    // Update is called once per frame
    void Update()
    {
        //ClampAngle(angleRot, minRot, maxRot);

        //angleRot = ClampAngle(angleRot, -minRot, maxRot);

     

        if (angle < -360F)
        {
            angle += 360F;
        }
        if (angle > 360F)
        {
            angle -= 360F;
        }


        if (transform.localEulerAngles.z >= angle)
        {
            print("Left");

            if (Input.GetKey(KeyCode.J))
            {
                transform.Rotate(0, 0, rotateSpeed);
            }
        }
        else if (transform.localEulerAngles.z <= angle)
        {
            print("Right");

            if (Input.GetKey(KeyCode.L))
            {
                transform.Rotate(0, 0, -rotateSpeed);
            }
        }


        //if (Input.GetKey(KeyCode.J))
        //{
        //    transform.rotation = Quaternion.Euler(0, 0, 90);
        //}
        //else if (Input.GetKey(KeyCode.L))
        //{
        //    transform.rotation = Quaternion.Euler(0, 0, -90);
        //}

        // print(transform.localEulerAngles.z);

    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
        {
            angle += 360F;
        }
        if (angle > 360F)
        {
            angle -= 360F;
        }

        return Mathf.Clamp(angle, min, max);
    }
}
