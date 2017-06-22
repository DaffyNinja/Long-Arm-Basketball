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

    Quaternion angleL;
    Quaternion angleR;

    //public GameObject armObj;

    // Use this for initialization
    void Start()
    {
        canRotate = true;

        angleL.eulerAngles = new Vector3(0, 0, minRot);
        angleR.eulerAngles = new Vector3(0, 0, maxRot);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, angleR, rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.L))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, angleL, rotateSpeed * Time.deltaTime);
        }

        // print(transform.localEulerAngles.z);

    }

    //public static float ClampAngle(float angle, float min, float max)
    //{
    //    if (angle < -360F)
    //    {
    //        angle += 360F;
    //    }
    //    if (angle > 360F)
    //    {
    //        angle -= 360F;
    //    }

    //    return Mathf.Clamp(angle, min, max);
    //}
}
