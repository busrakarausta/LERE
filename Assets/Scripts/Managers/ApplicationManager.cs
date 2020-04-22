using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour
{
    public static ApplicationManager instance;

    private int _activeSceneIndex=0;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    public void LoadHomeScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGamesScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadParentControlScene()
    {
        SceneManager.LoadScene(2);
    }
}
