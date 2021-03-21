using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText;
    float countdown = 5.0f;
    //Level level;
    GameSession gameSession;
    

    void Start()
    {
        //level = FindObjectOfType<Level>();
        
        gameSession = FindObjectOfType<GameSession>();

        
        HideScores();


    }

    public void HideScores()
    {
        gameSession.GetComponentInChildren<Canvas>().enabled = false;
    }

    public void ShowScores()
    {
        if (!gameSession.GetComponentInChildren<Canvas>().enabled)
        {
            gameSession.GetComponentInChildren<Canvas>().enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

        SceneTimer(gameSession.GetCurrentScene());

    }


    public void SceneTimer(int currentScene)
    {
        countdown -= Time.deltaTime;
        

        if (countdown <=1)
        {
            
            ShowScores();

            //Debug.Log(currentScene.ToString());

            if (currentScene > 0)
            {
                SceneManager.LoadScene(currentScene);
            }
            else
            {
                SceneManager.LoadScene(0);
            }

            

        }
        else
        {
            countdownText.text = Mathf.Round(countdown).ToString();
        }
        
        
    }
}
