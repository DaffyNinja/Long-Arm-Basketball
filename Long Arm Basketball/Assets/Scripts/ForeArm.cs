using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeArm : MonoBehaviour
{

    public float rotateSpeed;

    public float minRot;
    public float maxRot;

    float angle;

    bool canRotate;

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
            //angle += Input.GetAxis("Vertical") * Time.deltaTime * rotateSpeed;
            angle = Mathf.Clamp(angle, minRot, maxRot);
            //transform.localRotation = Quaternion.AngleAxis(angle, Vector3.right);

            if (Input.GetKey(KeyCode.J))
            {
                angle += rotateSpeed * Time.deltaTime;

                // transform.Rotate(0, 0, angle);

                transform.localRotation = Quaternion.Euler(0, 0, angle);

            }
            else if (Input.GetKey(KeyCode.L))
            {
                angle += rotateSpeed * Time.deltaTime;

                //transform.Rotate(0, 0, -angle);

                // transform.localRotation = Quaternion.AngleAxis(-angle, Vector2.left);

                transform.localRotation = Quaternion.Euler(0, 0, -angle);

            }
            else
            {
                angle = 0;
            }
        }

      

        //print(canRotate.ToString());

    }
}
