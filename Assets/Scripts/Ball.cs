using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] float xPush = 1f;
    [SerializeField] float yPush = 12f;
    [SerializeField] float randomFactor = 0.05f;
    [SerializeField] AudioClip ballSound;


    Rigidbody2D myRigidbody2D;

    GameSession gameSession;

    //Level level;

    int currentSceneIndex = 0;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        myRigidbody2D = GetComponent<Rigidbody2D>();
        gameSession = FindObjectOfType<GameSession>();

        if (!gameSession.GetComponentInChildren<Canvas>().enabled)
        {
            gameSession.GetComponentInChildren<Canvas>().enabled = true;
        }

        transform.position = gameSession.StartingBallPosition();

        LounchBall();

    }



    private void LounchBall()
    {


        if (gameSession.isPlayerStart())
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, PlayerPrefersController.GetBallSpeed());

        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-xPush, -PlayerPrefersController.GetBallSpeed());
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
        //{
        //    ChangeBallAngleInPaddles(collision.gameObject.tag);
        //}
        //else
        //{
        //    ChangeBallAngle();
        //}

        if (collision.gameObject.tag == "Wall")
        {
            AudioSource.PlayClipAtPoint(ballSound, Camera.main.transform.position, 1f);
        } 

        ChangeBallAngle();


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        CalculateScores(collision.gameObject.tag);
    }

    private void RestartLevel(int sceneIndex)
    {
        FindObjectOfType<Level>().LoadCurrentLevelAgain(sceneIndex);
        //FindObjectOfType<Level>().LoadLevelAgain();
    }

    private void CalculateScores(string current_tag)
    {
        switch (current_tag)
        {
            case "ScoreLeft":
                FindObjectOfType<GameSession>().AddPointPlayer();
                gameSession.isPlayerWinPoint(true);
                break;

            case "ScoreRight":
                FindObjectOfType<GameSession>().AddPointEnemy();
                gameSession.isPlayerWinPoint(false);
                break;
            default:
                break;
        }


        if ((gameSession.GetLevelPoint() == gameSession.GetPlayerPoint()) || (gameSession.GetLevelPoint() == gameSession.GetEnemyPoint()))
        {
            if (gameSession.GetPlayerPoint() > gameSession.GetEnemyPoint())
            {
                gameSession.IncreaseGeneralPlayerScore();
            }

            if (gameSession.GetPlayerPoint() < gameSession.GetEnemyPoint())
            {
                gameSession.IncreaseGeneralEnemyScore();
            }

            if (gameSession.IsMaxPoint())
            {
                SceneManager.LoadScene("EndGame");
            }
            else
            {
                SceneManager.LoadScene("CountdownScene");
                gameSession.ResetPoints();
            }

        }
        else
        {
            RestartLevel(currentSceneIndex);
        }


    }

    private void ChangeBallAngleInPaddles(string tag)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, 2f), UnityEngine.Random.Range(0f, 2f));

        myRigidbody2D.velocity += velocityTweak;
    }

    private void ChangeBallAngle()
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));

        myRigidbody2D.velocity += velocityTweak;

    }

    // Update is called once per frame
    void Update()
    {

    }


}
