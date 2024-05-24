using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatingScript : MonoBehaviour
{
    [SerializeField] private Text name1;
    [SerializeField] private Text score1;
    [SerializeField] private Text name2;
    [SerializeField] private Text score2;
    [SerializeField] private Text name3;
    [SerializeField] private Text score3;

    private int scores1;
    private int scores2;
    private int scores3;
    void Start()
    {
        scores1 = int.Parse(score1.text);
        scores2 = int.Parse(score2.text);
        scores3 = int.Parse(score3.text);
    }

    public void AddNewScore(string name, int score)
    {
        if(score> scores1)
        {
            name1.text = name;
            score1.text = score.ToString();
        }
        else
        {
            if (score > scores2)
            {
                name2.text = name;
                score2.text = score.ToString();
            }
                else
                    {
                        if (score > scores3)
                {
                    name3.text = name;
                    score3.text = score.ToString();
                }
                    }
        }
    }
}
