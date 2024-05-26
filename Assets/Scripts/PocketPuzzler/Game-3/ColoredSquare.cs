using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredSquare : MonoBehaviour
{
    public BasicSquares BasicSquare;
    public int squareId;

    public void CanStay(bool isCan)
    {
        if(!isCan)
        {
            BasicSquare.IsOccupated = false;
            BasicSquare.occupatedSquare = null;
            Destroy(gameObject);
        }
    }
}
