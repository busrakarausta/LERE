using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [Header("References")]

    [SerializeField]
    private UIManager uiManager;

    private int _activeSceneIndex=0;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        uiManager.OnClickChildButton += LoadGamesScene;
        uiManager.OnClickParentButton += LoadParentControlScene;
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
