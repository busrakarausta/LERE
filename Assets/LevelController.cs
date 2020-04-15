using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField]
    private AppleManager appleGame;
    [SerializeField]
    private RabbitController rabbitGame;

    void Awake()
    {
        appleGame.OnLevelEnd += OnLevelEnd;
        rabbitGame.OnLevelEnd += OnLevelEnd;
    }

    private void OnLevelEnd()
    {
        Debug.Log("LevelEnd");
    }
}
