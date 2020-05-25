using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    public event Action OnGameEnd;

    void Awake()
    {
        Debug.Log("LevelController/Awake");

        instance = this;
    }

    public void OnLevelEnd()
    {
        Debug.Log("LevelController/OnLevelEnd");

        OnGameEnd?.Invoke();
    }
}
