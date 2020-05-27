using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementManager : MonoBehaviour
{
    public static AchivementManager instance;
    [SerializeField]
    private int[] letterEducationMinMove;
    [SerializeField]
    private int[] numberEducationMinMove;
    [SerializeField]
    private int[] colorEducationMinMove;
    [SerializeField]
    private int timeMaxAttempt = 3;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    public int GetEducationRate(int status, int index)
    {
        int rate = DataManager.instance.GetEducationRate(status, index);
        return rate;

    }
    public int GetTestRate(int status, int index)
    {
        int rate = DataManager.instance.GetTestRate(status, index);
        return rate;
    }

    public void SetEducationAttempt(int status, int index, int attemptAmount)
    {
        int rate=0;

        if (status == 0)
        {
            rate = (100 * letterEducationMinMove[index]) / attemptAmount;

            Debug.Log(rate);
        }
        else if (status == 1)
        {
            rate = (100 * numberEducationMinMove[index]) / attemptAmount;
        }
        else if (status == 2)
        {
            rate = (100 * colorEducationMinMove[index]) / attemptAmount;
        }

        DataManager.instance.SetEducationRate(status,index, rate);
    }
    public void SetTestAttempt(int status, int index, int attemptAmount)
    {
        int rate = 100 / attemptAmount;

        DataManager.instance.SetTestRate(status, index, rate);
    }
}
