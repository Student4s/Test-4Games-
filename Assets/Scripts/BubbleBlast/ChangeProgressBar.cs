using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeProgressBar : MonoBehaviour
{
    [SerializeField] private GameObject progress1;
    [SerializeField] private GameObject star1;
    [SerializeField] private GameObject progress2;
    [SerializeField] private GameObject star2;
    [SerializeField] private GameObject progress3;
    [SerializeField] private GameObject star3;

    [SerializeField] private int[] countsToChangeProgress;// при каких очках мы даем звездочки

    void Start()
    {

    }

    // Update is called once per frame
    public void UpdateProgress(int count)
    {

        if (count > countsToChangeProgress[0])
        {
            progress1.SetActive(true);
            star1.SetActive(false);
        }

        if (count > countsToChangeProgress[1])
        {
            progress2.SetActive(true);
            star2.SetActive(false);
        }
        if (count > countsToChangeProgress[2])
        {
            progress3.SetActive(true);
            star3.SetActive(false);
        }

    }
}
