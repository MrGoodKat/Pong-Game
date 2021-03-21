using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    float yPos;
    Vector2 paddlePos;

    [SerializeField] float minY = 1f;
    [SerializeField] float maxY = 10f;

    [SerializeField] bool autoPlay;
    float computerPaddleSpeed = 1f;
    Vector3 newPos;

    void Update()
    {
        computerPaddleSpeed = PlayerPrefersController.GetEnemySpeed();
        
        PaddleControl();
    }

    private void ComputerPaddleControl()
    {
        Vector2 ballPosition = FindObjectOfType<Ball>().transform.position;
        

        if (ballPosition.y < transform.position.y)
        {

            //transform.position += new Vector3(0f, -computerPaddleSpeed * Time.deltaTime, 0f);
            
            transform.position += new Vector3(0f, -computerPaddleSpeed * Time.deltaTime, 0f);
            paddlePos = new Vector2(transform.position.x, transform.position.y);
            paddlePos.y = Mathf.Clamp(transform.position.y, minY, maxY);
            transform.position = paddlePos;

        }

        if (ballPosition.y > transform.position.y)
        {
            //transform.position += new Vector3(0f, computerPaddleSpeed * Time.deltaTime, 0f);

            transform.position += new Vector3(0f, computerPaddleSpeed * Time.deltaTime, 0f);
            paddlePos = new Vector2(transform.position.x, transform.position.y);
            paddlePos.y = Mathf.Clamp(transform.position.y, minY, maxY);
            transform.position = paddlePos;

        }
        

    }

    private void PaddleControl()
    {

        if (isAutoPlayEnabled())
        {
            ComputerPaddleControl();
        }
        else
        {
            yPos = Input.mousePosition.y / Screen.height * 12f;
            paddlePos = new Vector2(transform.position.x, transform.position.y);
            paddlePos.y = Mathf.Clamp(yPos, minY, maxY);
            transform.position = paddlePos;
        }

    }


    private bool isAutoPlayEnabled()
    {
        return autoPlay;
    }

    

    
}
