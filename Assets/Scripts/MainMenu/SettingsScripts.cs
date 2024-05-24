using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScripts : MonoBehaviour
{
    [SerializeField] private GameObject redSoundButton;
    [SerializeField] private GameObject greenSoundButton;
    [SerializeField] private GameObject redMusicButton;
    [SerializeField] private GameObject greenMusicButton;

    private bool sound;
    private bool music;
    void Start()
    {
        sound = true;   
        music = true;
    }


    public void ChangeSound()
    {
        if (sound)
        {
            redSoundButton.SetActive(true);
            greenSoundButton.SetActive(false);
            sound = false;
        }
        else
        {
            redSoundButton.SetActive(false);
            greenSoundButton.SetActive(true);
            sound = true; ;
        }
    }
    public void ChangeMusic()
    {
        if (music)
        {
            redMusicButton.SetActive(true);
            greenMusicButton.SetActive(false);
            music = false;
        }
        else
        {
            redMusicButton.SetActive(false);
            greenMusicButton.SetActive(true);
            music = true;
        }
    }
}
