using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MonkeyControl : MonoBehaviour , IPointerDownHandler
{
    public GameObject monkey_right;
    public GameObject monkey_left;
    private Animator anim_right;
    private Animator anim_left;
    private int clickCount = 0;
   
    void Awake()
    {
        anim_right = monkey_right.GetComponent<Animator>();
        anim_left = monkey_left.GetComponent<Animator>();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name== "Monkey2" && clickCount<=1)
        {
            JumpRightMonkey();
        }
        else if (gameObject.name== "Monkey1" && clickCount<=1)
        {
            JumpLeftMonkey();
        }
    }

    public void JumpRightMonkey()
    {
        anim_right.SetTrigger("Monkey_right");
    }
    public void JumpLeftMonkey()
    {
        anim_left.SetTrigger("Monkey_left");
    }
}
