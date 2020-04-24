using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSoundProvider : MonoBehaviour
{
    public AudioClip[] testSoundArray;
    private AudioSource aSource;

    public void TestSoundPlayer(int index)
    {
        if (aSource == null)
        {
            aSource = GetComponent<AudioSource>();
        }
        aSource.clip = testSoundArray[index];
        aSource.Play();
    }
}
