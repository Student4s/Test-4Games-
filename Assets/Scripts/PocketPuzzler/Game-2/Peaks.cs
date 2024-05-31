using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Peaks : MonoBehaviour
{
    [SerializeField] private Color selectedColor = Color.red;
    private SpriteRenderer spriteRenderer;
    public List<Peaks> connectedPeaks;
    public List<GameObject> connectionLines;

    public bool IsSelected = false;

    public delegate void SelectThisPeak(Peaks peak);
    public static event SelectThisPeak SelectedPeak;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider = Physics2D.OverlapPoint(mousePos);

            if (collider != null && collider.gameObject == gameObject && !IsSelected)
            {
                SelectedPeak(gameObject.GetComponent<Peaks>());
            }
                
        }
    }

    public void SetSelectedColor()
    {
        spriteRenderer.color = selectedColor;
        IsSelected = true;
    }
}
