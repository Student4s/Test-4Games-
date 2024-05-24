using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
