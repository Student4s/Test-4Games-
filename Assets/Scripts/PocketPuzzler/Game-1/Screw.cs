using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Screw;

public class Screw : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float lifeTime;
    [SerializeField] private bool isRotating = false;

    [SerializeField] private GameObject[] fallScrews;
    public delegate void ScrewDestroyed(Screw screw);
    public static event ScrewDestroyed ScrewDestroy;

    private void Start()
    {
        System.Random random = new System.Random();
        lifeTime = random.Next(1, 3);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider = Physics2D.OverlapPoint(mousePos);

            if (collider != null && collider.gameObject == gameObject)
            {
                isRotating = true;
            }
            else
            {
                isRotating = false;
            }
        }
        else
        {
            isRotating = false;
        }

        Ratating();
        if (lifeTime <= 0)
        {
            DestroyItself();
        }
    }
    void DestroyItself()
    {
        System.Random random = new System.Random();

        ScrewDestroy(gameObject.GetComponent<Screw>());
        Instantiate(fallScrews[random.Next(0, fallScrews.Length)], transform.position, transform.rotation);
        Destroy(gameObject);
    }
    void Ratating()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            lifeTime -= Time.deltaTime;
        }
    }
}
