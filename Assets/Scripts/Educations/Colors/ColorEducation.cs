using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColorEducation : MonoBehaviour
{
    [HideInInspector]
    public static ColorEducation instance;
    [SerializeField]
    private GameObject[] colors;

    private int currentColorIndex=0;
    public event Action OnColorEnd;
    private void Awake()
    {
        instance = this;
    }

    public void StartColorEducation(int index)
    {
        currentColorIndex = index;
        colors[currentColorIndex].SetActive(true);
    }
    public void InactiveColorEducation()
    {
        colors[currentColorIndex].SetActive(false);
    }
    public void OnColorEducationEnd()
    {
        OnColorEnd?.Invoke();
    }


}
