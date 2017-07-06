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

    [Header("Ball Throw")]
    public float  ballForceFowardX;
    public float ballForceFowardYForce;
    public Vector2 ballForceBack;
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

            if (Input.GetKey(KeyCode.Space))
            {
                ballForceFowardYForce += 1 * Time.deltaTime;
            }
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

                       // ballObj.transform.position = new Vector3(handObj.transform.position.x + 1f, handObj.transform.position.y + 1f, handObj.transform.position.z);

                        //ballObj.transform.position = handObj.transform.position;

                      

                        addBallForce = true;
                    }
                }

                if (Input.GetKeyUp(KeyCode.Space))
                {
                    //print("LET GO");

                    ballObj.GetComponent<Rigidbody2D>().simulated = true;
                    ballObj.transform.parent = null;
                    Physics2D.IgnoreCollision(ballObj.GetComponent<CircleCollider2D>(), handObj.GetComponent<CircleCollider2D>(), false);

                    if (addBallForce) // Throw Ball
                    {
                        print("Throw");


                        ballObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(ballForceFowardX,ballForceFowardYForce), ForceMode2D.Impulse);
                

                        ballForceFowardYForce = 0;

                        addBallForce = false;

                        //if (fArm.gameObject.transform.localEulerAngles.z > 175 && fArm.gameObject.transform.localEulerAngles.z < 320)
                        //{
                        //    print("FORWARD");

                        //    ballObj.GetComponent<Rigidbody2D>().AddForce(ballForceFoward, ForceMode2D.Impulse);
                        //    addBallForce = false;
                        //}
                        //else
                        //{
                        //    print("BACK");

                        //    ballObj.GetComponent<Rigidbody2D>().AddForce(ballForceBack, ForceMode2D.Impulse);
                        //    addBallForce = false;
                        //}

                    }

                    // print(fArm.gameObject.transform.localEulerAngles.z);

                    ballObj.GetComponent<Rigidbody2D>().angularVelocity = 3;
                    addBallForce = false;
                }
            }
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
