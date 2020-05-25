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
    private int testMinAttempt =3;

    private int[] lettersEducationAttempt;
    private int[] colorsEducationAttempt;
    private int[] numbersEducationAttempt;


    private int[] lettersTestAttempt;
    private int[] colorsTestAttempt;
    private int[] numbersTestAttempt;

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
            lettersEducationAttempt[index] = attemptAmount;
            rate = (100 * letterEducationMinMove[index]) / attemptAmount;
        }
        else if (status == 1)
        {
            numbersEducationAttempt[index] = attemptAmount;
            rate = (100 * numberEducationMinMove[index]) / attemptAmount;
        }
        else if (status == 2)
        {
            colorsEducationAttempt[index] = attemptAmount;
            rate = (100 * colorEducationMinMove[index]) / attemptAmount;
        }

        DataManager.instance.SetEducationRate(status, rate, index);
    }
    public void SetTestAttempt(int status, int index, int attemptAmount)
    {
        int rate = 0;

        if (status == 0)
        {
            lettersTestAttempt[index] = attemptAmount;
            rate = (100 * testMinAttempt) / attemptAmount;
        }
        else if (status == 1)
        {
            numbersTestAttempt[index] = attemptAmount;
            rate = (100 * testMinAttempt) / attemptAmount;
        }
        else if (status == 2)
        {
            colorsTestAttempt[index] = attemptAmount;
            rate = (100 * testMinAttempt) / attemptAmount;
        }

        DataManager.instance.SetTestRate(status, rate, index);
    }
}
