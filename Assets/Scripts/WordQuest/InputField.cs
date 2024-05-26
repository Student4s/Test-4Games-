using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    [SerializeField] private WordQuestMainScript mainScript;
    [SerializeField] private string word;
    [SerializeField] private Text inputField;

    public void AddLetter(string letter)
    {
        word+= letter;
        inputField.text = word;
    }

    public void InputWord()
    {
        mainScript.CheckWord(word);
        RemoveAll();
    }

    public void RemoveAll()
    {
        word = null;
        inputField.text = word;
    }
}
