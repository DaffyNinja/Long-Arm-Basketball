using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMove : MonoBehaviour
{
    public float rotateSpeed;
    public float leftAngleMax;
    public float rightAngleMax;

    Quaternion angleL;
    Quaternion angleR;

    public Vector2 ballForce;
    bool addBallForce;

    [Space(15)]
    public GameObject handObj;

    public GameObject armObj;
    CapsuleCollider2D armCol;

    public GameObject ballObj;
    CircleCollider2D ballCol;

    BoxCollider2D gCol;

    public GameObject playerObj;
    CapsuleCollider2D playerCap;

    bool canGrab;

    public bool leftTriggerDown;

    ForeArm fArm;

    PlayerMove playMove;

    ControllerManager controlMan;


    // Use this for initialization
    void Awake()
    {

        ballCol = ballObj.GetComponent<CircleCollider2D>();
        armCol = armObj.GetComponent<CapsuleCollider2D>();
        playerCap = playerObj.GetComponent<CapsuleCollider2D>();

        addBallForce = false;

        angleL.eulerAngles = new Vector3(0, 0, leftAngleMax);
        angleR.eulerAngles = new Vector3(0, 0, rightAngleMax);

        fArm = transform.GetChild(1).GetComponent<ForeArm>();

        playMove = GetComponentInParent<PlayerMove>();

        controlMan = GetComponentInParent<ControllerManager>();

        //ballCol = GameObject.Find("Ball").GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (armCol.IsTouching(playerCap))
        {
            Physics2D.IgnoreCollision(armCol, playerCap);
        }

        if (handObj.GetComponent<CircleCollider2D>().IsTouching(ballCol))
        {
            canGrab = true;
        }
        else
        {
            canGrab = false;
        }

        if (playMove.isPlayer1)  // Player 1
        {
            //Arm Move
            if (playMove.isKeyboard) // Keyboard
            {
                // Arm Rotate
                if (Input.GetKey(KeyCode.I))
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, angleR, rotateSpeed * Time.deltaTime);

                    armObj.GetComponent<SpriteRenderer>().color = Color.green;

                }
                else if (Input.GetKey(KeyCode.P))
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, angleL, rotateSpeed * Time.deltaTime);

                    armObj.GetComponent<SpriteRenderer>().color = Color.green;
                }
                else
                {
                    armObj.GetComponent<SpriteRenderer>().color = Color.white;
                }

                if (canGrab) // Grab Ball
                {
                    if (Input.GetKey(KeyCode.Space)) // Hold
                    {
                        ballObj.GetComponent<Rigidbody2D>().simulated = false;
                        ballObj.transform.SetParent(handObj.transform);

                        ballObj.transform.position = new Vector3(handObj.transform.position.x + 1.5f, handObj.transform.position.y + 1.5f, handObj.transform.position.z);

                        //ballObj.transform.position = handObj.transform.position;
                        addBallForce = true;
                    }
                }

                if (Input.GetKeyUp(KeyCode.Space))
                {
                    //print("LET GO");

                    ballObj.GetComponent<Rigidbody2D>().simulated = true;
                    ballObj.transform.parent = null;
                    // ballObj.GetComponent<Rigidbody2D>().AddForce(ballForce,ForceMode2D.Impulse);
                    Physics2D.IgnoreCollision(ballObj.GetComponent<CircleCollider2D>(), handObj.GetComponent<CircleCollider2D>(), false);

                    if (addBallForce)
                    {
                        print("Throw");

                        if (fArm.gameObject.transform.localEulerAngles.z > 200 && fArm.gameObject.transform.localEulerAngles.z < 320)
                        {
                           // print("FORWARD");
                            ballObj.GetComponent<Rigidbody2D>().AddForce(ballForce, ForceMode2D.Impulse);
                            addBallForce = false;
                        }
                        else
                        {
                           // print("BACK");
                            ballObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-ballForce.x,ballForce.y), ForceMode2D.Impulse);
                            addBallForce = false;
                        }
                    }

                   // print(fArm.gameObject.transform.localEulerAngles.z);

                    ballObj.GetComponent<Rigidbody2D>().angularVelocity = 3;
                    addBallForce = false;
                }
            }
            else // Controller
            {
                controlMan.XboxButtons360Arms();

                if (controlMan.leftTriggerDown == false)
                {
                    if (controlMan.rightStickR)
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, angleR, rotateSpeed * Time.deltaTime);
                    }
                    else if (controlMan.rightStickL)
                    {
                        //print("New Control");
                        transform.rotation = Quaternion.Slerp(transform.rotation, angleL, rotateSpeed * Time.deltaTime);
                    }

                    armObj.GetComponent<SpriteRenderer>().color = Color.green;
                }
                else
                {
                    armObj.GetComponent<SpriteRenderer>().color = Color.white;
                }

                if (canGrab)
                {
                    if (controlMan.grab)
                    {
                        ballObj.GetComponent<Rigidbody2D>().simulated = false;
                        ballObj.transform.SetParent(handObj.transform);

                        ballObj.transform.position = new Vector3(handObj.transform.position.x + 0.5f, handObj.transform.position.y + 0.5f, handObj.transform.position.z);

                        addBallForce = true;
                    }
                }

                if (controlMan.grab == false) // Let go
                {

                    ballObj.GetComponent<Rigidbody2D>().simulated = true;
                    ballObj.transform.parent = null;
                    Physics2D.IgnoreCollision(ballObj.GetComponent<CircleCollider2D>(), handObj.GetComponent<CircleCollider2D>(), false);

                    if (addBallForce == true)
                    {
                        ballObj.GetComponent<Rigidbody2D>().AddForce(ballForce, ForceMode2D.Impulse);
                        addBallForce = false;
                    }
                }

            }

        }
        else  // Player 2
        {

            if (playMove.isKeyboard)
            {

                if (canGrab)
                {
                    if (Input.GetKey("[0]"))
                    {
                        ballObj.GetComponent<Rigidbody2D>().simulated = false;
                        ballObj.transform.SetParent(handObj.transform);

                        ballObj.transform.position = new Vector3(handObj.transform.position.x + 0.5f, handObj.transform.position.y + 0.5f, handObj.transform.position.z);

                        addBallForce = true;
                    }
                }

                if (Input.GetKeyUp("[0]")) // Let go
                {
                    ballObj.GetComponent<Rigidbody2D>().simulated = true;
                    ballObj.transform.parent = null;
                    Physics2D.IgnoreCollision(ballObj.GetComponent<CircleCollider2D>(), handObj.GetComponent<CircleCollider2D>(), false);

                    if (addBallForce == true)
                    {
                        ballObj.GetComponent<Rigidbody2D>().AddForce(ballForce, ForceMode2D.Impulse);
                        addBallForce = false;
                    }
                }

            }
            else // Controller
            {

                if (Input.GetAxis("Left Trigger") > 0)
                {
                    //print("LT");

                    leftTriggerDown = true;
                }
                else
                {
                    leftTriggerDown = false;
                }

                if (leftTriggerDown == false)
                {
                    if (Input.GetAxis("Right Stick X") < -0.1f || Input.GetAxis("Right Stick Y") < -0.1f)
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, angleR, rotateSpeed * Time.deltaTime);
                    }
                    else if (Input.GetAxis("Right Stick X") > 0.1f || Input.GetAxis("Right Stick Y") > 0.1f)
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, angleL, rotateSpeed * Time.deltaTime);
                    }
                }

                if (canGrab)
                {
                    if (Input.GetButton("RB Button"))
                    {
                        ballObj.GetComponent<Rigidbody2D>().simulated = false;
                        ballObj.transform.SetParent(handObj.transform);

                        ballObj.transform.position = new Vector3(handObj.transform.position.x + 0.5f, handObj.transform.position.y + 0.5f, handObj.transform.position.z);

                        addBallForce = true;
                    }

                }

                if (Input.GetButtonUp("RB Button"))
                {

                    ballObj.GetComponent<Rigidbody2D>().simulated = true;
                    ballObj.transform.parent = null;
                    Physics2D.IgnoreCollision(ballObj.GetComponent<CircleCollider2D>(), handObj.GetComponent<CircleCollider2D>(), false);

                    if (addBallForce == true)
                    {
                        if (transform.localEulerAngles.z <= 50)
                        {
                            ballObj.GetComponent<Rigidbody2D>().AddForce(ballForce, ForceMode2D.Impulse);
                            addBallForce = false;
                        }
                        else
                        {

                            ballObj.GetComponent<Rigidbody2D>().AddForce(-ballForce, ForceMode2D.Impulse);
                            addBallForce = false;
                        }
                    }
                }
            }
        }

        if (armCol.IsTouching(gCol))
        {
            Physics2D.IgnoreCollision(armCol, gCol);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Ground")
        {
            gCol = col.gameObject.GetComponent<BoxCollider2D>();

        }

    }


}
