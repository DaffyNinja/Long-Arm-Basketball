﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool isPlayer1;

    public float speed;

    public float jumpForce;
    bool isGrounded;


    GameObject arm;
    CapsuleCollider2D armCap;

    public bool isKeyboard;

    Rigidbody2D rig;

    // Use this for initialization
    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();

        arm = transform.GetChild(0).gameObject;
        armCap = arm.GetComponent<CapsuleCollider2D>();
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

                if (isGrounded)
                {
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        Vector2 moveQuality = new Vector2(0, jumpForce);
                        rig.velocity = new Vector2(rig.velocity.x, moveQuality.y);
                    }
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


                if (isGrounded)
                {
                    if (Input.GetButtonDown("A Button"))
                    {
                        Vector2 moveQuality = new Vector2(0, jumpForce);
                        rig.velocity = new Vector2(rig.velocity.x, moveQuality.y);
                    }
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

                //if (Input.GetKey("[6]"))
                //{
                //    arm.transform.Rotate(0, 0, rotateSpeed);
                //}
                //else if (Input.GetKey("[4]"))
                //{
                //    arm.transform.Rotate(0, 0, -rotateSpeed);
                //}
            }

        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        //if (armCap.IsTouching(groundCol))
        //{
        //    Physics2D.IgnoreCollision(groundCol, armCap, true);
        //}

    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }

    }
}
