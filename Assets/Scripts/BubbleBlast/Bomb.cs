using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float radius;
    
    void Start()
    {
        GetComponent<CircleCollider2D>().radius = radius;
        Destroy(gameObject, 0.05f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BallsInField>() != null)
        {
            collision.GetComponent<BallsInField>().Pop();
        }
    }
}
