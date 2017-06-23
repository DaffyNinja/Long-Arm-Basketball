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

   public float angleTest;

    [Space(5)]
    public bool isKeyboard;

     ArmMove aMove;

    //public GameObject armObj;

    // Use this for initialization
    void Awake()
    {
        aMove = transform.GetComponentInParent<ArmMove>();

        canRotate = true;

        angleL.eulerAngles = new Vector3(0, 0, leftRotMax);
        angleR.eulerAngles = new Vector3(0, 0, rightRotMax);

        angleTest = transform.localEulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (isKeyboard)
        {
            if (Input.GetKey(KeyCode.J))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(0,0, leftRotMax * Mathf.Sin(Time.deltaTime * rotateSpeed)),rotateSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.L))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, rightRotMax * Mathf.Sin(Time.deltaTime * rotateSpeed)), rotateSpeed * Time.deltaTime);

            }
        }
        else
        {

            //// Arm
            if (aMove.leftTriggerDown == true)
            {
                if (Input.GetAxis("Right Stick Y") < -0.1f)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, leftRotMax * Mathf.Sin(Time.deltaTime * rotateSpeed)), rotateSpeed * Time.deltaTime);
                }
                else if (Input.GetAxis("Right Stick Y") > 0.1f)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, rightRotMax * Mathf.Sin(Time.deltaTime * rotateSpeed)), rotateSpeed * Time.deltaTime);
                }
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
