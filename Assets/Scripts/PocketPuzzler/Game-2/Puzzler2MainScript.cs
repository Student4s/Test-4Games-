using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzler2MainScript : MonoBehaviour
{
    [SerializeField] private ChangeProgressBar progressBar;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject playField;

    private void OnEnable()
    {
        Graph.PeaksDone += Win;
    }
    private void OnDisable()
    {
        Graph.PeaksDone -= Win;
    }

    void Win()
    {
        progressBar.gameObject.SetActive(false);
        playField.SetActive(false);
        winPanel.SetActive(true);
    }
}
