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

    bool grabed;

    public bool leftTriggerDown;

    ForeArm fArm;

    PlayerMove playMove;

    ControllerManager controlMan;

    [Space(5)]
    public Ball ballCS;
    private bool throwBall;

    Rigidbody2D ballRig;


    // Use this for initialization
    void Awake()
    {

        ballRig = ballCS.gameObject.GetComponent<Rigidbody2D>();

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
    void FixedUpdate()
    {
        if (armCol.IsTouching(playerCap))
        {
            Physics2D.IgnoreCollision(armCol, playerCap);
        }

        // Ball
        // Hold
        if (Input.GetKey(KeyCode.Space) && ballCS.isTouchingHand)
        {
            ballRig.GetComponent<Rigidbody2D>().simulated = false;

            grabed = true;

            ballCS.gameObject.transform.position = new Vector2(handObj.transform.position.x + 0.5f, handObj.transform.position.y + 0.5f);
            ballCS.gameObject.transform.parent = handObj.transform;
        }

        if (Input.GetKeyUp(KeyCode.Space)) // throw
        {
            throwBall = true;

            ballCS.gameObject.transform.parent = null;

            ballRig.GetComponent<Rigidbody2D>().simulated = true;            
        }

        if (ballCS.isTouchingHand)
        {
            if (grabed)
            {
                if (throwBall)
                {
                    print("Throw");

                    ballRig.GetComponent<Rigidbody2D>().AddForce(transform.forward);

                    //ballRig.GetComponent<Rigidbody2D>().AddForce(new Vector2(75f, 10));

                    throwBall = false;

                    grabed = false;
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
