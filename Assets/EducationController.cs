using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EducationController : MonoBehaviour
{
    [SerializeField]
    private WritingHandler _writingHandler;

    [SerializeField]
    private GameObject letterEducation;

    

    public event Action OnLetterEducationEnd;
    private EducationSoundsProvider educationSoundsProvider;

    public void InActiveEducation()
    {
        _writingHandler.InactiveCurrentLetter();
        letterEducation.SetActive(false);
    }

    private void Awake()
    {
        educationSoundsProvider = letterEducation.GetComponent<EducationSoundsProvider>();
        _writingHandler.OnLetterEnd += OnLetterEnd;

        //
    }
    public void StartLetterEducation(char letter)
    {
        int index = (letter - 'A');

        educationSoundsProvider.EducationSoundPlayer(index);

        letterEducation.SetActive(true);
        _writingHandler.SetCurrentLetterIndex(index);
        _writingHandler.LoadLetter();
    }

    private void OnLetterEnd()
    {
        OnLetterEducationEnd?.Invoke();
    }

}
