using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EducationSoundsProvider : MonoBehaviour
{
    public AudioClip[] educationSoundArray;
    private AudioSource aSource;

    public void EducationSoundPlayer(int index) {
        if (aSource == null)
        {
            aSource = GetComponent<AudioSource>();
        }
        aSource.clip = educationSoundArray[index];
        aSource.Play();    
    }
}
