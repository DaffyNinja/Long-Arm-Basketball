using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeArm : MonoBehaviour
{

    public float rotateSpeed;

    public float minRot;
    public float maxRot;

    bool canRotate;
    public bool canMoveLeft;
    public bool canMoveRight;

    private float rotationZ = 0f;
    public float sensitivityZ = 2f;

    //public GameObject armObj;

    // Use this for initialization
    void Start()
    {
        canRotate = true;


    }

    // Update is called once per frame
    void Update()
    {

        if (transform.localEulerAngles.z <= 20 || transform.localEulerAngles.z >= 100)  // Right
        {
            canMoveLeft = false;
            canMoveRight = true;
        }
        else
        {
            canMoveLeft = true;
            canMoveRight = false;
        }

        if (transform.localEulerAngles.z >= 180)  // Left
        {
            canMoveLeft = true;
            canMoveRight = false;
        }
        else
        {
            canMoveLeft = false;
            canMoveRight = true;
        }

        if (canMoveLeft && Input.GetKey(KeyCode.J))
        {
            transform.Rotate(0, 0, rotateSpeed);
        }
        else if (canMoveRight && Input.GetKey(KeyCode.L))
        {
            transform.Rotate(0, 0, -rotateSpeed);
        }


        //if (Input.GetKey(KeyCode.J))
        //{
        //    rotationZ += rotateSpeed * Time.deltaTime;
        //    rotationZ = Mathf.Clamp(rotationZ, -minRot, maxRot);

        //    // transform.Rotate(0, 0, rotationZ);

        //    transform.Rotate(transform.localEulerAngles.x, transform.localEulerAngles.y, rotationZ);

        //}
        //else if (Input.GetKey(KeyCode.L))
        //{
        //    rotationZ += rotateSpeed * Time.deltaTime;
        //    rotationZ = Mathf.Clamp(rotationZ, -minRot, maxRot);

        //    //transform.Rotate(0, 0, -rotationZ);

        //    transform.Rotate(transform.localEulerAngles.x, transform.localEulerAngles.y, -rotationZ);
        //}
        //else
        //{
        //    rotationZ = 0;
        //}

        print(transform.localEulerAngles.z);

    }
}
