using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysticHammer : MonoBehaviour
{
    public string itemName;

    public delegate void HammerMatch(int score);
    public static event HammerMatch Match;
    private void Start()
    {
        Match(3);
        Destroy(gameObject, 2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ItemCore>() != null)
        {
            if (collision.GetComponent<ItemCore>().item.ItemName == itemName)
            {
                collision.GetComponent<ItemCore>().item.DestroyMyself();
            }
        }
    }
}
