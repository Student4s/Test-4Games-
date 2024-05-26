using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Plank;

public class Plank : MonoBehaviour
{
    [SerializeField] private List<Screw> screws;
    private Rigidbody2D rb;

    public delegate void PlankDestroyed(Plank plank);
    public static event PlankDestroyed PlankDestroy;

    private void OnEnable()
    {
        Screw.ScrewDestroy += RemoveScrew;
    }
    private void OnDisable()
    {
        Screw.ScrewDestroy -= RemoveScrew;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateScrewCount();
    }
    void UpdateScrewCount()
    {
        bool hasScrews = screws.Count > 0;

        if(!hasScrews)
        {
            rb.gravityScale = 1;
            rb.constraints = RigidbodyConstraints2D.None;
        }
        else
        {
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    public void RemoveScrew(Screw screw)
    {
        if (screws.Contains(screw))
        {
            screws.Remove(screw);
        }
        UpdateScrewCount();
    }

    private void Update()
    {
        if (gameObject.transform.position.y < -5)
        {
            PlankDestroy(gameObject.GetComponent<Plank>());
            Destroy(gameObject);
        }
    }
}
