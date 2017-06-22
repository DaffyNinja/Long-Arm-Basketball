using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeArm : MonoBehaviour
{

    public float rotateSpeed;

    //public float leftAngle;
    //public float rightAngle;
    
    public float minRot;
    public float maxRot;

    bool canRotate;

    Quaternion angleL;
    Quaternion angleR;

    [Space(5)]
    public bool isKeyboard;

    //public GameObject armObj;

    // Use this for initialization
    void Start()
    {
        canRotate = true;

        if (minRot < -360F)
        {
            minRot += 360F;
        }
        if (minRot > 360F)
        {
            minRot -= 360F;
        }

        if (maxRot < -360F)
        {
            maxRot += 360F;
        }
        if (maxRot > 360F)
        {
            maxRot -= 360F;
        }

        angleL.eulerAngles = new Vector3(0, 0, minRot);
        angleR.eulerAngles = new Vector3(0, 0, maxRot);

        //angleL.eulerAngles = new Vector3(0, 0, ClampAngle(leftAngle,minRot,maxRot));
        //angleR.eulerAngles = new Vector3(0, 0, ClampAngle(rightAngle, minRot, maxRot));

    }

    // Update is called once per frame
    void Update()
    {
        if (isKeyboard)
        {
            if (Input.GetKey(KeyCode.J))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, angleR, rotateSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.L))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, angleL, rotateSpeed * Time.deltaTime);
            }
        }
        else
        {
            //// Arm
            if (Input.GetAxis("Right Stick Y") < -0.1f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, angleR, rotateSpeed * Time.deltaTime);
            }
            else if (Input.GetAxis("Right Stick Y") > 0.1f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, angleL, rotateSpeed * Time.deltaTime);
            }
        }

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
