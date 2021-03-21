using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int enemyScore = 0;
    [SerializeField] int playerScore = 0;
    [SerializeField] int levelScore = 10;
    [SerializeField] int generalLevelScore = 3;
    int generalEnemyScore, generalPlayerScore = 0;
    int currentScene = 0;
    

    [SerializeField] TextMeshProUGUI enemyScoreText;
    [SerializeField] TextMeshProUGUI enemyGeneralScoreText;
    [SerializeField] TextMeshProUGUI playerScoreText;
    [SerializeField] TextMeshProUGUI playerGeneralScoreText;
    Scene scene;

    [SerializeField] List<GameObject> positions;

    int startingPointIndex = 0;

    bool isPlayerWin = false;

    List<Transform> startPoints;


    public int GeneralLevelScore()
    {
        return generalLevelScore;
    }

    private void Awake()
    {
        int gameSesssionCount = FindObjectsOfType<GameSession>().Length;

        if (gameSesssionCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public int GetCurrentScene()
    {
        return currentScene;
    }

    public void isPlayerWinPoint(bool isWin)
    {
        isPlayerWin = isWin;
    }

    public bool isPlayerStart()
    {
        return isPlayerWin;
    }

    public void AddPointEnemy()
    {
        enemyScore += 1;
        enemyScoreText.text = enemyScore.ToString();
    }

    public void AddPointPlayer()
    {
        playerScore += 1;
        playerScoreText.text = playerScore.ToString();
    }


    public int GetEnemyPoint()
    {
        return enemyScore;
    }

    public int GetPlayerPoint()
    {
        return playerScore;
    }

    public int GetLevelPoint()
    {
        return levelScore;
    }

    public int GetPlayerGeneralScore()
    {
        return generalPlayerScore;
    }

    public int IncreaseGeneralPlayerScore()
    {
        generalPlayerScore++;
        playerGeneralScoreText.text = generalPlayerScore.ToString();
        return generalPlayerScore;
    }

    public int GetEnemyGeneralScore()
    {
        return generalEnemyScore;
    }

    public int IncreaseGeneralEnemyScore()
    {
        generalEnemyScore++;
        enemyGeneralScoreText.text = generalEnemyScore.ToString();
        return generalEnemyScore;
    }


    public void ResetAllGame()
    {
        playerScore = enemyScore = 0;
        generalEnemyScore = generalPlayerScore = 0;

        playerGeneralScoreText.text = enemyGeneralScoreText.text = "0";
        playerScoreText.text = enemyScoreText.text = playerScore.ToString();
    }

    public void ResetPoints()
    {
        playerScore = enemyScore = 0;
        //generalEnemyScore = generalPlayerScore = 0;

        //playerGeneralScoreText.text = enemyGeneralScoreText.text = "0";
        playerScoreText.text = enemyScoreText.text = playerScore.ToString();
    }

    public bool IsMaxPoint()
    {
        if (generalLevelScore == generalPlayerScore || generalLevelScore == generalEnemyScore)
        {
            return true;
        }

        return false;
    }

    public List<Transform> StartingPositions()
    {
        var positionPoints = new List<Transform>();

        foreach (var item in positions)
        {
            positionPoints.Add(item.transform);
        }

        return positionPoints;
    }

    public Vector3 StartingBallPosition()
    {

        Ball ball = FindObjectOfType<Ball>();

        startPoints = StartingPositions();

        ball.transform.position = startPoints[startingPointIndex].transform.position;

        

        if (startingPointIndex < startPoints.Count - 1)
        {
            startingPointIndex++;
        }
        else
        {
            startingPointIndex = 0;
        }

        return ball.transform.position;
    }

}
