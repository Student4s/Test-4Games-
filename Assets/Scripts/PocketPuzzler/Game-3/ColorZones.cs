using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorZones : MonoBehaviour
{
    public string color;
    public bool canConnected = true;
    [SerializeField] private bool firstTime=true;// чтобы проверка происходила только 1 раз
    [SerializeField] private ColoredSquare square;

    private void Start()
    {
        Invoke("FirstTimeEnd", 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<ColorZones>() != null)
        {
            if (collision.GetComponent<ColorZones>().color !=color)
            {  
                canConnected = false;
                if(firstTime)
                {
                    square.CanStay(canConnected);
                }
                
            }
        }
    }

    void FirstTimeEnd()
    {
        firstTime = false;
    }
}
