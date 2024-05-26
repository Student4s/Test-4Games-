using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSquares : MonoBehaviour
{
    public bool IsOccupated=false;
    public ColoredSquare occupatedSquare;

    public void Occupated(ColoredSquare square)
    {
        occupatedSquare = square;
        IsOccupated = true;
        square.BasicSquare = this;
        Quaternion rotation = square.transform.rotation;
        ColoredSquare instantiated= Instantiate(square, transform.position, rotation);
        instantiated.transform.SetParent(this.transform);// нужно чтобы объекты не висели при вызове победной панели
        instantiated.BasicSquare = this;
    }

    void UpdateInfo()
    {
        if (occupatedSquare==null)
        {
            IsOccupated = false;
        }
    }
}
