using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour
{
    public int score1;
    public int score2;

    public float scoreTime;
    float timer;

    public float gameTime;
    public bool runTimer;

    float minutes;
    float seconds;

    [Space(5)]
    public GameObject leftHoop;
    BoxCollider2D leftHoopCol;
    public GameObject rightHoop;
    BoxCollider2D rightHoopCol;

    bool leftHoopScored;
    bool rightHoopScored;


    public GameObject ballObj;
    CircleCollider2D ballCol;
    [Space(5)]
    public TMP_Text scoreText1;
    public TMP_Text scoreText2;

    public TMP_Text minutesText;
    public TMP_Text secText;

    public TMP_Text winText;

    //public TMP_Text scoreText1;


    // Use this for initialization
    void Start()
    {
        leftHoopCol = leftHoop.GetComponent<BoxCollider2D>();
        rightHoopCol = rightHoop.GetComponent<BoxCollider2D>();

        ballCol = ballObj.GetComponent<CircleCollider2D>();

        winText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (runTimer)
        {
            gameTime -= Time.deltaTime;

            minutes = Mathf.Floor(gameTime / 60f);
            seconds = Mathf.Floor(gameTime % 60f);

            minutesText.text = minutes.ToString();
            secText.text = seconds.ToString();

            if (gameTime <= 0)
            {
                runTimer = false;
            }
        }
        else
        {
            minutesText.text = ("0");
            secText.text = ("0");
        }



        if (leftHoopCol.IsTouching(ballCol))
        {
            // print("LEFT SCORE");

            leftHoopScored = true;

            
            if (leftHoopScored == true)
            {
                timer += Time.deltaTime;

                if (timer >= scoreTime)
                {
                    score2 += 1;
                    leftHoopScored = false;
                    timer = 0;
                }
            }
            else
            {
                timer = 0;
            }



        }
        else if (rightHoopCol.IsTouching(ballCol))
        {
            //  print("RIGHT SCORE");

            rightHoopScored = true;

            if (rightHoopScored == true)
            {
                timer += Time.deltaTime;

                if (timer >= scoreTime)
                {
                    score1 += 1;
                    rightHoopScored = false;
                    timer = 0;
                }
            }
            else
            {
                timer = 0;
            }

        }

        scoreText1.text = score1.ToString();
        scoreText2.text = score2.ToString();

        if (gameTime <= 0)
        {
            if (score1 > score2)
            {
                winText.gameObject.SetActive(true);

                winText.text = "Player 1 Wins!";
            }
            else if (score2 > score1)
            {
                winText.gameObject.SetActive(true);

                winText.text = "Player 2 Wins!";
            }
            else if (score1 == score2 && score2 == score1)
            {
                winText.gameObject.SetActive(true);

                winText.text = "Tie!";
            }
        }
    }
}
