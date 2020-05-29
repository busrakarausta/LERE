using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Listener : MonoBehaviour
{
    public AudioClip[] soundArray; 
    AudioSource aSource;
    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            aSource.clip = soundArray[0];
            aSource.Play();
        }
    }
}
