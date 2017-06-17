using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour
{
    public int score1;
    public int score2;

    public float gameTime;

    float minutes;
    float seconds;

    [Space(5)]
    public GameObject leftHoop;
    BoxCollider2D leftHoopCol;
    public GameObject rightHoop;
    BoxCollider2D rightHoopCol;

    public GameObject ballObj;
    CircleCollider2D ballCol;
    [Space(5)]
    public TMP_Text scoreText1;
    public TMP_Text scoreText2;

    public TMP_Text minutesText;
    public TMP_Text secText;

    //public TMP_Text scoreText1;


    // Use this for initialization
    void Start()
    {
        leftHoopCol = leftHoop.GetComponent<BoxCollider2D>();
        rightHoopCol = rightHoop.GetComponent<BoxCollider2D>();

        ballCol = ballObj.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;

        minutes = Mathf.Floor(gameTime / 60f);
        seconds = Mathf.Floor(gameTime % 60f);

        minutesText.text = minutes.ToString();
        secText.text = seconds.ToString();

        if (leftHoopCol.IsTouching(ballCol))
        {
            // print("LEFT SCORE");
            score2 += 1;
        }
        else if (rightHoopCol.IsTouching(ballCol))
        {
            //  print("RIGHT SCORE");
            score1 += 1;
        }

        scoreText1.text = score1.ToString();
        scoreText2.text = score2.ToString();

        if (gameTime <= 0)
        {
            if (score1 > score2)
            {
                print("Player 1 Wins");
            }
            else if (score2 > score1)
            {
                print("Player 2 Wins");
            }
            else if (score1 == score2 && score2 == score1)
            {
                print("TIE");
            }
        }
    }
}
