using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private List<BasicSquares> squares;
    [SerializeField] private List<ColoredSquare> squaresToMove;// те, которые выставляем на поле
    [SerializeField] private int currentId;//Изначально равен 11, чтобы нельзя было сходу ставить тайлы

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject playField;

    bool CheckList()
    {
        bool check = true;
        foreach (BasicSquares square in squares)
        {
            if (!square.IsOccupated)
            {
                return false;
            }
        }
        return check;
    }

    void PlusOneSquare()
    {

        bool isWin = CheckList();

        if (isWin)
        {
            playField.SetActive(false);
            winPanel.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider = Physics2D.OverlapPoint(mousePos);

            if (collider != null && collider.GetComponent<ColoredSquare>()!=null) // выбор что ставить
            {
                currentId= collider.GetComponent<ColoredSquare>().squareId;
            }

            if (collider != null && collider.GetComponent<BasicSquares>() != null) // выбор куда ставить
            {
                if(!collider.GetComponent<BasicSquares>().IsOccupated&& currentId!=11)
                {
                    collider.GetComponent<BasicSquares>().Occupated(squaresToMove[currentId]);
                    PlusOneSquare();
                }
            }
        }
    }
}
