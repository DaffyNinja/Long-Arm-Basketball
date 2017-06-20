using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMove : MonoBehaviour
{
    public bool isPlayer1;
    public bool isKeyboard;

    bool addBallForce;

    [Space(5)]
    public GameObject handObj;

    public GameObject armObj;
    CapsuleCollider2D armCol;

    public GameObject ballObj;
    CircleCollider2D ballCol;

    BoxCollider2D gCol;

    public GameObject playerObj;
    CapsuleCollider2D playerCap;

    bool canGrab;

    // Use this for initialization
    void Start()
    {

        ballCol = ballObj.GetComponent<CircleCollider2D>();
        armCol = armObj.GetComponent<CapsuleCollider2D>();
        playerCap = playerObj.GetComponent<CapsuleCollider2D>();

        addBallForce = false;

        //ballCol = GameObject.Find("Ball").GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // To WORK ON

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

        if (isPlayer1)
        {
            if (canGrab) // Grab Ball
            {
                if (isKeyboard)
                {
                    if (Input.GetKey(KeyCode.Space)) // Hold
                    {
                        ballObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                        ballObj.transform.parent = handObj.transform;
                      
                        ballObj.transform.position = handObj.transform.position;

                       // ballObj.transform.position = new Vector3(handObj.transform.position.x, handObj.transform.position.y, handObj.transform.position.z);
                        Physics2D.IgnoreCollision(ballObj.GetComponent<CircleCollider2D>(), handObj.GetComponent<CircleCollider2D>());

                         //ballObj.GetComponent<CircleCollider2D>().enabled = false;

                        addBallForce = true;
                    }

                }
                else
                {
                    if (Input.GetButton("RB Button"))
                    {
                        ballObj.transform.parent = handObj.transform;
                        ballObj.transform.position = handObj.transform.position;
                        ballObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
  
                        // ballObj.GetComponent<CircleCollider2D>().enabled = false;

                        addBallForce = true;
                    }
                }

            }

            if (isKeyboard)  // Let Go
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    ballObj.transform.parent = null;
                    ballObj.GetComponent<Rigidbody2D>().simulated = true;
                    ballObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    ballObj.GetComponent<CircleCollider2D>().enabled = true;

                    Physics2D.IgnoreCollision(ballObj.GetComponent<CircleCollider2D>(), handObj.GetComponent<CircleCollider2D>(),false);


                    if (addBallForce == true)
                    {
                        ballObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(500, 800));
                        addBallForce = false;
                    }
                }
            }
            else
            {
                if (Input.GetButtonUp("RB Button"))
                {
                    ballObj.transform.parent = null;
                    ballObj.GetComponent<Rigidbody2D>().simulated = true;
                    ballObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

                    // ballObj.GetComponent<CircleCollider2D>().enabled = true;

                    if (addBallForce == true)
                    {
                        ballObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(500, 800));
                        addBallForce = false;
                    }
                }
            }
        }
        else  // player 2
        {
            if (canGrab)
            {
                if (isKeyboard)
                {
                    if (Input.GetKey("[0]"))
                    {
                        ballObj.transform.parent = transform;
                        ballObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                        ballObj.transform.position = handObj.transform.position;
                    }
                }


            }

            if (isKeyboard)
            {
                if (Input.GetKeyUp("[0]"))
                {
                    ballObj.transform.parent = null;
                    ballObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

                    ballObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500, -800));
                }
            }

        }

        if (armCol.IsTouching(gCol))
        {
            Physics2D.IgnoreCollision(armCol, gCol);
        }


        //if (armCol.IsTouching())
        //{
        //    Physics2D.IgnoreCollision(armCol, gCol);
        //}
    }

    void OnCollisionEnter2D(Collision2D col)
    {


        if (col.gameObject.name == "Ground")
        {
            gCol = col.gameObject.GetComponent<BoxCollider2D>();

        }



    }


}
