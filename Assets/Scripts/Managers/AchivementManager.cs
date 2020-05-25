﻿using System.Collections;
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
    private int[] colorEducationMaxMove;
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

    public void GetEducationRate(int status, int index)
    {
        if(status == 0)
        {

        }
        else if(status == 1)
        {

        }
        else if(status == 2)
        {

        }
    }
    public void GetTestRate(int status, int index)
    {
        //letter
        if (status == 0)
        {

        }
        //color
        else if (status == 1)
        {

        }
        //number
        else if (status == 2)
        {

        }
    }


    public int SetEducationAttempt(int status, int index, int attemptAmount)
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
            rate = (100 * numbersEducationAttempt[index]) / attemptAmount;
        }
        else if (status == 2)
        {
            colorsEducationAttempt[index] = attemptAmount;
            rate = (100 * colorsEducationAttempt[index]) / attemptAmount;
        }

        return rate;
    }
    public void SetTestAttempt(int status, int index, int attemptAmount)
    {
        if (status == 0)
        {
            lettersTestAttempt[index] = attemptAmount;
        }
        else if (status == 1)
        {
            numbersTestAttempt[index] = attemptAmount;
        }
        else if (status == 2)
        {
            colorsTestAttempt[index] = attemptAmount;
        }
    }
}