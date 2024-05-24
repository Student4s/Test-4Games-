using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public string color;

    void Start()
    {
        Destroy(gameObject, 0.1f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BallsInField>() != null)
        {
            if(collision.GetComponent<BallsInField>().colorName == color)
            {
                collision.GetComponent<BallsInField>().Pop();
            } 
        }
    }
}
