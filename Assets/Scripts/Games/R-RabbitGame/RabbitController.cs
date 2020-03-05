using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RabbitController : MonoBehaviour,IPointerDownHandler
{
    public GameObject rabbit_right;
    public GameObject rabbit_left;
    private Animator anim_right;
    private Animator anim_left;
    private AudioSource source;
    private int clickCount = 0;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        anim_right = rabbit_right.GetComponent<Animator>();
        anim_left = rabbit_left.GetComponent<Animator>();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        clickCount++;
        if (clickCount == 1)
        {
            JumpRightRabbit();
        }
        else if (clickCount == 2)
        {
            JumpLeftRabbit();
        }
        else
        {
            Debug.Log("pass game");
        }
    }

    public void JumpRightRabbit()
    {
        rabbit_right.SetActive(true);
        anim_right.SetTrigger("Play_right");
        
        source.Play();
    }
    public void JumpLeftRabbit()
    {
        rabbit_left.SetActive(true);
        anim_left.SetTrigger("Play_left");
        
        source.Play();
    }
    
    
}
