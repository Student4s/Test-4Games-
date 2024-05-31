using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItems : MonoBehaviour
{
    [SerializeField] private List<GridItem> selectedItems;
    [SerializeField] private List<GridItem> allItems;
    [SerializeField] private LayerMask selectableLayer;

    public delegate void ThreeMatch(int count);
    public static event ThreeMatch Match;

    private bool isHammer = false;
    [SerializeField] private MysticHammer hammer;

    private void OnEnable()
    {
        GridItem.Add += AddToList;
        MysticMatchMainScript.Hammer += UseHammer;
    }
    private void OnDisable()
    {
        GridItem.Add -= AddToList;
        MysticMatchMainScript.Hammer -= UseHammer;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isHammer)
        {
            DeleteNullItem();
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, selectableLayer);

            if (hit.collider.GetComponent<ItemCore>() != null)
            {
                
                GridItem selectItems = hit.collider.GetComponent<ItemCore>().item;
                if (selectItems != null)
                {
                    if (isSelected(selectItems))
                    {
                        selectItems.Select();// подкрашиваем выбранный предмет
                        selectedItems.Add(selectItems);
                        if (selectedItems.Count == 3)// если собралось 3 в ряд - удаляем
                        {
                            foreach (GridItem item in selectedItems)
                            {
                               item.GetComponent<GridItem>().DestroyMyself();
                            }
                            selectedItems.Clear();
                            DeleteNullItem();
                            Match(1);
                        }
                    }
                    else
                    {
                        foreach (GridItem item in allItems)
                        {
                            item.Deselect();
                            selectedItems.Clear();
                        }
                        DeleteNullItem();
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(0) && isHammer)// Use Hammer
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, selectableLayer);

            if (hit.collider.GetComponent<ItemCore>() != null)
            {
                hammer.itemName = hit.collider.GetComponent<ItemCore>().item.ItemName;
                Instantiate(hammer, hit.collider.gameObject.transform.position, hit.collider.gameObject.transform.rotation);

                foreach (GridItem item in allItems)
                {
                    item.Deselect();
                    selectedItems.Clear();
                }
                isHammer = false;
            }
        }
    }

    bool isSelected(GridItem item)// проверка на нахождение в одной плоскости + чтобы это был один тип предметов
    {
        bool answer = true;

        foreach (GridItem item2 in selectedItems)
        {
            if (!item2.connectedItem.Contains(item) || item.ItemName != item2.ItemName || selectedItems.Contains(item))
            {
                return false;
            }
        }
        return answer;
    }

    public void UseHammer()
    {
        isHammer = true;
    }

    public void AddToList(GridItem item)
    {
        allItems.Add(item);
    }

    void DeleteNullItem()
    {
        allItems.RemoveAll(item => item == null);
    }


}
