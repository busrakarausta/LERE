using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EducationController : MonoBehaviour
{
    [SerializeField]
    private GameObject education;
    [SerializeField]
    private GameObject letterEducation;
    [SerializeField]
    private GameObject numberEducation;
    [SerializeField]
    private GameObject colorEducationPanel;

    private WritingHandler _writingHandler;
    private ColorEducation _colorEducation;
    private GameObject _education;

    public event Action OnLetterEducationEnd;
    private EducationSoundsProvider educationSoundsProvider;
    private int status;

    public void InActiveEducation()
    {
        Debug.Log("EducationController/InActiveEducation");
        if(status == 2)
        {
            _colorEducation.InactiveColorEducation();
            colorEducationPanel.SetActive(false);
        }
        else
        {
            _writingHandler?.InactiveCurrentLetter();
            education.SetActive(false);
        }
    }

    private void Awake()
    {
        Debug.Log("EducationController/Awake");
        _colorEducation.OnColorEnd += OnEducationEnd;
        educationSoundsProvider = education.GetComponent<EducationSoundsProvider>();

    }
    private void Education(int index) // kacinci element oldugunu soyluyorum
    {
        educationSoundsProvider = education.GetComponent<EducationSoundsProvider>();
        Debug.Log("EducationController/StartLetterEducation");

        educationSoundsProvider.EducationSoundPlayer(status,index);

        if (status == 2)
        {
            colorEducationPanel.SetActive(true);
            _colorEducation.StartColorEducation(index);
        }
        else
        {
            _education.SetActive(true);
            education.SetActive(true);

            _writingHandler = _education.GetComponent<WritingHandler>();
            _writingHandler.OnLetterEnd += OnEducationEnd;
            _writingHandler.SetCurrentIndex(status, index);
        }

    }

    public void StartEducation(int index, char obj)
    {
        status = index;
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
            itemIndex = (obj - '0')-1;
        }
        else if (index == 2)
        {
            itemIndex = (obj - '0') - 1;
        }

        Education(itemIndex);
    }

    private void OnEducationEnd()
    {
        Debug.Log("EducationController/OnLetterEnd");

        OnLetterEducationEnd?.Invoke();
    }

}
