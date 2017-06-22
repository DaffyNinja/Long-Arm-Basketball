using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool isPlayer1;

    public float speed;
    public float rotateSpeed;

    GameObject arm;
    CapsuleCollider2D armCap;

    public bool isKeyboard;

   // public HingeJoint2D armJoint;

    // public BoxCollider2D groundCol;

    Rigidbody2D rig;

    // Use this for initialization
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        arm = transform.GetChild(0).gameObject;
        armCap = arm.GetComponent<CapsuleCollider2D>();

        // groundCol = GameObject.Find("Ground").GetComponentInChildren<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<CapsuleCollider2D>().IsTouching(armCap))
        {
            Physics2D.IgnoreCollision(GetComponent<CapsuleCollider2D>(), armCap);
        }

        if (isPlayer1)
        {
            if (isKeyboard)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    Vector2 moveQuality = new Vector2(speed, 0);
                    rig.velocity = new Vector2(moveQuality.x, rig.velocity.y);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    Vector2 moveQuality = new Vector2(-speed, 0);
                    rig.velocity = new Vector2(moveQuality.x, rig.velocity.y);
                }

                // Arm Rotate
                if (Input.GetKey(KeyCode.U))
                {
                    arm.transform.Rotate(0, 0, rotateSpeed);

                }
                else if (Input.GetKey(KeyCode.P))
                {
                    arm.transform.Rotate(0, 0, -rotateSpeed);
                }
            }
            else
            {
                if (Input.GetAxis("Left Stick X") > 0.1f)
                {
                    Vector2 moveQuality = new Vector2(speed, 0);
                    rig.velocity = new Vector2(moveQuality.x, rig.velocity.y);
                }
                else if (Input.GetAxis("Left Stick X") < -0.1f)
                {
                    Vector2 moveQuality = new Vector2(-speed, 0);
                    rig.velocity = new Vector2(moveQuality.x, rig.velocity.y);
                }

                // Arm
                if (Input.GetAxis("Right Stick Y") < -0.1f)
                {
                    arm.transform.Rotate(0, 0, rotateSpeed);
                }
                else if (Input.GetAxis("Right Stick Y") > 0.1f)
                {
                    arm.transform.Rotate(0, 0, -rotateSpeed);
                }
            }
        }
        else // Player 2
        {
            if (isKeyboard)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    Vector2 moveQuality = new Vector2(speed, 0);
                    rig.velocity = new Vector2(moveQuality.x, rig.velocity.y);
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    Vector2 moveQuality = new Vector2(-speed, 0);
                    rig.velocity = new Vector2(moveQuality.x, rig.velocity.y);
                }

                if (Input.GetKey("[6]"))
                {
                    arm.transform.Rotate(0, 0, rotateSpeed);
                }
                else if (Input.GetKey("[4]"))
                {
                    arm.transform.Rotate(0, 0, -rotateSpeed);
                }
            }

        }

    }

    //private void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (armCap.IsTouching(groundCol))
    //    {
    //        Physics2D.IgnoreCollision(groundCol, armCap,true);
    //    }

    //}
}
