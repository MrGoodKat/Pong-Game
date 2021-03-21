using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefersController : MonoBehaviour
{
    const string MASTER_ENEMYSPEED_KEY = "EnemySpeed";
    const string MASTER_BALL_KEY = "BallSpeed";

    public static void SetEnemySpeed(float enemySpeed)
    {
        PlayerPrefs.SetFloat(MASTER_ENEMYSPEED_KEY, enemySpeed);
    }

    public static float GetEnemySpeed()
    {
        return PlayerPrefs.GetFloat(MASTER_ENEMYSPEED_KEY);
    }

    public static void SetBallSpeed(float ballSpeed)
    {
        PlayerPrefs.SetFloat(MASTER_BALL_KEY, ballSpeed);
    }

    public static float GetBallSpeed()
    {
        return PlayerPrefs.GetFloat(MASTER_BALL_KEY);
    }

}
