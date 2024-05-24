using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
   [SerializeField] private GameObject mainScreen;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject ratingsScreen;
    [SerializeField] private GameObject shopScreen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToSettings()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }
    public void GoToRatings()
    {
        mainScreen.SetActive(false);
        ratingsScreen.SetActive(true);
    }
    public void GoToShop()
    {
        mainScreen.SetActive(false);
        shopScreen.SetActive(true);
    }
    public void GoToMain()
    {
        mainScreen.SetActive(true);
        settingsScreen.SetActive(false);
        ratingsScreen.SetActive(false);
        shopScreen.SetActive(false);
    }
}
