﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public bool isSinglePlayer;
    [Header("Controllers")]
    public string controller1Name;
    public string controller2Name;
    [Space(5)]
    public bool p1IsXbox360;
    public bool p1IsLogitech;
    public bool p1IsPS4;
    [Space(10)]
    public bool p2IsXbox360;
    public bool p2IsLogitech;
    public bool p2IsPS4;
    [Header("Input")]
    public bool moveLeft;
    public bool moveRight;
    public bool canJump;
    public bool leftTriggerDown;
    public bool rightStickR;
    public bool rightStickL;
    public bool grab;

    PlayerMove pMove;

    // Use this for initialization
    void Awake()
    {
        pMove = GetComponent<PlayerMove>();

        if (pMove.isKeyboard == false)
        {
            for (int i = 0; i < Input.GetJoystickNames().Length; i++)
            {
                controller1Name = Input.GetJoystickNames()[0];
                if (isSinglePlayer == false)
                {
                    controller2Name = Input.GetJoystickNames()[1];
                }
            }

            if (pMove.isPlayer1)
            {
                switch (controller1Name)
                {
                    case "Xbox 360 Controller":
                        p1IsXbox360 = true;
                        break;
                    case "Wireless Controller":  //PS4
                        p1IsPS4 = true;
                        break;
                    case "Logitech Dual Action":
                        p1IsLogitech = true;
                        break;
                    default:
                        print("CONTROLLER 1 ERROR");
                        break;
                }
            }
            else
            {
                switch (controller2Name)
                {
                    case "Xbox 360 Controller":
                        p2IsXbox360 = true;
                        break;
                    case "Wireless Controller":  //PS4
                        p2IsPS4 = true;
                        break;
                    case "Logitech Dual Action":
                        p2IsLogitech = true;
                        break;
                    default:
                        print("CONTROLLER 2 ERROR");
                        break;
                }

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Xbox
        // PS4



    }

    //Xbox
    public void Xbox360Input()
    {
        // Left Stick Move
        if (Input.GetAxis("Left Stick X") > 0.1f) // Right
        {
            moveRight = true;
        }
        else if (Input.GetAxis("Left Stick X") < -0.1f) // Left
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
            moveRight = false;
        }

        // Jump
        if (pMove.isGrounded)
        {
            if (Input.GetButtonDown("A Button"))
            {
                canJump = true;
            }
        }
        else
        {
            canJump = false;
        }

    }

    public void XboxButtons360Arms()
    {


        if (Input.GetAxis("Right Stick X") < -0.1f || Input.GetAxis("Right Stick Y") < -0.1f)
        {
            rightStickR = true;
        }
        else if (Input.GetAxis("Right Stick X") > 0.1f || Input.GetAxis("Right Stick Y") > 0.1f)
        {
            rightStickL = true;
        }
        else
        {
            rightStickL = false;
            rightStickR = false;
        }
        //armObj.GetComponent<SpriteRenderer>().color = Color.green;




        if (Input.GetAxis("Left Trigger") > 0)
        {
            leftTriggerDown = true;
        }
        else
        {
            leftTriggerDown = false;
        }

        // Grab
        if (Input.GetButton("RB Button"))
        {
            grab = true;
        }
        else if (Input.GetButtonUp("RB Button"))
        {
            grab = false;
        }

    }


    //PS4

    //Logitech
    public void Logitechinput()
    {

        if (Input.GetAxis("Left Stick X") > 0.1f) // Right
        {
            moveRight = true;
            moveLeft = false;
        }
        else if (Input.GetAxis("Left Stick X") < -0.1f)
        {
            moveLeft = true;
            moveRight = false;

        }
        else
        {
            moveLeft = false;
            moveRight = false;
        }

        //if (Input.GetAxis("Right Stick X") < -0.1f || Input.GetAxis("Right Stick Y") < -0.1f)
        //{
        //    print("Right");
        //}
        //else if (Input.GetAxis("Right Stick X") > 0.1f || Input.GetAxis("Right Stick Y") > 0.1f)
        //{
        //    print("Left");
        //}


        // Logitech
        if (pMove.isGrounded)
        {
            if (Input.GetKey(KeyCode.Joystick1Button1))
            {
                // print("1"); // Logitech A
                canJump = true;
            }
        }
        else
        {
            canJump = false;
        }
    }

}
