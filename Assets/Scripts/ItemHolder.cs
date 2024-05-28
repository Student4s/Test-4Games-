using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour// ����� ��������� ������� ���������� ������ �� ������ ������
{
    public int Bombs;
    public int Hammers;
    public int Lightnings;
    public int Dice;

    private static ItemHolder instance;


    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddBomb()
    {
        Bombs += 1;
    }
    public void Addhammer()
    {
        Hammers += 1;
    }
    public void AddLightning()
    {
        Lightnings += 1;
    }
    public void AddDice()
    {
        Dice += 1;
    }
}
