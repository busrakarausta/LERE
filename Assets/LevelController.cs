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
        instance = this;
    }

    public void OnLevelEnd()
    {
        OnGameEnd?.Invoke();
    }
}
