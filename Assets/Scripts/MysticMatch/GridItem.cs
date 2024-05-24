using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridItem : MonoBehaviour
{
    public string ItemName;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    [SerializeField] private Color selectedColor;
    public List <GridItem> connectedItem;
    public bool isSelected= false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void Select()
    {
        spriteRenderer.color = selectedColor;
        isSelected = true;
    }

    public void Deselect()
    {
        spriteRenderer.color = originalColor;
        isSelected = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ItemCore>() != null)
        {
            if (!connectedItem.Contains(collision.GetComponent<ItemCore>().item))
            {
                connectedItem.Add(collision.GetComponent<ItemCore>().item);
            }
        }
    }

    public void DestroyMyself()
    {
        Destroy(gameObject);
    }
}
