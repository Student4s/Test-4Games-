using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BlastBubblesMainScipt;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ballRigidbody;
    [SerializeField] private float launchForceMultiplier = 10f; // Коэффициент силы запуска
    [SerializeField] private float maxLineLength = 5f; // Максимальная длина линии

    private Vector2 touchStartPosition;
    private Vector2 touchEndPosition;
    private bool isDragging = false;
    private LineRenderer lineRenderer;


    public delegate void BallDestroyed();
    public static event BallDestroyed BallDestroy;

    public bool isBomb=false;
    public bool isLightning = false;
    [SerializeField] private Bomb bomb;
    [SerializeField] private Lightning lightning;
    public string colorName;

    private void OnEnable()
    {
        BlastBubblesMainScipt.Bomb += SetBomb;
        BlastBubblesMainScipt.Lightning += SetLightning;
    }

    private void OnDisable()
    {
        BlastBubblesMainScipt.Bomb -= SetBomb;
        BlastBubblesMainScipt.Lightning -= SetLightning;
    }
    void Start()
    {
        // Инициализация LineRenderer
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        HandleMouseInput();
#else
            HandleTouchInput();
#endif
        if (gameObject.transform.position.y>5)
        {
            DestroyIt();
        }

    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging = true;
                touchStartPosition = mousePosition;
                lineRenderer.enabled = true; // Включаем линию при оттягивании
            }
        }

        if (isDragging)
        {
            if (Input.GetMouseButton(0))
            {
                touchEndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                UpdateTrajectoryLine();
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                LaunchBall();
                lineRenderer.enabled = false; // Выключаем линию после запуска шарика
            }
        }
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

                    if (hit.collider != null && hit.collider.gameObject == gameObject)
                    {
                        isDragging = true;
                        touchStartPosition = touchPosition;
                        lineRenderer.enabled = true; // Включаем линию при оттягивании
                    }
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        touchEndPosition = Camera.main.ScreenToWorldPoint(touch.position);
                        UpdateTrajectoryLine();
                    }
                    break;

                case TouchPhase.Ended:
                    if (isDragging)
                    {
                        isDragging = false;
                        LaunchBall();
                        lineRenderer.enabled = false; // Выключаем линию после запуска шарика
                    }
                    break;
            }
        }
    }

    void LaunchBall()
    {
        Vector2 direction = touchStartPosition - touchEndPosition;
        ballRigidbody.AddForce(direction * launchForceMultiplier, ForceMode2D.Impulse);
    }

    void UpdateTrajectoryLine()
    {
        Vector2 direction;
        float distance;

        if (isDragging)
        {
            direction = touchStartPosition - touchEndPosition;
            distance = Mathf.Min(direction.magnitude, maxLineLength);
        }
        else
        {
            direction = Vector2.up;
            distance = maxLineLength;
        }

        direction = direction.normalized * distance;

        // Начальная позиция линии
        Vector2 lineStart = ballRigidbody.position;
        Vector2 lineEnd = lineStart + direction;

        // Устанавливаем позиции начала и конца линии
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, lineStart);
        lineRenderer.SetPosition(1, lineEnd);

    }

    public void DestroyIt()
    {
        if(isBomb)
        {
            Instantiate(bomb, transform.position, transform.rotation);
            isBomb = false;
        }
        if(isLightning)
        {
            var light = Instantiate(lightning, transform.position, transform.rotation);
            light.color = colorName;
            isLightning = false;
        }
        Destroy(gameObject);
        BallDestroy();
    }

    public void SetBomb()
    {
        isBomb = true;
    }

    public void SetLightning()
    {
        isLightning = true;
    }
}