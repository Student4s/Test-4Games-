using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private ItemHolder items;
    [SerializeField] private int[] countItem = new int[4];

    [SerializeField] private Text countOfItem1;
    [SerializeField] private Text countOfItem2;
    [SerializeField] private Text countOfItem3;
    [SerializeField] private Text countOfItem4;
    void Start()
    {
        items = FindObjectOfType<ItemHolder>();
        countItem[0] = items.Bombs;
        countItem[1] = items.Lightnings;
        countItem[2] = items.Hammers;
        countItem[3] = items.Dice;
        UpdateCounts();
        
    }

    void UpdateCounts()
    {
        countItem[0] = items.Bombs;
        countItem[1] = items.Lightnings;
        countItem[2] = items.Hammers;
        countItem[3] = items.Dice;

        countOfItem1.text = countItem[0].ToString();
        countOfItem2.text = countItem[1].ToString();
        countOfItem3.text = countItem[2].ToString();
        countOfItem4.text = countItem[3].ToString();
    }

    public void Additem(int itemNumber)
    {
        if(itemNumber==0)
        {
            items.AddBomb();
        } else {
            if (itemNumber == 1)
            {
                items.AddLightning();
            }
            else
            {
                if (itemNumber == 2)
                {
                    items.Addhammer();
                }
                else {
                    if (itemNumber == 3)
                    {
                        items.AddDice();
                    }
                }
            }
        }
        UpdateCounts();
    }
}
