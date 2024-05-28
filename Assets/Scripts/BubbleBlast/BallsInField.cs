using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallsInField : MonoBehaviour
{
    public string colorName;
    public bool isPop = false;

    [SerializeField] private List<GameObject> ballsInTriggerZone;

    public delegate void BallDestroyed();
    public static event BallDestroyed BallDestroy;

    public delegate void AddToList(GameObject ball);
    public static event AddToList AddThis;

    private void Start()
    { 
        if(colorName!= "rock")
        {
            AddThis(gameObject);
        }
        
    }
    public void Pop()
    {
        isPop = true;
        foreach (GameObject obj in ballsInTriggerZone)
        {
            if(obj!=null)
            {
                if (!obj.GetComponent<BallsInField>().isPop && obj.GetComponent<BallsInField>().colorName == colorName)
                {
                    obj.GetComponent<BallsInField>().Invoke("Pop",0.01f);
                }
            }
        }
        BallDestroy();
        Destroy(gameObject,0.02f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BallController>() != null)
        {
            if (collision.GetComponent<BallController>().colorName == colorName)
            {
                Pop();
            }
                collision.GetComponent<BallController>().DestroyIt();

        }

        if (collision.GetComponent<BallsInField>() != null)
        {
            ballsInTriggerZone.Add(collision.gameObject);
        }

    }

}
