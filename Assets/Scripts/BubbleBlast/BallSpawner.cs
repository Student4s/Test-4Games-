using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private BallController[] balls;
    [SerializeField] private BallController currentBall;


    private void Update()
    {
        if(currentBall == null)
        {
            Spawn();
        }
    }
    void SpawnNewBall()
    {
        Invoke("Spawn", 0.5f) ;// костыль для бага с молнией - новый шарик спаунился не в том месте
    }    
    void Spawn()
    {
        System.Random random = new System.Random();
        BallController newBall = Instantiate(balls[random.Next(0, balls.Length)], transform.position, transform.rotation);
        currentBall = newBall;
    }

}
