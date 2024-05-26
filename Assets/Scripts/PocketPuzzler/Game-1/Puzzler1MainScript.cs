using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class Puzzler1MainScript : MonoBehaviour
{
    [SerializeField] private List<Plank> planks;
    [SerializeField] private int scores;

    [SerializeField] private ChangeProgressBar progressBar;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject playField;

    private void OnEnable()
    {
        Plank.PlankDestroy += RemovePlank;
    }
    private void OnDisable()
    {
        Plank.PlankDestroy -= RemovePlank;
    }

    void RemovePlank(Plank plank)
    {
        if (planks.Contains(plank))
        {
            planks.Remove(plank);
        }
        UpdatePlankCount();
    }

   void UpdatePlankCount()
    {
        bool hasPlank = planks.Count > 0;
        scores += 1;
        progressBar.UpdateProgress(scores);

        if(!hasPlank)
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
