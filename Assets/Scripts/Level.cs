using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level : MonoBehaviour
{
    int currentScene = 0;
    [SerializeField] float sceneDelay = 5f;
    [SerializeField] TextMeshProUGUI endgameTitle;
    [SerializeField] AudioClip gameSound;

    GameSession gameSession;
    
    Scene scene;
    

    private void Awake()
    {
        //int gameSesssionCount = FindObjectsOfType<GameSession>().Length;

        //if (gameSesssionCount > 1)
        //{
        //    //Destroy(gameObject);
        //    Destroy(FindObjectOfType<GameSession>().gameObject);
        //}
        //else
        //{
        //    DontDestroyOnLoad(FindObjectOfType<GameSession>().gameObject);
        //}
    }


    public void GameSituation()
    {
        if (SceneManager.GetActiveScene().name == "EndGame")
        {
            // mantık hatasını düzelt
            //Debug.Log("Player Final Score : " + gameSession.GetPlayerGeneralScore());
            //Debug.Log("Enemy Final Score : " + gameSession.GetEnemyGeneralScore());
            //Debug.Log("All Level : " + gameSession.GeneralLevelScore());

            if (gameSession.GetPlayerGeneralScore() == gameSession.GeneralLevelScore())
            {
                AudioSource.PlayClipAtPoint(gameSound, Camera.main.transform.position, 1f);
                gameSession.ResetAllGame();
                gameSession.GetComponentInChildren<Canvas>().enabled = false;
                endgameTitle.text = "You've Won!";
                endgameTitle.color = Color.green;
            }
            else if (gameSession.GetPlayerGeneralScore() == gameSession.GetEnemyGeneralScore() && gameSession.GetEnemyGeneralScore() < gameSession.GeneralLevelScore())
            {
                LoadCurrentLevelAgain(gameSession.GetCurrentScene());
            }
            else
            {
                AudioSource.PlayClipAtPoint(gameSound, Camera.main.transform.position, 1f);
                gameSession.ResetAllGame();
                gameSession.GetComponentInChildren<Canvas>().enabled = false;
                endgameTitle.text = "Game Over.";
                endgameTitle.color = Color.red;
            }

        }
    }

    private void Update()
    {
        
    }

    // Menu Start Game Button
    public void StartNewGame()
    {
        //SceneManager.LoadScene(currentScene + 1);
        SceneManager.LoadScene("SelectEnemyLevel");
    }

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        //scene = SceneManager.GetActiveScene();
        
        //print(scene.name);

        //if (scene.name == "EndGame")
        //{
        //    ResetPoints();
        //    GetComponentInChildren<Canvas>().enabled = false;
        //}
        //else
        //{
        //    if (!GetComponentInChildren<Canvas>().enabled)
        //    {
        //        GetComponentInChildren<Canvas>().enabled = true;
        //    }
        //}

        //ShowScores();
        GameSituation();

        //Debug.Log(scene.name);

        


    }

    public void LoadLevelAgain()
    {
        SceneManager.LoadScene(currentScene);
    }


    public void LoadCurrentLevelAgain(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }


    public IEnumerator LoadLevelScene()
    {   
        yield return new WaitForSeconds(sceneDelay);
        LoadLevelAgain();

    }


    


    public int GetCurrentSceneIndex()
    {
        return currentScene;
    }

    

    public IEnumerator LounchGame()
    {
        yield return new WaitForSeconds(sceneDelay);

    }


   

    


}
