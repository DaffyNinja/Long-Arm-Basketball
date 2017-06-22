using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeArm : MonoBehaviour
{

    public float rotateSpeed;

    //public float leftAngle;
    //public float rightAngle;
    
    public float leftRotMax;
    public float rightRotMax;

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

        angleL.eulerAngles = new Vector3(0, 0, leftRotMax);
        angleR.eulerAngles = new Vector3(0, 0, rightRotMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (leftRotMax < -360F)
        {
            leftRotMax += 360F;
        }
        if (leftRotMax > 360F)
        {
            leftRotMax -= 360F;
        }

        if (rightRotMax < -360F)
        {
            rightRotMax += 360F;
        }
        if (rightRotMax > 360F)
        {
            rightRotMax -= 360F;
        }

        if (isKeyboard)
        {
            if (Input.GetKey(KeyCode.J))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, angleL, rotateSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.L))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, angleR, rotateSpeed * Time.deltaTime);
            }
        }
        else
        {
            //// Arm
            if (Input.GetAxis("Right Stick Y") < -0.1f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, angleL, rotateSpeed * Time.deltaTime);
            }
            else if (Input.GetAxis("Right Stick Y") > 0.1f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, angleR, rotateSpeed * Time.deltaTime);
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
