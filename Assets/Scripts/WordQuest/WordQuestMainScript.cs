using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordQuestMainScript : MonoBehaviour
{
    [SerializeField] private List<string> dictionary;//загаданные слова
    [SerializeField] private List<GameObject> words;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject playField;

    public void CheckWord(string word)
    {
        if(dictionary.Contains(word))
        {
            words[dictionary.IndexOf(word)].SetActive(true);
            if(CheckList())
            {
                Win();
            }
        }
    }
     bool CheckList()
    {
        foreach(GameObject word in words)
        {
            if(!word.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    void Win()
    {
        playField.SetActive(false);
        winPanel.SetActive(true);
    }
}
