using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EducationController : MonoBehaviour
{
    [SerializeField]
    private WritingHandler _writingHandler;

    [SerializeField]
    private GameObject education;
    [SerializeField]
    private GameObject letterEducation;
    [SerializeField]
    private GameObject numberEducation;
    [SerializeField]
    private GameObject colorEducation;

    private GameObject _education;

    public event Action OnLetterEducationEnd;
    private EducationSoundsProvider educationSoundsProvider;

    public void InActiveEducation()
    {
        Debug.Log("EducationController/InActiveEducation");

        _writingHandler.InactiveCurrentLetter();
        education.SetActive(false);
    }

    private void Awake()
    {
        Debug.Log("EducationController/Awake");

        educationSoundsProvider = education.GetComponent<EducationSoundsProvider>();
        _writingHandler.OnLetterEnd += OnLetterEnd;

    }
    private void Education(int status,int index) // kacinci element oldugunu soyluyorum
    {
        educationSoundsProvider = education.GetComponent<EducationSoundsProvider>();
        Debug.Log("EducationController/StartLetterEducation");

        educationSoundsProvider.EducationSoundPlayer(status,index);

        _education.SetActive(true);
        _writingHandler.SetCurrentIndex(status,index);
    }

    public void StartEducation(int index, char obj)
    {
        education.SetActive(true);

        int itemIndex=0;

        if(_education != null)
            _education.SetActive(false);

        if (index == 0)
        {
            _education = letterEducation;
            itemIndex = (obj - 'A');
        }
        else if(index==1)
        {
            _education = numberEducation;
            itemIndex = (obj - '0');
        }
        else if (index == 2)
        {
            _education = colorEducation;
        }

        Education(index, itemIndex);
    }

    private void OnLetterEnd()
    {
        Debug.Log("EducationController/OnLetterEnd");

        OnLetterEducationEnd?.Invoke();
    }

}
