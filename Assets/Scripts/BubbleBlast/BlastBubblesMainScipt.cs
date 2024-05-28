using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class BlastBubblesMainScipt : MonoBehaviour
{
    [SerializeField] private ItemHolder items;

    [SerializeField] private int ballUse;// в теории может понадобится, но пока не придумал как
    [SerializeField] private int scores;
    [SerializeField] private int maxScores;
    [SerializeField] private int countOfBombs;
    [SerializeField] private int countOfLightnings;

    [SerializeField] private Text score;
    [SerializeField] private Text numbOfBomb;
    [SerializeField] private Text numbOfLightnings;

    [SerializeField] private ChangeProgressBar progressBar;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject playField;

    [SerializeField] private List<GameObject> allBallsInField;

    public delegate void SetBomb();
    public static event SetBomb Bomb;

    public delegate void SetLightning();
    public static event SetLightning Lightning;
    void OnEnable()
    {
        BallController.BallDestroy += ChangeCountOfUse;
        BallsInField.BallDestroy += ChangeScore;
        BallsInField.AddThis += AddBallToList; ;

    }
    void OnDisable()
    {
        BallController.BallDestroy -= ChangeCountOfUse;
        BallsInField.BallDestroy -= ChangeScore;
        BallsInField.AddThis -= AddBallToList; ;
    }


    private void Update()//нужный костыль, увы
    {
        if (CheckList())
        {
            Win();
        }
    }

    private void Start()
    {
        UpdateCounts();
        items = FindObjectOfType<ItemHolder>();
        countOfBombs = items.Bombs;
        countOfLightnings = items.Lightnings;
        UpdateCounts();

    }

    public void UploadBomb()
    {
        if (countOfBombs >= 1)
        {
            Bomb();
            countOfBombs -= 1;
            items.Bombs -= 1;
            UpdateCounts();
        }
    }

    public void UploadLightning()
    {
        if (countOfLightnings >= 1)
        {
            Lightning();
            countOfLightnings -= 1;
            items.Lightnings -= 1;
            UpdateCounts();
        }
    }

    public void ChangeCountOfUse()
    {
        ballUse += 1;
    }

    public void ChangeScore()
    {
        scores += 1;
        UpdateCounts();
        progressBar.UpdateProgress(scores);

        if (CheckList())
        {
            Win();
        }
    }
    public void SetCountOfBallsInField(int count)
    {
        scores = count;
        UpdateCounts();
    }

    void Win()
    {
        progressBar.gameObject.SetActive(false);
        playField.SetActive(false);
        winPanel.SetActive(true);
    }
   

    void UpdateCounts()
    {
        score.text = scores.ToString();
        numbOfBomb.text = countOfBombs.ToString();
        numbOfLightnings.text = countOfLightnings.ToString();
    }

    bool CheckList()
    {
        allBallsInField.RemoveAll(item => item == null);
        if (allBallsInField.Count > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void AddBallToList(GameObject ball)
    {
        allBallsInField.Add(ball);
    }
}
