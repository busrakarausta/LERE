using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("References")]

    [SerializeField]
    private GameManager gameManager;

    [Header("Canvas Elements")]

    [SerializeField]
    private GameObject mainCanvas;
    [SerializeField]
    private GameObject mainScreenPanel;

    private int _activeSceneIndex=0;

    public event Action OnClickParentButton;
    public event Action OnClickChildButton;

    //Click Events
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void OnClickParentControl()
    {
        //Goto parent panel
        OnClickParentButton?.Invoke();
    }

    public void OnClickChildGames()
    {
        //Go to child Games
        OnClickChildButton?.Invoke();
    }

}
