using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public string controller1Name;
    public string controller2Name;


    bool isXbox360;
    bool isLogitech;
    bool isPS4;

    // Use this for initialization
    void Awake()
    {
        for (int i = 0; i < Input.GetJoystickNames().Length; i++)
        {
            //print(Input.GetJoystickNames()[i].ToString());

            controller1Name = Input.GetJoystickNames()[0];
            controller2Name = Input.GetJoystickNames()[1];
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetJoystickNames()[0] == "Logitech Dual Action")
        {
            isLogitech = true;
        }

        if (isLogitech == true)
        {
            if (Input.GetAxis("Left Stick X") > 0.1f) // Right
            {
                print("Right");
            }
            else if (Input.GetAxis("Left Stick X") < -0.1f)
            {
                print("Left");
            }

            if (Input.GetAxis("Right Stick X") < -0.1f || Input.GetAxis("Right Stick Y") < -0.1f)
            {
                print("Right");
            }
            else if (Input.GetAxis("Right Stick X") > 0.1f || Input.GetAxis("Right Stick Y") > 0.1f)
            {
                print("Left");
            }

            // Logitech
            if (Input.GetKey(KeyCode.Joystick1Button1))
            {
                print("1"); // Logitech A
            }
            else if (Input.GetKey(KeyCode.Joystick1Button4))
            {
                print("4"); // Logitech LB
            }
            else if (Input.GetKey(KeyCode.Joystick1Button5))
            {
                print("5"); // Logitech RB
            }
            else if (Input.GetKey(KeyCode.Joystick1Button6))
            {
                print("6"); // Logitech LT
            }
            else if (Input.GetKey(KeyCode.Joystick1Button7))
            {
                print("7"); // Logitech RT
            }
        }

    }
}
