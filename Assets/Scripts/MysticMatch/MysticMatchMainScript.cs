using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
//using static UnityEditor.Progress;

public class MysticMatchMainScript : MonoBehaviour
{
    [SerializeField] private ItemHolder items;

    [SerializeField] private int scores;
    [SerializeField] private int maxScores;
    [SerializeField] private int countOfHammers;

    [SerializeField] private Text score;
    [SerializeField] private Text numbOfHammers;

    [SerializeField] private ChangeProgressBar progressBar;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject playField;

    public delegate void SetHammer();
    public static event SetHammer Hammer;

    private void OnEnable()
    {
        SelectItems.Match += ChangeScore;
        MysticHammer.Match += ChangeScore;
    }
    private void OnDisable()
    {
        SelectItems.Match -= ChangeScore;
        MysticHammer.Match -= ChangeScore;
    }
    private void Start()
    {
        UpdateCounts();
        items = FindObjectOfType<ItemHolder>();
        countOfHammers = items.Hammers;
        UpdateCounts();
    }
    public void UploadHammer()
    {
        if (countOfHammers >= 1)
        {
            Hammer();
            countOfHammers -= 1;
            items.Hammers -= 1;
            UpdateCounts();
        }
    }

    void UpdateCounts()
    {
        score.text = scores.ToString();
        numbOfHammers.text = countOfHammers.ToString();
    }

    public void ChangeScore(int count)
    {
        scores += count;
        UpdateCounts();
        progressBar.UpdateProgress(scores);

        if (scores >= maxScores)
        {
            Win();
        }
    }
    void Win()
    {
        progressBar.gameObject.SetActive(false);
        playField.SetActive(false);
        winPanel.SetActive(true);
    }
}
