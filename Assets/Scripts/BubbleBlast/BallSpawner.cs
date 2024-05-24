using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private BallController[] balls;

    void OnEnable()
    {
        BallController.BallDestroy += SpawnNewBall;
    }

    void SpawnNewBall()
    {
        Invoke("Spawn", 0.5f) ;// ������� ��� ���� � ������� - ����� ����� ��������� �� � ��� �����
    }    
    void Spawn()
    {
        System.Random random = new System.Random();
        Instantiate(balls[random.Next(0, balls.Length)], transform.position, transform.rotation);
    }

    void OnDisable()
    {
        BallController.BallDestroy -= SpawnNewBall;
    }
}
