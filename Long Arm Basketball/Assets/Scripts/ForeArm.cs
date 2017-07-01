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

    ArmMove aMove;

    PlayerMove playMove;

    //public GameObject armObj;

    // Use this for initialization
    void Awake()
    {
        aMove = transform.GetComponentInParent<ArmMove>();

        canRotate = true;

        angleL.eulerAngles = new Vector3(0, 0, leftRotMax);
        angleR.eulerAngles = new Vector3(0, 0, rightRotMax);

        playMove = GetComponentInParent<PlayerMove>();


    }

    // Update is called once per frame
    void Update()
    {

        if (playMove.isPlayer1)  // Player 1
        {
            if (playMove.isKeyboard)
            {
                if (Input.GetKey(KeyCode.J))
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, leftRotMax * Mathf.Sin(Time.deltaTime * rotateSpeed)), rotateSpeed * Time.deltaTime);

                    transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;
                }
                else if (Input.GetKey(KeyCode.L))
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, rightRotMax * Mathf.Sin(Time.deltaTime * rotateSpeed)), rotateSpeed * Time.deltaTime);

                    transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;
                }
                else
                {
                    transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
                }


            }
            else  // Controller
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

                    transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;

                }
                else
                {

                    transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
                }
            }

        }
        else // Player 2
        {
            if (playMove.isKeyboard) // Keyboard
            {
                if (Input.GetKey(KeyCode.J))
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, leftRotMax * Mathf.Sin(Time.deltaTime * rotateSpeed)), rotateSpeed * Time.deltaTime);

                    transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;
                }
                else if (Input.GetKey(KeyCode.L))
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, rightRotMax * Mathf.Sin(Time.deltaTime * rotateSpeed)), rotateSpeed * Time.deltaTime);

                    transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;
                }
                else
                {
                    transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
                }


            }
            else  // Controller
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

                    transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;

                }
                else
                {

                    transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }


    }
}
