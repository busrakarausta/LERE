using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    [Header("Data Keys")]

    [SerializeField]
    private string activeGameKey = "ActiveGameCount";

    private int _activeGameCount;


    private void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
    }

    public void SetActiveGameCount(int value=1)
    {
        _activeGameCount = value;

        PlayerPrefs.SetInt(activeGameKey, _activeGameCount);
    }

}
