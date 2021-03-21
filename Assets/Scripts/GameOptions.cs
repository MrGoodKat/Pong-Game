using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOptions : MonoBehaviour
{
    public void EasyButton()
    {
        PlayerPrefersController.SetEnemySpeed(9f);
        PlayerPrefersController.SetBallSpeed(9f);
        SceneManager.LoadScene("Level 1");
    }

    public void NormalButton()
    {
        PlayerPrefersController.SetEnemySpeed(18f);
        PlayerPrefersController.SetBallSpeed(16f);
        SceneManager.LoadScene("Level 1");
    }
    public void HardButton()
    {
        PlayerPrefersController.SetEnemySpeed(25f);
        PlayerPrefersController.SetBallSpeed(20f);
        SceneManager.LoadScene("Level 1");
    }
}
